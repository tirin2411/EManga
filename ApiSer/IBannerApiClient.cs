using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Catalog.Banner;
using ViewModels.Common;

namespace ApiSer
{
    public interface IBannerApiClient
    {
        Task<List<BannerViewModel>> GetAll();
        Task<bool> Add(BannerCreateRequest request);
        Task<bool> Update(int bannerId, BannerUpdateRequest request);
        Task<ApiResult<bool>> Remove(int idBanner);
        Task<ApiResult<BannerViewModel>> GetById(int idBanner);
    }
}