using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Catalog.Tintuc;
using ViewModels.Common;

namespace ApiSer
{
    public interface ITintucApiClient
    {
        Task<ApiResult<PagedResult<TintucVM>>> GetAll(GetNewsPagingRequest request);

        Task<TintucVM> GetById(int id);

        Task<bool> Create(TintucCreateRequest request);

        Task<bool> Update(int id, TintucUpdate request);

        Task<ApiResult<bool>> Detele(int id);
    }
}