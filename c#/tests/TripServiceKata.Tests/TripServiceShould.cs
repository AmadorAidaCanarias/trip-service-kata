using NSubstitute;
using System;
using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using Xunit;

namespace TripServiceKata.Tests {
    public class TripServiceShould
    {
        [Fact(DisplayName ="Should Return UserNotLoggedInException When Not Logged User")]
        public void return_null_when_send_null() {
            // Arrange
            var userLoginInformation = Substitute.For<IUserLoginInformation>();
            userLoginInformation.GetLoggedUser().Returns((User) null);
            var tripService = new TripService(userLoginInformation);
            
            // Act
            void Result() => tripService.GetTripsByUser(null);

            // Assert
            Assert.Throws<UserNotLoggedInException>((Action) Result);
        }

        [Fact(DisplayName = "Should Return Empty Trip List When not Is Friend")]
        public void return_empty_list_trip_when_not_is_friend()
        {
            var userLoginInformation = Substitute.For<IUserLoginInformation>();
            var tripService = new TripService(userLoginInformation);
            var user = new User();
            var userTrips = tripService.GetTripsByUser(user);

            Assert.Equal(userTrips, new List<Trip>());
        }
    }
}
