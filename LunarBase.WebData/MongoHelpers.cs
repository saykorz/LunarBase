using System.Linq;
using System.Web.Security;
using LunarBase.WebData.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace LunarBase.WebData
{
    public static class MongoHelpers
    {
        public static IQueryable<T> LoadData<T>()
        {
            IQueryable<T> result = null;
            try
            {
                result = Configuration.db.GetCollection<T>(typeof(T).Name).AsQueryable();
            }
            catch (MongoConnectionException ex)
            {
                //no time to implement
            }
            return result;
        }

        public static SafeModeResult SaveData<T>(T value)
        {
            return Configuration.db.GetCollection<T>(typeof (T).Name).Save(value, SafeMode.True);
        }

        public static UserProfile CreateUserProfile(MembershipUser user)
        {
            var up = new UserProfile();
            if (user != null)
            {
                up.UserName = user.UserName;
                up.ProviderUserKey = user.ProviderUserKey;
                up.Email = user.Email;
                up.IsApproved = user.IsApproved;
            }
            return up;
        }

        public static bool IsUserValid(string email, string password)
        {
            return Membership.ValidateUser(email, password);
        }

        public static MembershipUser Register(string email, string password)
        {
            return Membership.CreateUser(email, password, email);
        }
    }
}
