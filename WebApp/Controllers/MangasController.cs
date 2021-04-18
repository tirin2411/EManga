using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSer;
using Application.Catalog.Categorys;
using Application.Catalog.Mangas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels.Catalog.Mangas;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MangasController : Controller
    {
        private readonly ITheloaiService _theloaiService;
        private readonly IMangaService _mangaService;
        private readonly IMangaApiClient _mangaApiClient;
        private readonly ITheloaiApiClient _theloaiApiClient;

        public MangasController(ITheloaiService theloaiService, IMangaService mangaService,
                                ITheloaiApiClient theloaiApiClient, IMangaApiClient mangaApiClient)
        {
            _theloaiService = theloaiService;
            _mangaService = mangaService;
            _theloaiApiClient = theloaiApiClient;
            _mangaApiClient = mangaApiClient;
        }

        public async Task<IActionResult> Index(string keyword,int? CategoryId, int pageIndex = 1, int pageSize = 4)
        {
            var request = new GetManageMangaPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _mangaService.GetAllPaging(request);
            ViewBag.Keyword = keyword;
            ViewBag.theloai = await _theloaiService.GetList();
            var category = await _theloaiService.GetList();
            ViewBag.Categories = category.Select(x => new SelectListItem()
            {
                Text = x.TenTL,
                Value = x.Id.ToString(),
                Selected = CategoryId.HasValue && CategoryId.Value == x.Id
            });
            ViewBag.ngonngu = await _theloaiService.GetListNgonngu();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }
        public async Task<JsonResult> ListName(String q)
        {
            var data = await _mangaService.ListName(q);
            return Json(new
            {
                data = data,
                status = true
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ViewBag.theloai = await _theloaiService.GetList();
            ViewBag.ngonngu = await _theloaiService.GetListNgonngu();
            var mangas = await _mangaService.GetAll();
            return View(mangas);
        }

        [HttpGet]
        public async Task<IActionResult> GetMangaId(string meta,int mangaId)
        {
            ViewBag.theloai = await _theloaiService.GetList();
            ViewBag.ngonngu = await _theloaiService.GetListNgonngu();
            var mangas = await _mangaService.GetByIdWeb(meta,mangaId);

            return View(mangas);
        }

        [HttpGet]
        public async Task<IActionResult> GetbycategoryId(string meta,int theloaiId, int page = 1, int pageSize = 30)
        {
            var mangas = await _mangaService.GetAllByCategoryId(meta,new GetPublicMangaPagingRequest()
            {
                TheloaiId = theloaiId,
                PageIndex = page,
                PageSize = pageSize
            });
            ViewBag.theloai = await _theloaiService.GetList();
            ViewBag.ngonngu = await _theloaiService.GetListNgonngu();
            return View(new MangaCategoryVM()
            {
                Theloai = await _theloaiService.GetById(theloaiId),
                Mangas = mangas
            }); ;
        }
        public async Task<IActionResult> GetMangaDiscount()
        {
            var mangas = await _mangaService.GetMangaDiscount();
            return PartialView(mangas);
        }
        public IActionResult Manga()
        {
            return View();
        }

        public IActionResult MangaDetail()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }
    }
}