using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WhatIsMyIP.Services
{
    public class GoogleMapsService
    {
        private readonly string _mapsApiKey;
        private readonly HttpClient _httpClient;

        public GoogleMapsService(IConfiguration configuration, HttpClient httpClient)
        {
            _mapsApiKey = configuration["GoogleAPI:MapsApiKey"];
            _httpClient = httpClient;
        }

        public async Task<string> GetAddressFromCoordinates(double latitude, double longitude)
        {
            var requestUri = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}&key={_mapsApiKey}";
            var response = await _httpClient.GetAsync(requestUri);

            if (!response.IsSuccessStatusCode)
                return "Unable to fetch address.";

            var content = await response.Content.ReadAsStringAsync();

            try
            {
                using var jsonDoc = JsonDocument.Parse(content);
                var results = jsonDoc.RootElement.GetProperty("results");

                if (results.GetArrayLength() > 0)
                {
                    var formattedAddress = results[0].GetProperty("formatted_address").GetString();
                    return formattedAddress ?? "Address not found.";
                }
                return "No address found for the given coordinates.";
            }
            catch (Exception ex)
            {
                // Log the exception for debugging (if logging is set up)
                return $"Error parsing the address: {ex.Message}";
            }
        }

    }
}
