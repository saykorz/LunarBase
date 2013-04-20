using System.Collections.ObjectModel;
using System.Linq;
using LunarBase.Library.GameService;
using LunarBase.Library.Models;
using UserProfile = LunarBase.Library.GameService.UserProfile;

namespace LunarBase.Library
{
    public class ApplicationViewModel : PropertyChange
    {
        private UserProfile userProfile = new UserProfile();
        public UserProfile UserProfile
        {
            get
            {
                return this.userProfile;
            }
            set
            {
                this.userProfile = value;
                RaisePropertyChanged("UserProfile");
            }
        }

        private ObservableCollection<Building> allBuildings = new ObservableCollection<Building>();
        public ObservableCollection<Building> AllBuildings
        {
            get
            {
                if (allBuildings.Count == 0)
                {
                    var client = new GameServiceClient();
                    client.GetBuildingsCompleted += client_GetBuildingsCompleted;
                    client.GetBuildingsAsync("", AppCache.ApplicationViewModel.UserProfile.CityId);
                }
                return allBuildings;
            }
            set 
            {
                allBuildings = value;
                RaisePropertyChanged("AllBuildings");
            }
        }

        void client_GetBuildingsCompleted(object sender, GetBuildingsCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                foreach (var building in e.Result)
                {
                    this.allBuildings.Add(building);
                }
                RaisePropertyChanged("AllBuildings");
            }
        }

        private ObservableCollection<Race> races = new ObservableCollection<Race>();
        public ObservableCollection<Race> Races
        {
            get
            {
                if (races.Count == 0)
                {
                    var client = new GameServiceClient();
                    client.GetRacesCompleted += client_GetRacesCompleted;
                    client.GetRacesAsync("");
                }
                return races;
            }
            set { races = value; }
        }

        void client_GetRacesCompleted(object sender, GetRacesCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                foreach (var race in e.Result)
                {
                    this.races.Add(race);    
                }
            }
        }

        #region BusyIndicator

        private ObservableCollection<string> isBusyPool = new ObservableCollection<string>();
        public ObservableCollection<string> IsBusyPool
        {
            get { return isBusyPool; }
            set
            {
                isBusyPool = value;
                RaisePropertyChanged("IsBusyPool");
            }
        }

        private bool showMessageBox = false;
        public bool ShowMessageBox
        {
            get { return showMessageBox; }
            set
            {
                showMessageBox = value;
                RaisePropertyChanged("ShowMessageBox");
            }
        }

        private MessageBoxDataContext messageBoxDataContext = new MessageBoxDataContext();
        public MessageBoxDataContext MessageBoxDataContext
        {
            get { return messageBoxDataContext; }
            set
            {
                messageBoxDataContext = value;
                RaisePropertyChanged("MessageBoxDataContext");
            }
        }

        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        private string isBusyMessage = "Please Wait...";
        public string IsBusyMessage
        {
            get { return isBusyMessage; }
            set
            {
                isBusyMessage = value;
                RaisePropertyChanged("IsBusyMessage");
            }
        }

        

        #endregion

        
    }
}
