using System.Configuration;
using MongoDB.Driver;

namespace LunarBase.WebData
{
    public static class Configuration
    {
        private static string pictureExtension = ".jpg";
        public static string PictureExtension { get { return pictureExtension; } }

        private static string pictureFolder = ApplicationDomain + "/App_Themes/Default/GameResources/Images/"; 
        public static string PictureFolder { get { return pictureFolder; } }

        private static string applicationDomain = string.Empty;
        public static string ApplicationDomain
        {
            get { return applicationDomain; }
            set
            {
                if (string.IsNullOrEmpty(applicationDomain))
                {
                    applicationDomain = value;
                }
            }
        }

        public static MongoDatabase db
        {
            get
            {
                var connectionstring = ConfigurationManager.AppSettings["MONGOLAB_URI"];
                string dbName = MongoUrl.Create(connectionstring).DatabaseName;
                MongoServer dbServer = MongoServer.Create(connectionstring);
                MongoDatabase dbConnection = dbServer.GetDatabase(dbName, SafeMode.True);
                return dbConnection;
            }
        }

        
    }
}
