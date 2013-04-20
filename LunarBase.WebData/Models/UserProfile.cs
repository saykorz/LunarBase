using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace LunarBase.WebData.Models
{
    public class UserProfile : PropertyChange
    {
        private string id = string.Empty;
        [DataMember(Name = "Id")]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string userName = string.Empty;
        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged("UserName"); }
        }

        private object providerUserKey;
        public object ProviderUserKey
        {
            get { return providerUserKey; }
            set { providerUserKey = value; RaisePropertyChanged("ProviderUserKey"); }
        }

        private string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { email = value; RaisePropertyChanged("Email"); }
        }

        private bool isApproved = false;
        public bool IsApproved
        {
            get { return this.isApproved; }
            set { this.isApproved = value; RaisePropertyChanged("IsApproved"); }
        }

        private string raceId = string.Empty;
        [BsonRepresentation(BsonType.ObjectId)]
        public string RaceId
        {
            get { return raceId; }
            set { raceId = value; }
        }

        
        private string cityId = string.Empty;
        [BsonRepresentation(BsonType.ObjectId)]
        public string CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }

        private City city = new City();
        [BsonIgnore]
        public City City
        {
            get { return city; }
            set { city = value; }
        }
    }
}
