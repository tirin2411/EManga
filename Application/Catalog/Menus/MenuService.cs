using Application.Common;
using Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Menus;
using ViewModels.Common;
using Data.Entities;
using Utilities.Exceptions;

namespace Application.Catalog.Menus
{
    public class MenuService : IMenuService
    {
        private readonly MnDbContext _context;
        private readonly IStorageService _storageService;

        public MenuService(MnDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<List<MenuViewModel>> GetAllMenu()
        {
            return await _context.Menus.Select(i => new MenuViewModel()
            {
                Id = i.Id,
                TenMenu = i.TenMenu,
                Meta = i.Meta,
                ThuTu = i.ThuTu,
                Anhien = i.Anhien
            }).ToListAsync();
        }
        public async Task<ApiResult<MenuViewModel>> GetMenuById(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            var menuViewModel = new MenuViewModel()
            {
                Id = menu.Id,
                TenMenu = menu.TenMenu,
                ThuTu = menu.ThuTu,
                Meta = menu.Meta
            };
            return new ApiSuccessResult<MenuViewModel>(menuViewModel);
        }
        public async Task<List<MenuItemVM>> GetAllMenuItem(int menuId)
        {
            var query = from mi in _context.MenuItems
                        join m in _context.Menus on mi.MenuId equals m.Id
                        where m.Id == menuId
                        select mi;
            return await query.Select(x => new MenuItemVM()
            {
                Id = x.Id,
                Name = x.Name,
                CustomLink = x.CustomLink,
                MenuId = x.MenuId,
                Meta = x.Meta,
                ThuTu = x.ThuTu
            }).ToListAsync();
        }
        public async Task<ApiResult<MenuItemVM>> GetMenuItemById(int id, int menuId)
        {
            var menuitem = await _context.MenuItems.FindAsync(id);
            var menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == menuId);
            var menuViewModel = new MenuItemVM()
            {
                Id = menuitem.Id,
                Name = menuitem.Name,
                CustomLink = menuitem.CustomLink,
                MenuId = menuitem.MenuId,
                ThuTu = menuitem.ThuTu,
                Meta = menuitem.Meta
            };
            return new ApiSuccessResult<MenuItemVM>(menuViewModel);
        }
        public async Task<ApiResult<int>> Create(MenuCreate request)
        {
            //var menus = await (from c in _context.Menus
            //                   select c.TenMenu).ToListAsync();
            //foreach (var menu in request.Menus)
            //{
            //    var productInCategory = await _context.MenuItems
            //        .FirstOrDefaultAsync(x => x.MenuId == int.Parse(menu.Id));
            //};
            var menuitem = new MenuItem()
            {
                
                MenuId = request.MenuId,
                Name = request.Name,
                CustomLink = request.CustomLink,
                Meta = request.Meta,
                ThuTu = request.ThuTu
            };
            
            _context.MenuItems.Add(menuitem);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>(menuitem.Id);
        }

        public async Task<ApiResult<bool>> Detele(int id)
        {
            var manga = await _context.Menus.FindAsync(id);
            if (manga == null) throw new FMNException($"Cannot find a menu: {id}");
            _context.Menus.Remove(manga);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }
        public async Task<ApiResult<bool>> Update(int id, MenuUpdate request)
        {
            var tl = await _context.Menus.FindAsync(id);
            if (tl == null) throw new FMNException($"Cannot find a menu with id: {request.Id}");
            id = request.Id;
            tl.ThuTu = request.ThuTu;
            tl.Meta = request.Meta;

            _context.Menus.Update(tl);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }
    }
}