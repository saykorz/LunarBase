using System.Collections.ObjectModel;
using System.Runtime.Serialization;
#if !SILVERLIGHT
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
#endif

namespace LunarBase.WebData.Models
{
    public class Building : PropertyChange
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

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged("Name"); }
        }

        [DataMember]
        public ObservableCollection<ResourceInBuilding> Resources { get; set; }

        private int buildsRequested = 0;
        //[DataMember]
        public int BuildsRequested
        {
            get { return buildsRequested; }
            set { buildsRequested = value; RaisePropertyChanged("BuildsRequested"); }
        }
        
        private int buildsCompleted = 0;
        //[DataMember]
        public int BuildsCompleted
        {
            get { return buildsCompleted; }
            set { buildsCompleted = value; RaisePropertyChanged("BuildsCompleted"); }
        }
    }
}
