using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSer;
using Application.WishLists;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class WishListsController : Controller
    {
        private readonly IWishListService _wishlistService;
        private readonly IWishListApiClient _wishlistApiClient;
        private readonly UserManager<AppUser> _userManager;


        public WishListsController(IWishListService wishlistService, IWishListApiClient wishlistApiClient, UserManager<AppUser> userManager)
        {
            _wishlistService = wishlistService;
            _wishlistApiClient = wishlistApiClient;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var wishlists = await _wishlistApiClient.GetListMnByIdUser(user.Id);
            ViewBag.ThongbaoWL = "Chưa có sản phẩm nào..!";
            return View(wishlists);
        }

        [Authorize]
        public async Task<IActionResult> AddItems(int mangaId)
        {
            var user = await _userManager.GetUserAsync(User);
            var wishlists = await _wishlistService.Create(user.Id,mangaId);
            return RedirectToAction("Index");
        }
       
        public async Task<IActionResult> DeleteItems(int mangaId)
        {
            var user = await _userManager.GetUserAsync(User);
            var wishlists = await _wishlistService.Delete(user.Id, mangaId);
            return RedirectToAction("Index");
        }
    }
}
