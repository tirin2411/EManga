using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Catalog.Khuyenmais;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.Khuyenmai;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IKhuyenmaiiService _khuyenmaiService;

        public DiscountsController(IKhuyenmaiiService khuyenmaiService)
        {
            _khuyenmaiService = khuyenmaiService;
        }
        // GET: api/<DiscountsController>
        [HttpGet("paging")]
        public async Task<IActionResult> GetAll([FromQuery] GetDiscountPagingRequest request)
        {
            var discounts = await _khuyenmaiService.GetAll(request);
            return Ok(discounts);
        }

        [HttpGet("getdiscount")]
        public async Task<IActionResult> Get()
        {
            var discounts = await _khuyenmaiService.GetList();
            return Ok(discounts);
        }

        // GET api/<DiscountsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var mangas = await _khuyenmaiService.GetById(id);
            return Ok(mangas);
        }

        // POST api/<DiscountsController>
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] KhuyenmaiCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var discountId = await _khuyenmaiService.Create(request);
            if (discountId == 0)
            {
                return BadRequest();
            }

            var discount = await _khuyenmaiService.GetById(discountId);

            return CreatedAtAction(nameof(GetId), new { id = discountId }, discount);
        }

        // PUT api/<DiscountsController>/5
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(int id, [FromForm] KhuyenmaiUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Result = await _khuyenmaiService.Update(id, request);
            if (Result == 0)
            {
                return BadRequest(Result);
            }

            return Ok();
        }

        // DELETE api/<DiscountsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Result = await _khuyenmaiService.Detele(id);
            return Ok(Result);
        }
    }
}
