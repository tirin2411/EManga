using Application.Shipment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Shipment;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceAndDestinationsController : ControllerBase
    {
        private readonly ITableRateShippingService _tableRateShippingService;

        public PriceAndDestinationsController(ITableRateShippingService tableRateShippingService)
        {
            _tableRateShippingService = tableRateShippingService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shippings = await _tableRateShippingService.GetAll();
            return Ok(shippings);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shippings = await _tableRateShippingService.GetById(id);
            return Ok(shippings);
        }
        [HttpGet("getbyprovince/{provinceId}")]
        public async Task<IActionResult> GetByProvinceId(int provinceId)
        {
            var shippings = await _tableRateShippingService.GetByProvinceId(provinceId);
            return Ok(shippings);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShippingPriceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var shippingId = await _tableRateShippingService.Create(request);
            if (shippingId == 0)
            {
                return BadRequest();
            }
            var shipping = await _tableRateShippingService.GetById(shippingId);
            return CreatedAtAction(nameof(GetById), new { id = shippingId }, shipping);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ShippingPriceUpdate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Result = await _tableRateShippingService.Update(id, request);
            if (Result == 0)
            {
                return BadRequest(Result);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Result = await _tableRateShippingService.Detele(id);
            return Ok(Result);
        }
    }
}
