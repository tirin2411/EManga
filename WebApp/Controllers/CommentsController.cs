using Application.Cmt;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Cmt;

namespace WebApp.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;


        public CommentsController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Get(int mangaId)
        {
            var wishlists = await _commentService.GetCmtByIdManga(mangaId);
            ViewBag.Thongbao = "Chưa có binh luan nào..!";
            return View(wishlists);
        }
        public async Task<IActionResult> AddItems(int mangaId, [FromForm] CommentForm request)
        {
            var user = await _userManager.GetUserAsync(User);
            var wishlists = await _commentService.Create(user.Id, mangaId, request);
            return RedirectToAction("Index");
        }
    }
}
