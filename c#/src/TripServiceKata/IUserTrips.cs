using System.Collections.Generic;
using TripServiceKata.Entity;

namespace TripServiceKata
{
    public interface IUserTrips
    {
        List<Trip> TripsFromUser(IUser user);
    }
}