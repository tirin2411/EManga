using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSer;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.Tintuc;

namespace WebApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly ITintucApiClient _tintucService;

        public NewsController(ITintucApiClient tintucService)
        {
            _tintucService = tintucService;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 4)
        {
            var request = new GetNewsPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _tintucService.GetAll(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> GetMangaId(int id)
        {
            var news = await _tintucService.GetById(id);
            return View(news);
        }
    }
}