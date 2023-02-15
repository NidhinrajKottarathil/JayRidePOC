using Contracts.BusinessLogic;
using FluentAssertions;
using JayRidePOC.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.Listing;
using Model.Location;
using NSubstitute;

namespace UnitTests
{
    public class LocationControllerTests
    {
        private readonly LocationController _locationController;
        private readonly ILocationLogic _locationLogic;

        public LocationControllerTests()
        {
            _locationLogic = Substitute.For<ILocationLogic>();
            _locationController = new LocationController(_locationLogic);
        }

        [Fact]
        public async void LocationInfoAsync_ShouldReturnLocation()
        {
            var ipAddress = "134.201.250.155";

            // Arrange
            _locationLogic.GetByIPAddress(Arg.Any<string>()).Returns(new LocationRoot
            {
                Latitude = 34.0453,
                Longitude = -118.2413
            });

            // Act
            var actionResult = await _locationController.LocationInfoAsync(ipAddress);
            var okResult = actionResult as OkObjectResult;
            var response = okResult.Value;

            Assert.NotNull(response);
            response.Should().BeEquivalentTo(new
            {
                Latitude = 34.0453,
                Longitude = -118.2413
            });
        }
    }
}
