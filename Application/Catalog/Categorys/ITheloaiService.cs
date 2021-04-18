using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Theloai;
using ViewModels.Common;

namespace Application.Catalog.Categorys
{
    public interface ITheloaiService
    {
        Task<List<TheloaiViewModel>> GetListAd();

        Task<List<TheloaiViewModel>> GetList();

        Task<List<NgonnguVM>> GetListNgonngu();

        Task<TheloaiViewModel> GetById(int theloaiId);

        Task<ApiResult<int>> Create(TheloaiCreateRequest request);

        Task<ApiResult<bool>> Update(int idTL, TheloaiUpdateRequest request);

        Task<ApiResult<bool>> Detele(int id);
    }
}