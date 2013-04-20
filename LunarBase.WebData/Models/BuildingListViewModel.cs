using System;
using System.Linq;
using System.Windows;
using LunarBase.Library.GameService;
using LunarBase.WebData;

namespace LunarBase.WebData.Models
{
    public class BuildingListViewModel : DependencyObject
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
           DependencyProperty.Register("GetBuildingsInQuery", typeof(FilterableNotifiableCollection<Building>), typeof(BuildingListViewModel), null);

        public FilterableNotifiableCollection<Building> GetBuildingsInQuery
        {
            get
            {
                return (FilterableNotifiableCollection<Building>)base.GetValue(GetBuildingsInQueryProperty);
            }
            set
            {
                base.SetValue(GetBuildingsInQueryProperty, value);
            }
        }

        public BuildingListViewModel()
        {
            GetNewBuildings = new FilterableNotifiableCollection<Building>(AppCache.ApplicationViewModel.Buildings);
            GetNewBuildings.Filter = new Predicate<Building>(GetNewBuildingsFilter);

            GetBuildingsInQuery =
                new FilterableNotifiableCollection<Building>(
                    AppCache.ApplicationViewModel.UserProfile.City.BuildingsInCity.Where(
                        b => b.Status == BuildingStatuses.InQuery).Select(s => s.Building).ToObservableCollection());
                GetBuildingsInQuery.Filter = new Predicate<Building>(GetBuildingsInQueryFilter);
        }

        private bool GetNewBuildingsFilter(Building x)
        {
            if (AppCache.ApplicationViewModel.UserProfile.City != null)
            {
                return !AppCache.ApplicationViewModel.UserProfile.City.BuildingInCityIds.Contains(x.Id);
            }
            return false;
        }

        private bool GetBuildingsInQueryFilter(Building x)
        {
            return true;// x.Status == BuildingStatuses.InQuery;
        }
    }
}
