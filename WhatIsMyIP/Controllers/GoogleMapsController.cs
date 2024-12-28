using Microsoft.AspNetCore.Mvc;
using WhatIsMyIP.Services;

namespace WhatIsMyIP.Controllers
{
    [ApiController]
    [Route("api/google-maps")]
    public class GoogleMapsController : ControllerBase
    {
        private readonly GoogleApiService _googleApiService;

        public GoogleMapsController(GoogleApiService googleApiService)
        {
            _googleApiService = googleApiService;
        }

        [HttpGet("load-script")]
        public IActionResult LoadScript()
        {
            var apiKey = _googleApiService.GetMapsApiKey();

            if (string.IsNullOrEmpty(apiKey))
            {
                return BadRequest("Google Maps API key is missing.");
            }

            return Content(
                $"https://maps.googleapis.com/maps/api/js?key={apiKey}&callback=initMap",
                "text/javascript"
            );
        }


    }
}
