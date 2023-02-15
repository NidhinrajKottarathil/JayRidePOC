using Contracts.BusinessLogic;
using JayRidePOC.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.Candidate;
using Model.Listing;
using NSubstitute;

namespace UnitTests
{
    public class ListingControllerTests
    {
        private readonly ListingController _listingController;
        private readonly IListingLogic _listingLogic;

        public ListingControllerTests()
        {
            _listingLogic = Substitute.For<IListingLogic>();
            _listingController = new ListingController(_listingLogic);
        }

        [Theory]
        [InlineData(2)]
        public async Task ListingPassengers_ShouldReturnPassengers(int numberOfPassengers)
        {
            // Arrange
            _listingLogic.GetListingByNumerOfPassengers(numberOfPassengers).Returns(new List<Listing>
            {
                new Listing{
                    name = "Listing 1",
                    pricePerPassenger = 13.97,
                    vehicleType = new VehicleType
                    {
                        name = "Sedan",
                        maxPassengers = 3
                    }
                },
                new Listing
                    {
                    name = "Listing 2",
                    pricePerPassenger = 21.78,
                    vehicleType = new VehicleType
                    {
                        name = "SUV",
                        maxPassengers = 5
                    }
                }
            });

            // Act
            var actionResult = await _listingController.GetPassengers(numberOfPassengers);
            var okResult = (OkObjectResult)actionResult.Result;
            var response = okResult.Value as List<Listing>;

            Assert.NotNull(response);
        }
    }
}
