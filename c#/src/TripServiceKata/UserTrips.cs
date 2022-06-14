using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public class UserTrips : IUserTrips
    {
        public UserTrips()
        {
        }

        public List<Trip> TripsFromUser(IUser user)
        {
            return TripDAO.FindTripsByUser(user);
        }
    }
}