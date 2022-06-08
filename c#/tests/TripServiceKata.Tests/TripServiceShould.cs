using System;
using TripServiceKata.Exception;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {
        [Fact(DisplayName ="Should Return UserNotLoggedInException When Not Logged User")]
        public void return_null_when_send_null() {
            // Arrange
            var tripService = new TripService();

            // Act
            void Result() => tripService.GetTripsByUser(null);

            // Assert
            Assert.Throws<UserNotLoggedInException>((Action) Result);
        }
    }
}
