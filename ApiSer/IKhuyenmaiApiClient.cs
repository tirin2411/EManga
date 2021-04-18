using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Khuyenmai;
using ViewModels.Common;

namespace ApiSer
{
    public interface IKhuyenmaiApiClient
    {
        Task<List<KhuyenmaiVM>> GetAllDiscount();

        Task<PagedResult<KhuyenmaiVM>> GetAll(GetDiscountPagingRequest request);
        Task<KhuyenmaiVM> GetById(int id);
        Task<bool> Create(KhuyenmaiCreateRequest request);
        Task<bool> Update(int id, KhuyenmaiUpdateRequest request);

        Task<ApiResult<bool>> Detele(int id);
    }
}
