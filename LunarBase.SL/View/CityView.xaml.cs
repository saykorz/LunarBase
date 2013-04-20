using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using LunarBase.Library;
using LunarBase.Library.GameService;
using LunarBase.Library.Models;

namespace LunarBase.SL.View
{
    public partial class CityView : UserControl
    {
        BuildingListViewModel buildingViewModel;

        public CityView()
        {
            InitializeComponent();
            this.Loaded += CityView_Loaded;
        }

        void CityView_Loaded(object sender, RoutedEventArgs e)
        {
            buildingViewModel = new BuildingListViewModel();
            lbNewBuildings.pnlBuildings.ItemsSource = buildingViewModel.GetNewBuildings;
            lbBuildingQuery.pnlBuildings.ItemsSource = buildingViewModel.GetBuildingsInQuery;
            lbBuildingsCompleted.pnlBuildings.ItemsSource = buildingViewModel.GetBuildingsCompleted;
        }

        public void btnStartProduction_OnClick(object sender, RoutedEventArgs e)
        {
            daNewBuildingsTop.To = -this.pnlNewBuildings.ActualHeight;
            sbOpenNewBuildingPanelTop.Begin();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            AppCache.ApplicationViewModel.AllBuildings.Add(new Building() {Name = "dsda"});
        }

        private void btnStartBuilding_OnClick(object sender, RoutedEventArgs e)
        {
            var building = lbNewBuildings.pnlBuildings.SelectedItem as Building;
            if (building != null)
            {
                BuildingInCity buildingInCity = new BuildingInCity();
                buildingInCity.Status = BuildingStatuses.InQuery;
                buildingInCity.BuildingId = building.Id;
                buildingInCity.Building = building;

                AppCache.ApplicationViewModel.UserProfile.City.BuildingsInCity.Add(buildingInCity);
                AppCache.ApplicationViewModel.UserProfile.City.BuildingInCityIds.Add(building.Id);

                var client = new GameServiceClient();
                client.SaveBuildingInCityCompleted += client_SaveBuildingInCityCompleted;
                client.SaveBuildingInCityAsync("", buildingInCity);

                buildingViewModel.initGetNewBuildings();
                lbNewBuildings.pnlBuildings.ItemsSource = buildingViewModel.GetNewBuildings;
            }
        }

        void client_SaveBuildingInCityCompleted(object sender, SaveBuildingInCityCompletedEventArgs e)
        {
            
        }

        private void btnCancelBuilding_OnClick(object sender, RoutedEventArgs e)
        {
            sbOpenNewBuildingPanelDown.Begin();
        }
    }
}
