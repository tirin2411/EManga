using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Catalog.Menus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.Menus;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("getmenu")]
        public async Task<IActionResult> Get()
        {
            var theloai = await _menuService.GetAllMenu();
            return Ok(theloai);
        }
        [HttpGet("getmenuitem/{menuId}")]
        public async Task<IActionResult> GetItem(int menuId)
        {
            var theloai = await _menuService.GetAllMenuItem(menuId);
            return Ok(theloai);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var theloai = await _menuService.GetMenuById(id);
            if (theloai == null)
                return BadRequest("Cannot find category");
            return Ok(theloai);
        }
        [HttpGet("{id}/{menuId}")]
        public async Task<IActionResult> GetItemById(int id, int menuId)
        {
            var theloai = await _menuService.GetMenuItemById(id, menuId);
            if (theloai == null)
                return BadRequest("Cannot find category");
            return Ok(theloai);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]MenuCreate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _menuService.Create(request);
            if (!result.IsSuccessed)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]MenuUpdate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _menuService.Update(id, request);
            if (!affectedResult.IsSuccessed)
            {
                return BadRequest(affectedResult);
            }
            return Ok(affectedResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var Result = await _menuService.Detele(id);
            return Ok(Result);
        }
    }
}