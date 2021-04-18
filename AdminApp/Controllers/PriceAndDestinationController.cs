using ApiSer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Shipment;

namespace AdminApp.Controllers
{
    public class PriceAndDestinationController : Controller
    {
        private readonly IPriceAndDestinationApiClient _priceAndDestinationApiClient;
        private readonly IConfiguration _configuration;
        private readonly ILocalApiClient _localApiClient;

        public PriceAndDestinationController(IPriceAndDestinationApiClient priceAndDestinationApiClient, IConfiguration configuration,
            ILocalApiClient localApiClient)
        {
            _priceAndDestinationApiClient = priceAndDestinationApiClient;
            _configuration = configuration;
            _localApiClient = localApiClient;
        }
        public async Task<IActionResult> Index()
        {
            var shipping = await _priceAndDestinationApiClient.GetAll();
            return View(shipping);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int? provinceId)
        {
            var province = await _localApiClient.GetProvince();
            ViewBag.Provinces = province.Select(x => new SelectListItem()
            {
                Text = x.type + " " + x.Name,
                Value = x.Id.ToString(),
                Selected = provinceId.HasValue && provinceId.Value == x.Id
            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShippingPriceRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _priceAndDestinationApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm thất bại");
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var shipping = await _priceAndDestinationApiClient.GetById(id);
            var shippingupdateRequest = new ShippingPriceUpdate()
            {
                Id = id,
                Note = shipping.Note,
                ShippingPrice = shipping.ShippingPrice
            };
            return View(shippingupdateRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] ShippingPriceUpdate request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _priceAndDestinationApiClient.Update(request.Id, request);
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
            return View(new ShippingPriceDelete()
            {
                Id = id
            });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ShippingPriceDelete request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _priceAndDestinationApiClient.Detele(request.Id);
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
