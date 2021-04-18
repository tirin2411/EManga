using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Menus;
using ViewModels.Common;

namespace Application.Catalog.Menus
{
    public interface IMenuService
    {
        Task<List<MenuViewModel>> GetAllMenu();

        Task<ApiResult<MenuViewModel>> GetMenuById(int id);
        Task<List<MenuItemVM>> GetAllMenuItem(int menuId);

        Task<ApiResult<MenuItemVM>> GetMenuItemById(int id,int menuId);

        Task<ApiResult<int>> Create(MenuCreate request);

        Task<ApiResult<bool>> Update(int id, MenuUpdate request);

        Task<ApiResult<bool>> Detele(int id);
    }
}