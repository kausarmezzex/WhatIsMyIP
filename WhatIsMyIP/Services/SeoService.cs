namespace WhatIsMyIP.Services
{
    public class SeoService
    {
        private readonly IConfiguration _configuration;

        public SeoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetMetaTitle() => _configuration["SEO:MetaTitle"];
        public string GetMetaDescription() => _configuration["SEO:MetaDescription"];
        public string GetMetaKeywords() => _configuration["SEO:MetaKeywords"];
    }
}
