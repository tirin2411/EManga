using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Catalog.Tintuc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.Tintuc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ITintucServer _newsService;

        public NewsController(ITintucServer newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] GetNewsPagingRequest request)
        {
            var news = await _newsService.GetAll(request);
            return Ok(news);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tintuc = await _newsService.GetById(id);
            if (tintuc == null)
                return BadRequest("Cannot find News");
            return Ok(tintuc);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] TintucCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newsid = await _newsService.Create(request);
            if (newsid == 0)
            {
                return BadRequest();
            }
            var news = await _newsService.GetById(newsid);

            return CreatedAtAction(nameof(GetById), new { id = newsid }, news);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(int id, [FromForm] TintucUpdate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Result = await _newsService.Update(id, request);
            if (Result == 0)
            {
                return BadRequest(Result);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var Result = await _newsService.Detele(id);
            return Ok(Result);
        }
    }
}