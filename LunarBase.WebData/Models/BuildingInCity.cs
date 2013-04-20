using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace LunarBase.WebData.Models
{
    public class BuildingInCity
    {
        [DataMember(Name = "Id")]
        private string id = string.Empty;
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string buildingId = string.Empty;
        [DataMember]
        public string BuildingId
        {
            get { return buildingId; }
            set { buildingId = value; }
        }

        private Building building = new Building();
        [BsonIgnore]
        [DataMember]
        public Building Building
        {
            get { return building; }
            set { building = value; }
        }

        [DataMember]
        public BuildingStatuses Status { get; set; }
    }
}
