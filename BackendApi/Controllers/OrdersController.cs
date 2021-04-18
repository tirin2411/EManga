using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Catalog.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.Order;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getorder")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery]GetOrderPagingRequest request)
        {
            var orders = await _orderService.GetList(request);
            return Ok(orders);
        }

        [HttpGet("{orderid}")]
        public async Task<IActionResult> GetById(int orderid)
        {
            var order = await _orderService.GetById(orderid);
            if (order == null)
                return BadRequest("Cannot find order");
            return Ok(order);
        }

        [HttpGet("getlistmn/{orderid}")]
        public async Task<IActionResult> GetListById(int orderid)
        {
            var order = await _orderService.GetListMnById(orderid);
            if (order == null)
                return BadRequest("Cannot find order");
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid iduser, [FromForm]OrderCreate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _orderService.Create(iduser, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("{orderid}")]
        public async Task<IActionResult> Update(int orderid, [FromBody]OrderUpdate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Result = await _orderService.Update(orderid, request);
            if (!Result.IsSuccessed)
            {
                return BadRequest(Result);
            }

            return Ok(Result);
        }
    }
}