using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using ViewModels.Catalog.Menus;

namespace AdminApp.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuApiClient _menuApiClient;
        private readonly IConfiguration _configuration;

        public MenuController(IMenuApiClient menuApiClient, IConfiguration configuration)
        {
            _menuApiClient = menuApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(int? menuId=1)
        {
            var menuitem = await _menuApiClient.GetAllItem(menuId);
            var menu = await _menuApiClient.GetAll();
            ViewBag.Menus = menu.Select(x => new SelectListItem()
            {
                Text = x.TenMenu,
                Value = x.Id.ToString(),
                Selected = menuId.HasValue && menuId.Value == x.Id
            });
            return View(menuitem);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuCreate request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _menuApiClient.Create(request);
            if (result.IsSuccessed)
                return RedirectToAction("Index");

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id,int menuId)
        {
            var result = await _menuApiClient.GetItemById(id,menuId);
            if (result.IsSuccessed)
            {
                var menu = result.ResultObj;
                var updateRequest = new MenuUpdate()
                {
                    Id = id,
                    Name = menu.Name,
                    ThuTu = menu.ThuTu,
                    Meta = menu.Meta
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Update(MenuUpdate request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _menuApiClient.Update(request.Id, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật menu thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int id,int menuId)
        {
            return View(new MenuDelete()
            {
                Id = id,
                menuId = menuId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MenuDelete request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _menuApiClient.Detele(request.Id);
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