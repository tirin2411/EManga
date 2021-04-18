using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Catalog.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.Cart;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var cart = await _cartService.GetAll();
            //return Ok(cart);
            return Ok();
        }

        [HttpGet("{userId}/{cartid}")]
        public async Task<IActionResult> GetById(int cartid)
        {
            //var cart = await _cartService.GetById(cartid);
            //if (cart == null)
            //    return BadRequest("Cannot find cart");
            //return Ok(cart);
            return Ok();

        }

        [HttpGet("{userid}")]
        public async Task<IActionResult> GetByUserId(Guid userid)
        {
            //var cart = await _cartService.GetByUserId(userid);
            //if (cart == null)
            //    return BadRequest("Cannot find !");
            //return Ok(cart);
            return Ok();

        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid iduser, int mamanga, [FromForm]AddItem request)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //var cartid = await _cartService.Add(iduser, mamanga, request);
            //if (cartid == 0)
            //    return BadRequest();

            //var cart = await _cartService.GetById(cartid);

            //return CreatedAtAction(nameof(GetById), new { id = cartid }, cart);
            return Ok();

        }

        [HttpDelete("{iduser}/cart/{cartid}")]
        public async Task<IActionResult> RemoveImage(Guid iduser, int cartid)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //var result = await _cartService.Remove(iduser, cartid);
            //if (result == 0)
            //    return BadRequest();

            return Ok();
        }
    }
}