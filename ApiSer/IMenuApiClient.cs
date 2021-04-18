using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Catalog.Menus;
using ViewModels.Common;

namespace ApiSer
{
    public interface IMenuApiClient
    {
        Task<List<MenuViewModel>> GetAll();
        Task<List<MenuItemVM>> GetAllItem(int? menuId);

        Task<ApiResult<MenuViewModel>> GetById(int id);
        Task<ApiResult<MenuItemVM>> GetItemById(int id,int menuId);


        Task<ApiResult<int>> Create(MenuCreate request);

        Task<ApiResult<bool>> Update(int id, MenuUpdate request);

        Task<ApiResult<bool>> Detele(int id);
    }
}