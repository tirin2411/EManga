using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.System.Locals;

namespace Application.System.Locals
{
    public interface ILocalService
    {
        Task<List<ProvinceVM>> GetProvince();
        Task<ProvinceVM> GetProvinceId(int provinceId);
        Task<List<DistrictVM>> GetDistrict(int provinceId);
        Task<DistrictVM> GetDistrictId(int districtId);
        Task<List<WardVM>> GetWard(int districtId);
        Task<WardVM> GetWardId(int wardId);
    }
}
