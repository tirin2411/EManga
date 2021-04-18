using Application.System.Locals;
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
    public class LocalsController : ControllerBase
    {
        private readonly ILocalService _localService;

        public LocalsController(ILocalService localService)
        {
            _localService = localService;
        }
        [HttpGet("getprovince")]
        public async Task<IActionResult> Get()
        {
            var local = await _localService.GetProvince();
            return Ok(local);
        }
        [HttpGet("getprovinceid/{provinceId}")]
        public async Task<IActionResult> GetProvinceId(int provinceId)
        {
            var local = await _localService.GetProvinceId(provinceId);
            if (local == null)
                return BadRequest("Cannot find district");
            return Ok(local);
        }
        [HttpGet("getdistrict/{provinceId}")]
        public async Task<IActionResult> GetDt(int provinceId)
        {
            var local = await _localService.GetDistrict(provinceId);
            if (local == null)
                return BadRequest("Cannot find district");
            return Ok(local);
        }
        [HttpGet("getdistrictid/{districtId}")]
        public async Task<IActionResult> GetDistrictId(int districtId)
        {
            var local = await _localService.GetDistrictId(districtId);
            if (local == null)
                return BadRequest("Cannot find district");
            return Ok(local);
        }
        [HttpGet("getward/{districtId}")]
        public async Task<IActionResult> GetW(int districtId)
        {
            var local = await _localService.GetWard(districtId);
            if (local == null)
                return BadRequest("Cannot find ward");
            return Ok(local);
        }
        [HttpGet("getwardid/{wardId}")]
        public async Task<IActionResult> GetWardId(int wardId)
        {
            var local = await _localService.GetWardId(wardId);
            if (local == null)
                return BadRequest("Cannot find ward");
            return Ok(local);
        }
    }
}
