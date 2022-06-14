using NSubstitute;
using System;
using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using Xunit;

namespace TripServiceKata.Tests {
    public class TripServiceShould {
        [Fact(DisplayName = "Should Return UserNotLoggedInException When Not Logged User")]
        public void return_null_when_send_null() {
            // Arrange
            var userLoginInformation = Substitute.For<IUserLoginInformation>();
            var userTrips = Substitute.For<IUserTrips>();
            userLoginInformation.GetLoggedUser().Returns((IUser)null);
            var tripService = new TripService(userLoginInformation, userTrips);

            // Act
            void Result() => tripService.GetTripsByUser(null);

            // Assert
            Assert.Throws<UserNotLoggedInException>((Action)Result);
        }

        [Fact(DisplayName = "Should Return Empty Trip List When not Is Friend")]
        public void return_empty_list_trip_when_not_is_friend() {
            var userLoginInformation = Substitute.For<IUserLoginInformation>();
            var loggedUser = new User();
            userLoginInformation.GetLoggedUser().Returns(loggedUser);
            var user = Substitute.For<IUser>();
            var userTrips = Substitute.For<IUserTrips>();
            user.IsFriend(loggedUser).Returns(false);
            var tripService = new TripService(userLoginInformation, userTrips);

            var trips = tripService.GetTripsByUser(user);

            Assert.Equal(trips, new List<Trip>());
        }

        [Fact(DisplayName = "Should return trip list with data when is friend")]
        public void return_trip_list_with_data_when_is_friend() {
            var userLoginInformation = Substitute.For<IUserLoginInformation>();
            var loggedUser = new User();
            userLoginInformation.GetLoggedUser().Returns(loggedUser);
            var user = Substitute.For<IUser>();
            user.IsFriend(loggedUser).Returns(true);
            var userTrips = Substitute.For<IUserTrips>();
            var desiredTrips = new List<Trip>() {new Trip()};
            userTrips.TripsFromUser(user).Returns(desiredTrips);
            var tripService = new TripService(userLoginInformation, userTrips);

            var trips = tripService.GetTripsByUser(user);

            Assert.Equal(trips, desiredTrips);
        }
    }
}
