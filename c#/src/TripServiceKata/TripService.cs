using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public class TripService
    {
        private readonly IUserLoginInformation userLoginInformation;
        private readonly IUserTrips userTrips;

        public TripService(IUserLoginInformation userLoginInformation, IUserTrips userTrips)
        {
            this.userLoginInformation = userLoginInformation;
            this.userTrips = userTrips;
        }

        public List<Trip> GetTripsByUser(IUser user)
        {
            List<Trip> tripList = new List<Trip>();
            IUser loggedUser = userLoginInformation.GetLoggedUser();
            if (loggedUser != null)
            {
                if (user.IsFriend(loggedUser))
                {
                    tripList = userTrips.TripsFromUser(user);
                }

                return tripList;
            }

            throw new UserNotLoggedInException();
        }
    }
}