using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ViewModels.Catalog.Theloai;

namespace AdminApp.Controllers
{
    public class TheloaiController : Controller
    {
        private readonly ITheloaiApiClient _theloaiApiClient;
        private readonly IConfiguration _configuration;

        public TheloaiController(ITheloaiApiClient theloaiApiClient, IConfiguration configuration)
        {
            _theloaiApiClient = theloaiApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _theloaiApiClient.GetAllAd();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TheloaiCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _theloaiApiClient.Create(request);
            if (result.IsSuccessed)
                return RedirectToAction("Index");

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int idTL)
        {
            var result = await _theloaiApiClient.GetById(idTL);
            if (result != null)
            {
                var theloai = result;
                var updateRequest = new TheloaiUpdateRequest()
                {
                    Id = idTL,
                    TenTL = theloai.TenTL,
                    Meta = theloai.Meta,
                    Thutu = theloai.Thutu,
                    Anhien = theloai.Anhien
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> Update(TheloaiUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _theloaiApiClient.Update(request.Id, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật thể loại thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new TheloaiDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TheloaiDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _theloaiApiClient.Detele(request.Id);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa thể loại thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }
    }
}