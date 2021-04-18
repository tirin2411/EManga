using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Tintuc;
using ViewModels.Common;

namespace Application.Catalog.Tintuc
{
    public interface ITintucServer
    {
        Task<ApiResult<PagedResult<TintucVM>>> GetAll(GetNewsPagingRequest request);

        Task<TintucVM> GetById(int id);

        Task<int> Create(TintucCreateRequest request);

        Task<int> Update(int id, TintucUpdate request);

        Task<ApiResult<bool>> Detele(int id);
    }
}