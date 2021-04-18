using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ViewModels.Catalog.Tintuc;

namespace AdminApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly ITintucApiClient _tintucApiClient;
        private readonly IConfiguration _configuration;

        public NewsController(ITintucApiClient tintucApiClient, IConfiguration configuration)
        {
            _tintucApiClient = tintucApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 15)
        {
            var request = new GetNewsPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _tintucApiClient.GetAll(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _tintucApiClient.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]TintucCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _tintucApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Tạo mới không thành công");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var news = await _tintucApiClient.GetById(id);
            var updateRequest = new TintucUpdate()
            {
                Id = id,
                TieuDe = news.TieuDe,
                Meta = news.Meta,
                //NgayCapNhat = news.NgayCapNhat,
                NoiDungTomTat = news.NoiDungTomTat,
                NoiDung = news.NoiDung,
                //Hinh = news.Hinh,
                AnHien = news.AnHien
            };
            return View(updateRequest);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromForm] TintucUpdate request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _tintucApiClient.Update(request.Id, request);
            if (result)
            {
                TempData["result"] = "Cập nhật tin tuc thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật thất bại");
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new TintucDelete()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TintucDelete request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _tintucApiClient.Detele(request.Id);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa menu thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }
    }
}