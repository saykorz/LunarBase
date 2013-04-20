using System;
using System.ComponentModel;
using System.Windows;
using LunarBase.Library.GameService;

namespace LunarBase.Library.Models
{
    public class BuildingListViewModel : DependencyObject, INotifyPropertyChanged
    {
        public static readonly DependencyProperty GetBuildingsNotCompletedProperty =
           DependencyProperty.Register("GetNewBuildings", typeof(FilterableNotifiableCollection<Building>), typeof(BuildingListViewModel), null);

        public FilterableNotifiableCollection<Building> GetNewBuildings
        {
            get
            {
                return (FilterableNotifiableCollection<Building>)base.GetValue(GetBuildingsNotCompletedProperty);
            }
            set
            {
                base.SetValue(GetBuildingsNotCompletedProperty, value);
            }
        }

        public static readonly DependencyProperty GetBuildingsInQueryProperty =
           DependencyProperty.Register("GetBuildingsInQuery", typeof(FilterableNotifiableCollection<BuildingInCity>), typeof(BuildingListViewModel), null);

        public FilterableNotifiableCollection<BuildingInCity> GetBuildingsInQuery
        {
            get
            {
                return (FilterableNotifiableCollection<BuildingInCity>)base.GetValue(GetBuildingsInQueryProperty);
            }
            set
            {
                base.SetValue(GetBuildingsInQueryProperty, value);
            }
        }

        public static readonly DependencyProperty GetBuildingsCompletedProperty =
           DependencyProperty.Register("GetBuildingsCompleted", typeof(FilterableNotifiableCollection<BuildingInCity>), typeof(BuildingListViewModel), null);

        public FilterableNotifiableCollection<BuildingInCity> GetBuildingsCompleted
        {
            get
            {
                return (FilterableNotifiableCollection<BuildingInCity>)base.GetValue(GetBuildingsCompletedProperty);
            }
            set
            {
                base.SetValue(GetBuildingsCompletedProperty, value);
            }
        }

        public BuildingListViewModel()
        {
            initGetNewBuildings();

            GetBuildingsInQuery = new FilterableNotifiableCollection<BuildingInCity>(AppCache.ApplicationViewModel.UserProfile.City.BuildingsInCity);
            GetBuildingsInQuery.Filter = new Predicate<BuildingInCity>(GetBuildingsInQueryFilter);

            GetBuildingsCompleted = new FilterableNotifiableCollection<BuildingInCity>(AppCache.ApplicationViewModel.UserProfile.City.BuildingsInCity);
            GetBuildingsCompleted.Filter = new Predicate<BuildingInCity>(GetBuildingsCompletedFilter);
        }

        public void initGetNewBuildings()
        {
            GetNewBuildings = new FilterableNotifiableCollection<Building>(AppCache.ApplicationViewModel.AllBuildings);
            GetNewBuildings.Filter = new Predicate<Building>(GetNewBuildingsFilter);
        }

        public bool GetNewBuildingsFilter(Building x)
        {
            if (AppCache.ApplicationViewModel.UserProfile.City != null)
            {
                return !AppCache.ApplicationViewModel.UserProfile.City.BuildingInCityIds.Contains(x.Id);
            }
            return false;
        }

        private bool GetBuildingsInQueryFilter(BuildingInCity x)
        {
            return x.Status == BuildingStatuses.InQuery;
        }

        private bool GetBuildingsCompletedFilter(BuildingInCity x)
        {
            return x.Status == BuildingStatuses.Completed;
        }

        public void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
