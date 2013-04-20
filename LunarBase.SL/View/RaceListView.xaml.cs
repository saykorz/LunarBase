using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using LunarBase.Library;
using LunarBase.Library.GameService;
using SaykorControls.SL;

namespace LunarBase.SL.View
{
    public partial class RaceListView : UserControl
    {
        public RaceListView()
        {
            InitializeComponent();
            //HtmlPage.RegisterScriptableObject("RaceListView", this);
        }

        public void btnSelectRace_OnClick(object sender, RoutedEventArgs e)
        {
            ImageButton btnAction = sender as ImageButton;
            if (btnAction != null && btnAction.Tag != null)
            {
                AppCache.ApplicationViewModel.UserProfile.RaceId = btnAction.Tag.ToString();

                string jsResult = HtmlPage.Window.Invoke("getRandomPosition", null) as string;
                GetCityCoordinates(jsResult);
            }
        }
        
        public void GetCityCoordinates(string cityCoordinate)
        {
            if (!string.IsNullOrEmpty(cityCoordinate))
            {
                if (AppCache.ApplicationViewModel.UserProfile.City == null)
                {
                    AppCache.ApplicationViewModel.UserProfile.City = new City();
                }
                AppCache.ApplicationViewModel.UserProfile.City.Latitude = cityCoordinate.Split(',')[0].Trim().Replace("(", "");
                AppCache.ApplicationViewModel.UserProfile.City.Longitude = cityCoordinate.Split(',')[1].Trim().Replace(")", "");
                
                var client = new GameServiceClient();

                client.SaveUserProfileCompleted += client_SaveUserProfileCompleted;
                client.SaveUserProfileAsync("", AppCache.ApplicationViewModel.UserProfile);
            }
        }

        void client_SaveUserProfileCompleted(object sender, SaveUserProfileCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                AppCache.ApplicationViewModel.UserProfile = e.Result;
            }
        }
    }
}
