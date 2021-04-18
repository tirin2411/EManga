using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Banner;
using ViewModels.Common;

namespace Application.Catalog.Banners
{
    public interface IBannerService
    {
        Task<List<BannerViewModel>> GetAll();

        Task<int> Add(BannerCreateRequest request);
        Task<int> Update(int bannerId, BannerUpdateRequest request);

        Task<ApiResult<bool>> Remove(int idBanner);

        Task<ApiResult<BannerViewModel>> GetById(int idBanner);
    }
}