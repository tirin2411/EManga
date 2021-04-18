using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.System.Locals;

namespace ApiSer
{
    public interface ILocalApiClient
    {
        Task<List<ProvinceVM>> GetProvince();
        Task<List<DistrictVM>> GetDistrict(int? provinceId);
        Task<List<WardVM>> GetWard(int? districtId);
        Task<ProvinceVM> GetProvinceId(int? provinceId);
        Task<DistrictVM> GetDistrictId(int? districtId);
        Task<WardVM> GetWardId(int? wardId);

    }
}
