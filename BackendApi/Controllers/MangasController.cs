using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Catalog.Mangas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.MangaImages;
using ViewModels.Catalog.Mangas;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangasController : ControllerBase
    {
        private readonly IMangaService _mangaService;

        public MangasController(IMangaService mangaService)
        {
            _mangaService = mangaService;
        }

        //http://localhost:port/Manga
        [HttpGet("getManga")]
        public async Task<IActionResult> Get()
        {
            var mangas = await _mangaService.GetAll();
            return Ok(mangas);
        }
        
        [HttpGet("getallbycategory")]
        public async Task<IActionResult> GetAllByCategoryId(string meta, [FromQuery]GetPublicMangaPagingRequest request)
        {
            var manga = await _mangaService.GetAllByCategoryId(meta,request);
            return Ok(manga);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]GetManageMangaPagingRequest request)
        {
            var manga = await _mangaService.GetAllPaging(request);
            return Ok(manga);
        }
        [HttpGet("getMangaDiscount")]
        public async Task<IActionResult> GetMangaDiscount()
        {
            var mangas = await _mangaService.GetMangaDiscount();
            return Ok(mangas);
        }
        [HttpGet("mangadiscountpaging")]
        public async Task<IActionResult> GetMangaDiscountPaging([FromQuery] GetManageMangaPagingRequest request)
        {
            var manga = await _mangaService.GetMangaDiscountPaging(request);
            return Ok(manga);
        }
        //http://localhost:port/Mangas/publicPaging
        //[HttpGet("publicPaging")]
        //public async Task<IActionResult> Get([FromQuery]GetPublicMangaPagingRequest request)
        //{
        //    var mangas = await _mangaService.GetAllByCategoryId(request);
        //    return Ok(mangas);
        //}

        //http://localhost:port/mangas/1
        [HttpGet("{mangaId}")]
        public async Task<IActionResult> GetById(int mangaId)
        {
            var mangas = await _mangaService.GetById(mangaId);
            return Ok(mangas);
        }

       

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] MangaCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mangaId = await _mangaService.Create(request);
            if (mangaId == 0)
            {
                return BadRequest();
            }

            var manga = await _mangaService.GetById(mangaId);

            return CreatedAtAction(nameof(GetById), new { id = mangaId }, manga);
        }

        [HttpPut("{mangaId}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Update(int mangaId, [FromForm] MangaUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Result = await _mangaService.Update(mangaId, request);
            if (Result ==0)
            {
                return BadRequest(Result);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var Result = await _mangaService.Detele(id);
            return Ok(Result);
        }

        [HttpPatch("{MaManga}/{NewGia}")]
        public async Task<IActionResult> UpdateGia(int MaManga, float NewGia)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mangaService.UpdateGia(MaManga, NewGia);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //Images
        [HttpPost("{MaManga}/images")]
        public async Task<IActionResult> CreateImage(int MaManga, [FromForm]MangaImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _mangaService.AddImage(MaManga, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _mangaService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }

        [HttpPut("{MaManga}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm]MangaImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _mangaService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{MaManga}/images/{imageId}")]
        [Authorize]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _mangaService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpGet("{MaManga}/images/{imageId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetImageById(int MaManga, int imageId)
        {
            var image = await _mangaService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find manga");
            return Ok(image);
        }

        [HttpPut("{mangaId}/categories")]
        [Authorize]
        public async Task<IActionResult> CategoryAssign(int mangaId, [FromBody] CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mangaService.CategoryAssign(mangaId, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("{mangaId}/discount")]
        public async Task<IActionResult> DiscountManga(int mangaId, [FromBody] DiscountMnRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mangaService.DiscountManga(mangaId, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}