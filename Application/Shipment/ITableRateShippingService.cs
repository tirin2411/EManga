using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Common;
using ViewModels.Shipment;

namespace Application.Shipment
{
    public interface ITableRateShippingService
    {
        //GetShippingPriceRequest
        //GetShippingPrices (GetShippingPriceRequest request)
        Task<int> Create(ShippingPriceRequest request);
        Task<int> Update(int id, ShippingPriceUpdate request);
        Task<ApiResult<bool>> Detele(int id);
        Task<PriceAndDestinationVM> GetById(int id);
        Task<List<PriceAndDestinationVM>> GetAll();
        Task<PriceAndDestinationVM> GetByProvinceId(int provinceId);

    }
}
