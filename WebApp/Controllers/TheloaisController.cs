using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiSer;
using Application.Catalog.Categorys;

namespace WebApp.Controllers
{
    public class TheloaisController : Controller
    {
        private readonly ITheloaiService _theloaiService;

        public TheloaisController(ITheloaiService theloaiService)
        {
            _theloaiService = theloaiService;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var theloai = await _theloaiService.GetList();
            
            return View(theloai);
        }
    }
}