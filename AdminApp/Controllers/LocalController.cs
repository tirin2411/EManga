using ApiSer;
using Data.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    public class LocalController : Controller
    {
        //private readonly MnDbContext _context;
        private readonly ILocalApiClient _localApiClient;

        public LocalController(ILocalApiClient localApiClient)
        {
            //_context = context;
            _localApiClient = localApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> District_Bind(int? provinceId)
        {
            var data = await _localApiClient.GetDistrict(provinceId);
            return Ok(data);
        }

        public async Task<IActionResult> Ward_Bind(int? districtId)
        {
            var data = await _localApiClient.GetWard(districtId);
            return Ok(data);
        }
        public async Task<IActionResult> GetProvinceId(int? provinceId)
        {
            var data = await _localApiClient.GetProvinceId(provinceId);
            return Ok(data);
        }
        public async Task<IActionResult> GetDistrictId(int? districtId)
        {
            var data = await _localApiClient.GetDistrictId(districtId);
            return Ok(data);
        }
        public async Task<IActionResult> GetWardId(int? wardId)
        {
            var data = await _localApiClient.GetWardId(wardId);
            return Ok(data);
        }
    }
}
