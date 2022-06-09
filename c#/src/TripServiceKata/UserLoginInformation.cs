using TripServiceKata.Entity;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public class UserLoginInformation : IUserLoginInformation
    {
        public User GetLoggedUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }
    }
}