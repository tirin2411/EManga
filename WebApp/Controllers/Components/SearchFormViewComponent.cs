using Application.Catalog.Categorys;
using Application.Catalog.Mangas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Catalog.Mangas;
using ViewModels.Common;

namespace WebApp.Controllers.Components
{
    public class SearchFormViewComponent : ViewComponent
    {
        private readonly ITheloaiService _theloaiService;
        private readonly IMangaService _mangaService;
        public SearchFormViewComponent(ITheloaiService theloaiService, IMangaService mangaService)
        {
            _theloaiService = theloaiService;
            _mangaService = mangaService;

        }
        public async Task<IViewComponentResult> InvokeAsync(string keyword, int? CategoryId, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetManageMangaPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _mangaService.GetAllPaging(request);
            ViewBag.Keyword = keyword;
            var category = await _theloaiService.GetList();
            ViewBag.Categories = category.Select(x => new SelectListItem()
            {
                Text = x.TenTL,
                Value = x.Id.ToString(),
                Selected = CategoryId.HasValue && CategoryId.Value == x.Id
            });

            return View("Default", data.ResultObj);
        }
    }
}