using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Catalog.Categorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.Theloai;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly ITheloaiService _theloaiService;

        public CategorysController(ITheloaiService theloaiService)
        {
            _theloaiService = theloaiService;
        }

        [HttpGet("getcategory")]
        public async Task<IActionResult> Get()
        {
            var theloai = await _theloaiService.GetList();
            return Ok(theloai);
        }
        [HttpGet("getcategoryad")]
        public async Task<IActionResult> Getlistad()
        {
            var theloai = await _theloaiService.GetListAd();
            return Ok(theloai);
        }

        [HttpGet("getlanguage")]
        public async Task<IActionResult> Getlanguage()
        {
            var theloai = await _theloaiService.GetListNgonngu();
            return Ok(theloai);
        }

        [HttpGet("{theloaiId}")]
        public async Task<IActionResult> GetById(int theloaiId)
        {
            var theloai = await _theloaiService.GetById(theloaiId);
            if (theloai == null)
                return BadRequest("Cannot find category");
            return Ok(theloai);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TheloaiCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _theloaiService.Create(request);
            if (!result.IsSuccessed)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut("{idTL}")]
        public async Task<IActionResult> Update(int idTL, [FromBody]TheloaiUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _theloaiService.Update(idTL, request);
            if (!affectedResult.IsSuccessed)
            {
                return BadRequest(affectedResult);
            }
            return Ok(affectedResult);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var Result = await _theloaiService.Detele(id);
            return Ok(Result);
        }
    }
}