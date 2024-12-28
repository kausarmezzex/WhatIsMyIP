namespace WhatIsMyIP.Services
{
    public class GoogleApiService
    {
        private readonly string _mapsApiKey;

        public GoogleApiService(IConfiguration configuration)
        {
            _mapsApiKey = configuration["GoogleAPI:MapsApiKey"];
        }

        public string GetMapsApiKey()
        {
            return _mapsApiKey;
        }
    }
}
