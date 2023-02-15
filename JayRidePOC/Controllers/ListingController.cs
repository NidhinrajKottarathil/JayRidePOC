using Contracts.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Listing;

namespace JayRidePOC.Controllers
{
    [Route("api")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly IListingLogic listingLogic;

        public ListingController(IListingLogic _listingLogic)
        {
            this.listingLogic = _listingLogic;
        }

        /// <summary>
        /// Get list of passengers by maximum passengers
        /// </summary>
        /// <param name="numberOfPassengers"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("Listings")]
        public async Task<ActionResult<List<Listing>>> GetPassengers(int numberOfPassengers)
        {
            List<Listing> passengerList = new();
            try
            {
                passengerList = await this.listingLogic.GetListingByNumerOfPassengers(numberOfPassengers);                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok(passengerList);
        }
    }
}
