using System.Runtime.Serialization;
#if !SILVERLIGHT
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
#endif

namespace LunarBase.WebData.Models
{
    [DataContract]
    public class Race
    {
        
        private string id = string.Empty;
        [DataMember(Name = "Id")]
#if !SILVERLIGHT
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
#endif
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Bonus { get; set; }

        private string pictureUri = string.Empty;
        [BsonIgnore]
        [DataMember]
        public string PictureUri
        {
            get
            {
                if (string.IsNullOrEmpty(this.pictureUri))
                {
                    this.pictureUri = Configuration.PictureFolder + this.GetType().Name + "/" + this.Name + Configuration.PictureExtension;
                }
                return pictureUri;
            }
            set
            {
                if (string.IsNullOrEmpty(this.pictureUri))
                {
                    this.pictureUri = Configuration.PictureFolder + this.GetType().Name + "/" + this.Name + Configuration.PictureExtension;
                }
            }
        }
    }
}
