using Application.Cmt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _cmtService;

        public CommentsController(ICommentService cmtService)
        {
            _cmtService = cmtService;
        }
        [HttpGet("getlistcmt/{mangaId}")]
        public async Task<IActionResult> GetListById(int mangaId)
        {
            var wishlist = await _cmtService.GetCmtByIdManga(mangaId);
            if (wishlist == null)
                return BadRequest("Cannot find comment");
            return Ok(wishlist);
        }
    }
}
