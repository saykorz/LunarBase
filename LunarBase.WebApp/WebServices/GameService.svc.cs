using System.Linq;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Security;
using LunarBase.WebData;
using LunarBase.WebData.Models;

namespace LunarBase.WebApp.WebServices
{
    [ServiceContract(Namespace = "GameService")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class GameService
    {
        [OperationContract]
        public UserProfile Login(string email, string password)
        {
            if (MongoHelpers.IsUserValid(email, password))
            {
                var userProfile = MongoHelpers.LoadData<UserProfile>().FirstOrDefault(u => u.Email == email);
                if (userProfile != null)
                {
                    var city = MongoHelpers.LoadData<City>().FirstOrDefault(c => c.Id == userProfile.CityId);
                    if (city != null)
                    {
                        userProfile.City = city;
                    }
                    return userProfile;
                }
                return MongoHelpers.CreateUserProfile(Membership.GetUser(email));
            }
            return MongoHelpers.CreateUserProfile(MongoHelpers.Register(email, password));
        }

        [OperationContract]
        public ObservableCollection<CityInit> GetCityCoordinates(double latitude, double longitude, double radius)
        {
            var ci = new ObservableCollection<CityInit>();
            MongoHelpers.LoadData<City>().ToObservableCollection().ForEach(c => ci.Add(new CityInit()
                {
                    CityId = c.Id,
                    Latitude = c.Latitude,
                    Longitude = c.Longitude,
                    Name = c.Name
                }));//.Where(c => c.Latitude is between latitude +- radius && c.Longtitude is between longitude +- radius )
            return ci;
        }
        
        [OperationContract]
        public City GetCity(string authToken, string cityId)
        {
            var city = MongoHelpers.LoadData<City>().FirstOrDefault(c => c.Id == cityId);
            return city;
        }

        [OperationContract]
        public Building SaveBuilding(string authToken, Building building)
        {
            MongoHelpers.SaveData(building);
            return building;
        }

        [OperationContract]
        public ObservableCollection<Building> GetBuildings(string authToken)
        {
            var buildings = MongoHelpers.LoadData<Building>().ToObservableCollection();
            //var city = MongoHelpers.LoadData<City>().FirstOrDefault(c => c.Id == cityId);
            //if (city != null)
            //{
            //    city.BuildingInCityIds.ForEach(bId =>
            //        {
            //            var building = MongoHelpers.LoadData<Building>().FirstOrDefault(b => b.Id == bId);
            //            if (building != null)
            //            {
            //                buildings.Add(building);
            //            }
            //        });
            //}

            return buildings;
        }

        [OperationContract]
        public bool SaveBuildingInCity(string authToken, BuildingInCity buildingInCity)
        {
            return MongoHelpers.SaveData(buildingInCity).Ok;
        }

        [OperationContract]
        public bool SaveCity(string authToken, City city)
        {
            return MongoHelpers.SaveData(city).Ok;
        }

        [OperationContract]
        public UserProfile SaveUserProfile(string authToken, UserProfile userProfile)
        {
            MongoHelpers.SaveData(userProfile.City);
            userProfile.CityId = userProfile.City.Id;
            MongoHelpers.SaveData(userProfile);
            return userProfile;
        }

        [OperationContract]
        public ObservableCollection<Race> GetRaces(string authToken)
        {
            if (!IsTokenValid(authToken))
                return null;

            var races = new ObservableCollection<Race>();
            
            MongoHelpers.LoadData<Race>().ToList().ForEach(races.Add);

            return races;
        }

        //[OperationContract]
        //public string SaveSelectRace(string authToken, UserProfile userProfile)
        //{
        //    if (!IsTokenValid(authToken))
        //        return string.Empty;

        //    MongoHelpers.SaveData(userProfile);
            
        //    return userProfile.RaceId;
        //}

        private bool IsTokenValid(string authToken)
        {
            return true;
        }
    }
}
