using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Catalog.Order;
using ViewModels.Common;

namespace ApiSer
{
    public interface IOrderApiClient
    {
        Task<ApiResult<PagedResult<OrderVM>>> GetList(GetOrderPagingRequest request);

        Task<ApiResult<OrderViewModel>> GetById(int orderid);

        Task<ApiResult<List<OrderViewModel>>> GetListMnById(int orderid);

        Task<ApiResult<int>> Create(OrderCreate request);

        Task<ApiResult<bool>> Update(int orderid, OrderUpdate request);
    }
}