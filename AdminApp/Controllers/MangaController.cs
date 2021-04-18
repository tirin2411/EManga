using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiSer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ViewModels.Catalog.Mangas;
using ViewModels.Common;

namespace AdminApp.Controllers
{
    public class MangaController : Controller
    {
        private readonly IMangaApiClient _mangaApiClient;
        private readonly ITheloaiApiClient _theloaiApiClient;
        private readonly IKhuyenmaiApiClient _khuyenmaiApiClient;

        private readonly IConfiguration _configuration;

        public MangaController(IMangaApiClient mangaApiClient, IConfiguration configuration, ITheloaiApiClient theloaiApiClient,
            IKhuyenmaiApiClient khuyenmaiApiClient)
        {
            _mangaApiClient = mangaApiClient;
            _configuration = configuration;
            _theloaiApiClient = theloaiApiClient;
            _khuyenmaiApiClient = khuyenmaiApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 15)
        {
            var request = new GetManageMangaPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _mangaApiClient.GetAllPaging(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }

        public async Task<IActionResult> MangaDiscount(string keyword, int pageIndex = 1, int pageSize = 15)
        {
            var request = new GetManageMangaPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _mangaApiClient.GetMangaDiscountPaging(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]MangaCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mangaApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int mangaId)
        {
            var manga = await _mangaApiClient.GetById(mangaId);
            var mangaupdateRequest = new MangaUpdateRequest()
            {
                Id = mangaId,
                Ten = manga.Ten,
                Gia = manga.Gia,
                SoLuong = manga.SoLuong,
                Mota = manga.Mota,
                Tacgia = manga.Tacgia,
                NamXB = manga.NamXB,
                Sotrang = manga.Sotrang,
                Anhien = manga.Anhien
            };
            return View(mangaupdateRequest);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] MangaUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mangaApiClient.Update(request.Id, request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cập nhật thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int mangaId)
        {
            var result = await _mangaApiClient.GetById(mangaId);
            return View(result);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new MangaDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MangaDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mangaApiClient.Detele(request.Id);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryAssign(int id)
        {
            var roleAssignRequest = await GetCategoryAssignRequest(id);
            return View(roleAssignRequest);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAssign(CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mangaApiClient.CategoryAssign(request.Id, request);

            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật danh mục thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            var roleAssignRequest = await GetCategoryAssignRequest(request.Id);

            return View(roleAssignRequest);
        }
        private async Task<CategoryAssignRequest> GetCategoryAssignRequest(int id)
        {
            var mangaObj = await _mangaApiClient.GetById(id);
            var categories = await _theloaiApiClient.GetAll();
            var categoryAssignRequest = new CategoryAssignRequest();
            foreach (var role in categories)
            {
                categoryAssignRequest.Categories.Add(new SelectItem()
                {
                    Id = role.Id.ToString(),
                    Name = role.TenTL,
                    Selected = mangaObj.Categories.Contains(role.TenTL)
                });
            }
            return categoryAssignRequest;
        }
        private async Task<DiscountMnRequest> GetDiscountMnRequest(int id)
        {
            var mangaObj = await _mangaApiClient.GetById(id);
            var categories = await _khuyenmaiApiClient.GetAllDiscount();
            var categoryAssignRequest = new DiscountMnRequest();
            foreach (var role in categories)
            {
                categoryAssignRequest.Discounts.Add(new SelectItem()
                {
                    Id = role.Id.ToString(),
                    Name = role.Name,
                    Selected = mangaObj.Discounts.Contains(role.Name)
                });
            }
            return categoryAssignRequest;
        }
        [HttpGet]
        public async Task<IActionResult> DiscountAssign(int id)
        {
            var roleAssignRequest = await GetDiscountMnRequest(id);
            return View(roleAssignRequest);
        }

        [HttpPost]
        public async Task<IActionResult> DiscountAssign(DiscountMnRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mangaApiClient.DiscountManga(request.Id, request);

            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật ưu đãi thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            var roleAssignRequest = await GetDiscountMnRequest(request.Id);

            return View(roleAssignRequest);
        }
    }
}