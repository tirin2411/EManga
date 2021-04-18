using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ViewModels.Catalog.Khuyenmai;

namespace AdminApp.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IKhuyenmaiApiClient _khuyenmaiApiClient;
        private readonly IConfiguration _configuration;

        public DiscountController(IKhuyenmaiApiClient khuyenmaiApiClient, IConfiguration configuration)
        {
            _khuyenmaiApiClient = khuyenmaiApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 15)
        
        {
            var request = new GetDiscountPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _khuyenmaiApiClient.GetAll(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _khuyenmaiApiClient.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] KhuyenmaiCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _khuyenmaiApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới khuyến mãi thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm mới khuyến mãi thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var discount = await _khuyenmaiApiClient.GetById(id);
            var discountupdateRequest = new KhuyenmaiUpdateRequest()
            {
                Id = id,
                Name = discount.Name,
                ToDate = discount.ToDate,
                ApplyForAll = discount.ApplyForAll,
                DiscountAmount = discount.DiscountAmount,
                DiscountPercent = discount.DiscountPercent,
                Status = discount.Status,
                //MaximumDiscountedQuantity = discount.MaximumDiscountedQuantity
            };
            return View(discountupdateRequest);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] KhuyenmaiUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _khuyenmaiApiClient.Update(request.Id, request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cập nhật thất bại");
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new KhuyenmaiDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(KhuyenmaiDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _khuyenmaiApiClient.Detele(request.Id);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

    }
}
