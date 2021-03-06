﻿using System.Runtime.Serialization;
#if !SILVERLIGHT
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
#endif

namespace LunarBase.WebData.Models
{
    public class ResourceInBuilding
    {
        [DataMember(Name = "Id")]
        private string id = string.Empty;
#if !SILVERLIGHT
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
#endif
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string ResourceId { get; set; }
        public int ProducePerTurn { get; set; }
        public UsefullTypes UsefullType { get; set; }
    }
}
