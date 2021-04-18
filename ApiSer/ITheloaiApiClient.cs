using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Catalog.Theloai;
using ViewModels.Common;

namespace ApiSer
{
    public interface ITheloaiApiClient
    {
        Task<List<TheloaiViewModel>> GetAllAd();

        Task<List<TheloaiViewModel>> GetAll();
        Task<List<NgonnguVM>> GetListNgonngu();

        Task<TheloaiViewModel> GetById(int id);

        Task<ApiResult<int>> Create(TheloaiCreateRequest request);

        Task<ApiResult<bool>> Update(int theloaiId, TheloaiUpdateRequest request);

        Task<ApiResult<bool>> Detele(int id);
    }
}