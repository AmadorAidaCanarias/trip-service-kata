using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public class TripService
    {
        private readonly IUserLoginInformation userLoginInformation;

        public TripService(IUserLoginInformation userLoginInformation)
        {
            this.userLoginInformation = userLoginInformation;
        }

        public List<Trip> GetTripsByUser(IUser user)
        {
            List<Trip> tripList = new List<Trip>();
            IUser loggedUser = userLoginInformation.GetLoggedUser();
            if (loggedUser != null)
            {
                if (user.IsFriend(loggedUser))
                {
                    tripList = TripDAO.FindTripsByUser(user);
                }

                return tripList;
            }

            throw new UserNotLoggedInException();
        }
    }
}