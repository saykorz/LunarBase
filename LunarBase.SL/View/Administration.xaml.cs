using LunarBase.Library;
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
using LunarBase.Library.Extensions;
using LunarBase.Library.GameService;

namespace LunarBase.SL.View
{
    public partial class Administration : UserControl
    {
        public Administration()
        {
            InitializeComponent();
            this.Loaded += Administration_Loaded;
        }

        void Administration_Loaded(object sender, RoutedEventArgs e)
        {
            //lbBuildings.ItemsSource = AppCache.ApplicationViewModel.AllBuildings;
            //lbBuildings.SetBinding(ListBox.ItemsSourceProperty, AppCache.ApplicationViewModel, "AllBuildings");
        }
        
        #region Building
        private void AddBuildingButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            BuildingSaveCancelStackPanel.Visibility = Visibility.Visible;
            btnBuildingAdd.Visibility = Visibility.Collapsed;

            var b = new Building();
            grdBuildingForm.DataContext = b;
            btnBuildingSave.SetBinding(Button.TagProperty, grdBuildingForm, "DataContext");
        }

        private void EditBuildingButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            BuildingSaveCancelStackPanel.Visibility = Visibility.Visible;
            BuildingEditRemoveStackPanel.Visibility = Visibility.Collapsed;
            btnBuildingAdd.Visibility = Visibility.Collapsed;

            var b = lbBuildings.SelectedItem as Building;
            if (b == null)
                b = new Building();
            grdBuildingForm.DataContext = b;
            //btnSave.Tag = b;
            btnBuildingSave.SetBinding(Button.TagProperty, grdBuildingForm, "DataContext");
            //btnSave.SetBinding(Button.TagProperty, lbBuildings, "SelectedItem");
            
        }

        private void RemoveBuildingButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            BuildingEditRemoveStackPanel.Visibility = Visibility.Collapsed;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this item?\nThis cannot be undone", "Delete Item", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                //TODO delete from database
                var b = lbBuildings.SelectedItem as Building;
                grdBuildingForm.DataContext = b;
                
            }
        }

        private void SaveBuildingButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add to the database. trqbva da se proverqva dali dobavq nov ili redaktira zapis ili trie

            Button btnAction = sender as Button;
            if (btnAction != null)
            {
                var b = btnAction.Tag as Building;
                if (b != null)
                {
                    var client = new GameServiceClient();
                    client.SaveBuildingCompleted += client_SaveBuildingCompleted;
                    client.SaveBuildingAsync("", b);
                }
            }

            //DeleteBuildingTextBoxs();
            BuildingSaveCancelStackPanel.Visibility = Visibility.Collapsed;
            btnBuildingAdd.Visibility = Visibility.Visible;
        }

        private void CancelBuildingButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            //DeleteBuildingTextBoxs();
            BuildingSaveCancelStackPanel.Visibility = Visibility.Collapsed;
        }

        private void DeleteBuildingTextBoxs()
        {
            txtNameBuilding.Text = string.Empty;
            txtBuildsCompleted.Text = string.Empty;
            txtBuildsRequested.Text = string.Empty;
        }

        void client_SaveBuildingCompleted(object sender, SaveBuildingCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (!AppCache.ApplicationViewModel.AllBuildings.Any(b => b.Id == e.Result.Id))
                    AppCache.ApplicationViewModel.AllBuildings.Add(e.Result);
            }
        }
        private void lbBuildings_SelectionChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            BuildingEditRemoveStackPanel.Visibility = Visibility.Visible;

            // TODO: Add listview items to right panel
        }

        private void PeopleBrowser_DeletingItem(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete this item?\nThis cannot be undone", "Delete Item", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {

                e.Cancel = true;

            }

        }
        #endregion

        #region Race
        private void AddRaceButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            RaceSaveCancelStackPanel.Visibility = Visibility.Visible;
        }

        private void EditRaceButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            RaceSaveCancelStackPanel.Visibility = Visibility.Visible;
            RaceEditRemoveStackPanel.Visibility = Visibility.Collapsed;
        }

        private void RemoveRaceButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            RaceSaveCancelStackPanel.Visibility = Visibility.Visible;
            RaceEditRemoveStackPanel.Visibility = Visibility.Collapsed;
        }

        /*private void CloseButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
        }*/

        private void SaveRaceButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add to the database.
            
            //DeleteRaceTextBoxs();
            RaceSaveCancelStackPanel.Visibility = Visibility.Collapsed;
        }

        private void CancelRaceButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteRaceTextBoxs();
            RaceSaveCancelStackPanel.Visibility = Visibility.Collapsed;
        }

        private void DeleteRaceTextBoxs()
        {
            txtNameRace.Text = string.Empty;
            txtBuildsCompleted.Text = string.Empty;
            txtBuildsRequested.Text = string.Empty;
        }

        private void lbRaces_SelectionChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            RaceEditRemoveStackPanel.Visibility = Visibility.Visible;

            // TODO: Add listview items to right panel
        }
        #endregion

        #region Resources
        private void AddResourceButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            ResourceSaveCancelStackPanel.Visibility = Visibility.Visible;
        }

        private void EditResourceButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            ResourceSaveCancelStackPanel.Visibility = Visibility.Visible;
            ResourceEditRemoveStackPanel.Visibility = Visibility.Collapsed;
        }

        private void RemoveResourceButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            ResourceSaveCancelStackPanel.Visibility = Visibility.Visible;
            ResourceEditRemoveStackPanel.Visibility = Visibility.Collapsed;
        }

        /*private void CloseButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
        }*/

        private void SaveResourceButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add to the database.
            
            //DeleteResourceTextBoxs();
            ResourceSaveCancelStackPanel.Visibility = Visibility.Collapsed;
        }

        private void CancelResourceButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteResourceTextBoxs();
            ResourceSaveCancelStackPanel.Visibility = Visibility.Collapsed;
        }

        private void DeleteResourceTextBoxs()
        {
            txtNameResource.Text = string.Empty;
            txtBuildsCompleted.Text = string.Empty;
            txtBuildsRequested.Text = string.Empty;
        }

        private void lbResource_SelectionChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            ResourceEditRemoveStackPanel.Visibility = Visibility.Visible;

            // TODO: Add listview items to right panel
        }
        #endregion
                
        
    }
}
