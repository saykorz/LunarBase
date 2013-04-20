using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace LunarBase.Library
{
    public class FilterableNotifiableCollection<T> : INotifyCollectionChanged, INotifyPropertyChanged, IEnumerable<T>,
                                                     IEnumerable
    {
        #region Class Level Variables

        private ObservableCollection<T> sourceCollection;
        private Predicate<T> currentFilter;

        #endregion

        #region Events

        private event NotifyCollectionChangedEventHandler collectionChanged;
        private event PropertyChangedEventHandler propertyChanged;

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add { collectionChanged += value; }
            remove { collectionChanged -= value; }
        }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add { propertyChanged += value; }
            remove { propertyChanged -= value; }
        }

        #endregion

        #region Properties

        public Predicate<T> Filter
        {
            get { return currentFilter; }
            set
            {
                currentFilter = value;
                this.RefreshCollection();
            }
        }

        public ObservableCollection<T> CoreCollection
        {
            get { return this.sourceCollection; }
        }

        public T this[int index]
        {
            get
            {
                if (this.currentFilter == null)
                {
                    return this.sourceCollection[index];
                }
                else
                {
                    int currentIndex = 0;
                    for (int i = 0; i < this.sourceCollection.Count; i++)
                    {
                        T indexitem = this.sourceCollection[i];
                        if (this.currentFilter(indexitem))
                        {
                            if (currentIndex.Equals(index))
                            {
                                return indexitem;
                            }
                            else
                            {
                                currentIndex++;
                            }
                        }
                    }
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (this.currentFilter == null)
                {
                    this.sourceCollection[index] = value;
                }
                else if (!this.currentFilter(value))
                {
                    throw new InvalidOperationException("Value doesn't match the filter criteria.");
                }
                else
                {
                    bool valueNotSet = true;
                    int currentIndex = 0;
                    for (int i = 0; i < this.sourceCollection.Count; i++)
                    {
                        T indexitem = this.sourceCollection[i];
                        if (this.currentFilter(indexitem))
                        {
                            if (currentIndex.Equals(index))
                            {
                                this.sourceCollection[i] = value;
                                valueNotSet = false;
                                break;
                            }
                            else
                            {
                                currentIndex++;
                            }
                        }
                    }

                    if (valueNotSet)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                }
            }
        }

        #endregion

        #region Constructors

        public FilterableNotifiableCollection(ObservableCollection<T> collectionParam)
        {
            this.sourceCollection = collectionParam;
            currentFilter = null;
            this.sourceCollection.CollectionChanged +=
                new NotifyCollectionChangedEventHandler(SourceCollection_CollectionChanged);
            ((INotifyPropertyChanged) sourceCollection).PropertyChanged +=
                new PropertyChangedEventHandler(SourceCollection_PropertyChanged);
        }

        #endregion

        #region Event Handlers

        private void SourceCollection_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (propertyChanged != null)
            {
                propertyChanged(this, e);
            }
        }

        private void SourceCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (collectionChanged != null)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        collectionChanged(this,
                                          new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        collectionChanged(this,
                                          new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        collectionChanged(this,
                                          new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        collectionChanged(this,
                                          new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                        break;
                    default:
                        break;
                }
            }

        }

        #endregion

        #region Public Methods

        public void Add(T item)
        {
            this.sourceCollection.Add(item);
        }

        public void Remove(T item)
        {
            this.sourceCollection.Remove(item);
        }

        public int IndexOf(T item)
        {
            if (currentFilter == null)
                return this.sourceCollection.IndexOf(item);
            else
            {
                int count = 0;
                for (int i = 0; i < this.sourceCollection.Count; i++)
                {
                    T indexitem = this.sourceCollection[i];
                    if (currentFilter(indexitem))
                    {
                        if (indexitem.Equals(item))
                            return count;
                        else
                            count++;
                    }
                }
                return -1;
            }
        }

        public void Clear()
        {
            if (currentFilter == null)
            {
                this.sourceCollection.Clear();
            }
            else
            {
                for (int i = 0; i < this.sourceCollection.Count;)
                {
                    T item = this.sourceCollection[i];

                    if (currentFilter(item))
                    {
                        this.sourceCollection.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }

        }

        public bool Contains(T item)
        {
            if (currentFilter != null && currentFilter(item) == false)
            {
                return false;
            }

            return this.sourceCollection.Contains(item);
        }

        public int Count
        {
            get
            {
                if (currentFilter == null)
                {
                    return this.sourceCollection.Count;
                }
                else
                {
                    int count = 0;
                    for (int i = 0; i < this.sourceCollection.Count; i++)
                    {
                        T item = this.sourceCollection[i];

                        if (currentFilter(item))
                        {
                            count++;
                        }
                    }

                    return count;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new FilterableEnumerator(this, this.sourceCollection.GetEnumerator());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new FilterableEnumerator(this, this.sourceCollection.GetEnumerator());
        }

        public IEnumerable<T> GetFilteredEnumerableGeneric()
        {
            return new FilterableEnumerable(this, this.sourceCollection.GetEnumerator());
        }

        public IEnumerable GetFilteredEnumerable()
        {
            return new FilterableEnumerable(this, this.sourceCollection.GetEnumerator());
        }

        #endregion

        #region Private Methods

        private void RefreshCollection()
        {
            if (collectionChanged != null)
            {
                collectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        #endregion

        #region Inner Classes

        private class FilterableEnumerable : IEnumerable<T>, IEnumerable
        {
            private FilterableNotifiableCollection<T> filterableNotifiableCollection;
            private IEnumerator<T> enumerator;

            public FilterableEnumerable(FilterableNotifiableCollection<T> filterablecollection,
                                        IEnumerator<T> enumeratorParam)
            {
                filterableNotifiableCollection = filterablecollection;
                enumerator = enumeratorParam;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new FilterableEnumerator(filterableNotifiableCollection, enumerator);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new FilterableEnumerator(filterableNotifiableCollection, enumerator);
            }
        }

        private class FilterableEnumerator : IEnumerator<T>, IEnumerator
        {
            private FilterableNotifiableCollection<T> filterableObservableCollection;
            private IEnumerator<T> enumerator;

            public FilterableEnumerator(FilterableNotifiableCollection<T> filterablecollection,
                                        IEnumerator<T> enumeratorParam)
            {
                filterableObservableCollection = filterablecollection;
                enumerator = enumeratorParam;
            }

            public T Current
            {
                get
                {
                    if (filterableObservableCollection.Filter == null)
                        return enumerator.Current;
                    else if (filterableObservableCollection.Filter(enumerator.Current) == false)
                        throw new InvalidOperationException();
                    else
                        return enumerator.Current;
                }
            }

            public void Dispose()
            {
                enumerator.Dispose();
            }

            object IEnumerator.Current
            {
                get { return this.Current; }
            }

            public bool MoveNext()
            {
                while (true)
                {
                    if (enumerator.MoveNext() == false)
                        return false;
                    if (filterableObservableCollection.Filter == null
                        || filterableObservableCollection.Filter(enumerator.Current) == true)
                        return true;
                }
            }

            public void Reset()
            {
                enumerator.Reset();
            }
        }

        #endregion

    }
}