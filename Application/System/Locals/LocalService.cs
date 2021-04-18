using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Exceptions;
using ViewModels.System.Locals;

namespace Application.System.Locals
{
    public class LocalService : ILocalService
    {
        private readonly MnDbContext _context;

        public LocalService(MnDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProvinceVM>> GetProvince()
        {
            return await _context.Provinces.Select(i => new ProvinceVM()
            {
                Id = i.Id,
                type = i.Type,
                Name = i.Name
            }).ToListAsync();
        }

        public async Task<List<DistrictVM>> GetDistrict(int provinceId)
        {
            var query = from mi in _context.Districts
                        join m in _context.Provinces on mi.ProvinceId equals m.Id
                        where m.Id == provinceId
                        select mi;
            return await query.Select(x => new DistrictVM()
            {
                Id = x.Id,
                type = x.Type,
                Name = x.Name
            }).ToListAsync();
        }

       
        public async Task<List<WardVM>> GetWard(int districtId)
        {
            var query = from mi in _context.Wards
                        join m in _context.Districts on mi.DistrictId equals m.Id
                        where m.Id == districtId
                        select mi;
            return await query.Select(x => new WardVM()
            {
                Id = x.Id,
                type = x.Type,
                Name = x.Name
            }).ToListAsync();
        }

        public async Task<ProvinceVM> GetProvinceId(int provinceId)
        {
            var province = await _context.Provinces.FindAsync(provinceId);
            if (province == null) throw new FMNException($"Cannot find with id: {provinceId}");
            var provinceViewModel = new ProvinceVM()
            {
                Id = province.Id,
                type = province.Type,
                Name = province.Name
            };
            return provinceViewModel;
        }

        public async Task<DistrictVM> GetDistrictId(int districtId)
        {
            var district = await _context.Districts.FindAsync(districtId);
            if (district == null) throw new FMNException($"Cannot find with id: {districtId}");
            var districtViewModel = new DistrictVM()
            {
                Id = district.Id,
                type = district.Type,
                Name = district.Name
            };
            return districtViewModel;
        }

        public async Task<WardVM> GetWardId(int wardId)
        {
            var ward = await _context.Wards.FindAsync(wardId);
            if (ward == null) throw new FMNException($"Cannot find with id: {wardId}");
            var wardViewModel = new WardVM()
            {
                Id = ward.Id,
                type = ward.Type,
                Name = ward.Name
            };
            return wardViewModel;
        }
    }
}
