using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhatIsMyIP.Services;

namespace WhatIsMyIP.Controllers
{
    [ApiController]
    [Route("api/location")]
    public class LocationController : ControllerBase
    {
        private readonly GoogleMapsService _googleMapsService;

        public LocationController(GoogleMapsService googleMapsService)
        {
            _googleMapsService = googleMapsService;
        }

        [HttpPost("get-address")]
        public async Task<IActionResult> GetAddress([FromBody] CoordinatesModel coordinates)
        {
            if (coordinates == null)
                return BadRequest("Coordinates are required.");

            var address = await _googleMapsService.GetAddressFromCoordinates(coordinates.Latitude, coordinates.Longitude);
            return Ok(new { Address = address });
        }
    }

    public class CoordinatesModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
