using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Khuyenmai;
using ViewModels.Common;

namespace Application.Catalog.Khuyenmais
{
    public interface IKhuyenmaiiService
    {
        Task<List<KhuyenmaiVM>> GetList();
        Task<PagedResult<KhuyenmaiVM>> GetAll(GetDiscountPagingRequest request);
        Task<KhuyenmaiVM> GetById(int id);
        Task<int> Create(KhuyenmaiCreateRequest request);
        Task<int> Update(int id, KhuyenmaiUpdateRequest request);

        Task<ApiResult<bool>> Detele(int id);
    }
}
