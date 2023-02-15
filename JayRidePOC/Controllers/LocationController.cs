using Contracts.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JayRidePOC.Controllers
{
    [Route("api")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationLogic locationLogic;
        public LocationController(ILocationLogic _locationLogic)
        {
            locationLogic = _locationLogic;
        }

        /// <summary>
        /// Get city location by IP Address
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("Location")]
        public async Task<IActionResult> LocationInfoAsync(string ipAddress)
        {
            var result = await locationLogic.GetByIPAddress(ipAddress);

            return Ok(new
            {
                result.Latitude,
                result.Longitude
            });
        }
    }
}
