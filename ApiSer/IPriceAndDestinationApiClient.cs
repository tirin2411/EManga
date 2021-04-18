using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Common;
using ViewModels.Shipment;

namespace ApiSer
{
    public interface IPriceAndDestinationApiClient
    {
        Task<List<PriceAndDestinationVM>> GetAll();
        Task<PriceAndDestinationVM> GetById(int id);
        Task<PriceAndDestinationVM> GetByProvinceId(int? provinceId);
        Task<bool> Create(ShippingPriceRequest request);
        Task<bool> Update(int id, ShippingPriceUpdate request);
        Task<ApiResult<bool>> Detele(int id);
    }
}
