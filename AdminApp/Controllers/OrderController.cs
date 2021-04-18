using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ViewModels.Catalog.Order;

namespace AdminApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApiClient _orderApiClient;
        private readonly IConfiguration _configuration;

        public OrderController(IOrderApiClient mangaApiClient, IConfiguration configuration)
        {
            _orderApiClient = mangaApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 30)
        {
            var request = new GetOrderPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _orderApiClient.GetList(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreate request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _orderApiClient.Create(request);
            if (result.IsSuccessed)
                return RedirectToAction("Index");

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int orderid)
        {
            var result = await _orderApiClient.GetListMnById(orderid);
            return View(result.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int orderid)
        {
            var result = await _orderApiClient.GetById(orderid);
            if (result.IsSuccessed)
            {
                var manga = result.ResultObj;
                var mangaupdateRequest = new OrderUpdate()
                {
                    Id = orderid,
                    Tinhtrang = manga.Tinhtrang
                };
                return View(mangaupdateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrderUpdate request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _orderApiClient.Update(request.Id, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }
    }
}