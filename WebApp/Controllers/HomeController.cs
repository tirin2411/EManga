using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;
using ApiSer;
using Microsoft.AspNetCore.Http;
using Application.Catalog.Categorys;
using Application.Catalog.Mangas;
using Application.Catalog.Banners;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITheloaiService _theloaiApiClient;
        private readonly IMangaService _mangaApiClient;
        private readonly IUserApiClient _userApiClient;
        private readonly IBannerService _bannerService;

        public HomeController(ILogger<HomeController> logger,
            ITheloaiService theloaiService,
            IMangaService mangaService,
            IBannerService bannerService,
            IUserApiClient userService)
        {
            _logger = logger;
            _theloaiApiClient = theloaiService;
            _mangaApiClient = mangaService;
            _bannerService = bannerService;
            _userApiClient = userService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.theloai = await _theloaiApiClient.GetList();
            ViewBag.ngonngu = await _theloaiApiClient.GetListNgonngu();
            ViewBag.manga = await _mangaApiClient.GetAll();
            ViewBag.mangadiscount = await _mangaApiClient.GetMangaDiscount();
            ViewBag.banner = await _bannerService.GetAll();
            ViewBag.Name = HttpContext.Session.GetString("Token");
            ViewBag.User = User.Claims.FirstOrDefault(x => x.Type == "displayName")?.Value ?? HttpContext.Session.GetString("displayName");
            return View();
        }
        public async Task<IActionResult> GetMangaDiscount()
        {
            var mangas = await _mangaApiClient.GetMangaDiscount();
            return PartialView(mangas);
        }
        //public async Task<IActionResult> Search(int? CategoryId)
        //{
        //    var category = await _theloaiApiClient.GetList();
        //    ViewBag.Categories = category.Select(x => new SelectListItem()
        //    {
        //        Text = x.TenTL,
        //        Value = x.Id.ToString(),
        //        Selected = CategoryId.HasValue && CategoryId.Value == x.Id
        //    });
        //    return PartialView(category);
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }
        public IActionResult NotFound()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}