using NSubstitute;
using System;
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
    }
}
