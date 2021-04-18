using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.WishLists;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListsController : ControllerBase
    {
        private readonly IWishListService _wishlistService;

        public WishListsController(IWishListService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpGet("getlistmn/{userId}")]
        public async Task<IActionResult> GetListById(Guid userId)
        {
            var wishlist = await _wishlistService.GetWishListByIdUser(userId);
            if (wishlist == null)
                return BadRequest("Cannot find wishlist");
            return Ok(wishlist);
        }
    }
}
