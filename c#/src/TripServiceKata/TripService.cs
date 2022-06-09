﻿using System.Collections.Generic;
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

        public List<Trip> GetTripsByUser(User user)
        {
            List<Trip> tripList = new List<Trip>();
            User loggedUser = userLoginInformation.GetLoggedUser();
            bool isFriend = false;
            if (loggedUser != null)
            {
                foreach (User friend in user.GetFriends())
                {
                    if (friend.Equals(loggedUser))
                    {
                        isFriend = true;
                        break;
                    }
                }

                if (isFriend)
                {
                    tripList = TripDAO.FindTripsByUser(user);
                }

                return tripList;
            }

            throw new UserNotLoggedInException();
        }
    }
}