using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.System.Users.Address;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.System.Users.Address;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var address = await _addressService.GetAll();
            return Ok(address);
        }

        [HttpGet("{userId}/{addressId}")]
        public async Task<IActionResult> GetById(int addressId)
        {
            var address = await _addressService.GetById(addressId);
            if (address == null)
                return BadRequest("Cannot find address");
            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid iduser, [FromForm]AddressCreate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userid = await _addressService.Add(iduser, request);
            if (userid == 0)
                return BadRequest();

            var address = await _addressService.GetById(userid);

            return CreatedAtAction(nameof(GetById), new { id = userid }, address);
        }

        [HttpDelete("{userId}/address/{addressId}")]
        public async Task<IActionResult> RemoveImage(int addressId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _addressService.Detele(addressId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }
    }
}