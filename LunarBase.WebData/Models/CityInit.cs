using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace LunarBase.WebData.Models
{
    public class CityInit
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
        public string CityId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Latitude { get; set; }

        [DataMember]
        public double Longitude { get; set; }
    }
}
