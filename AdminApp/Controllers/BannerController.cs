using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ViewModels.Catalog.Banner;

namespace AdminApp.Controllers
{
    public class BannerController : Controller
    {
        private readonly IBannerApiClient _bannerApiClient;
        private readonly IConfiguration _configuration;

        public BannerController(IBannerApiClient bannerApiClient, IConfiguration configuration)
        {
            _bannerApiClient = bannerApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _bannerApiClient.GetAll();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int idBanner)
        {
            var result = await _bannerApiClient.GetById(idBanner);
            return View(result.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] BannerCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _bannerApiClient.Add(request);
            if (result)
            {
                TempData["result"] = "Thêm mới banner thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm mới không thành công");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int bannerId)
        {
            var result = await _bannerApiClient.GetById(bannerId);
            if (result.IsSuccessed)
            {
                var menu = result.ResultObj;
                var updateRequest = new BannerUpdateRequest()
                {
                    Id = bannerId,
                    Tieude = menu.Tieude,
                    Meta = menu.Meta,
                    Noidung = menu.Noidung,
                    ThuTu = menu.ThuTu,
                    Anhien = menu.Anhien
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Update(BannerUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _bannerApiClient.Update(request.Id, request);
            if (result)
            {
                TempData["result"] = "Cập nhật menu thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật không thành công");
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int idBanner)
        {
            return View(new BannerDelete()
            {
                Id = idBanner
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BannerDelete request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _bannerApiClient.Remove(request.Id);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa banner thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }
    }
}