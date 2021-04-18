using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Order;
using ViewModels.Common;

namespace Application.Catalog.Order
{
    public interface IOrderService
    {
        Task<ApiResult<PagedResult<OrderVM>>> GetList(GetOrderPagingRequest request);

        Task<List<OrderViewModel>> GetAll();

        Task<ApiResult<OrderViewModel>> GetById(int orderid);

        Task<ApiResult<List<OrderViewModel>>> GetListMnById(int orderid);

        Task<ApiResult<int>> Create(Guid iduser, OrderCreate request);

        Task<ApiResult<bool>> Update(int orderid, OrderUpdate request);
        //IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);
        
    }
}