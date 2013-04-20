using System.Linq;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
#if !SILVERLIGHT
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
#endif

namespace LunarBase.WebData.Models
{
    public class City
    {
        [DataMember(Name = "Id")]
        private string id = string.Empty;
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Latitude { get; set; }

        [DataMember]
        public string Longitude { get; set; }

        private ObservableCollection<string> buildingInCityIds = new ObservableCollection<string>();
        [DataMember]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObservableCollection<string> BuildingInCityIds
        {
            get { return buildingInCityIds; }
            set { buildingInCityIds = value; }
        }

        private ObservableCollection<BuildingInCity> buildingsInCity = new ObservableCollection<BuildingInCity>();
        [DataMember]
        [BsonIgnore]
        public ObservableCollection<BuildingInCity> BuildingsInCity
        {
            get { return buildingsInCity; }
            set { buildingsInCity = value; }
        }

        private ObservableCollection<string> unitinCityIds = new ObservableCollection<string>();
        [DataMember]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObservableCollection<string> UnitinCityIds
        {
            get { return unitinCityIds; }
            set { unitinCityIds = value; }
        }

        private ObservableCollection<string> resourceStorageIds = new ObservableCollection<string>();
        [DataMember]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObservableCollection<string> ResourceStorageIds
        {
            get { return resourceStorageIds; }
            set { resourceStorageIds = value; }
        }
    }
}
