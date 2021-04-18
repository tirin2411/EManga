using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Catalog.Banners;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.Banner;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService banneriService)
        {
            _bannerService = banneriService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var banner = await _bannerService.GetAll();
            return Ok(banner);
        }

        [HttpGet("{idBanner}")]
        public async Task<IActionResult> GetById(int idBanner)
        {
            var image = await _bannerService.GetById(idBanner);
            if (image == null)
                return BadRequest("Cannot find Banner");
            return Ok(image);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]BannerCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _bannerService.Add(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut("{bannerId}")]
        public async Task<IActionResult> Update(int bannerId, [FromBody] BannerUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Result = await _bannerService.Update(bannerId, request);
            if (Result == 0)
            {
                return BadRequest(Result);
            }

            return Ok();
        }
        [HttpDelete("{idBanner}")]
        public async Task<IActionResult> Remove(int idBanner)
        {
            var Result = await _bannerService.Remove(idBanner);
            return Ok(Result);
        }
    }
}