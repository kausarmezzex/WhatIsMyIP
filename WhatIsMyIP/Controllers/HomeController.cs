using Microsoft.AspNetCore.Mvc;
using WhatIsMyIP.Services;

namespace WhatIsMyIP.Controllers
{
    public class HomeController : Controller
    {
        private readonly SeoService _seoService;

        public HomeController(SeoService seoService)
        {
            _seoService = seoService;
        }

        public IActionResult Index()
        {
            // Pass SEO metadata to the view
            ViewData["MetaTitle"] = _seoService.GetMetaTitle();
            ViewData["MetaDescription"] = _seoService.GetMetaDescription();
            ViewData["MetaKeywords"] = _seoService.GetMetaKeywords();

            return View();
        }
    }
}
