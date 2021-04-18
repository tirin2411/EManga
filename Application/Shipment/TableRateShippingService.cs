using Data.EF;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Common;
using ViewModels.Shipment;
using Data.Entities;
using Utilities.Exceptions;

namespace Application.Shipment
{
    public class TableRateShippingService : ITableRateShippingService
    {
        private readonly MnDbContext _context;

        public TableRateShippingService(MnDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(ShippingPriceRequest request)
        {
            var shipping = new ShippingTableRate()
            {
                ProvinceId = request.ProvinceId,
                DistricId = request.DistrictId,
                WardId = request.WardId,
                Note = request.Note,
                ShippingPrice = request.ShippingPrice
            };
            _context.ShippingTableRates.Add(shipping);
            await _context.SaveChangesAsync();
            return shipping.Id;
        }
        public async Task<int> Update(int id, ShippingPriceUpdate request)
        {
            var shipping = await _context.ShippingTableRates.FindAsync(id);
            if (shipping == null) throw new FMNException($"Cannot find with id: {request.Id}");
            shipping.Note = request.Note;
            shipping.ShippingPrice = request.ShippingPrice;
            _context.ShippingTableRates.Update(shipping);
            return await _context.SaveChangesAsync();
        }
        public async Task<ApiResult<bool>> Detele(int id)
        {
            var shipping = await _context.ShippingTableRates.FindAsync(id);
            if (shipping == null) throw new FMNException($"Cannot find with id: {id}");
            _context.ShippingTableRates.Remove(shipping);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<List<PriceAndDestinationVM>> GetAll()
        {
            var shippingprice = from s in _context.ShippingTableRates
                                join p in _context.Provinces on s.ProvinceId equals p.Id
                                where p.Id == s.ProvinceId
                                join d in _context.Districts on s.DistricId equals d.Id
                                where d.Id == s.DistricId
                                join w in _context.Wards on s.WardId equals w.Id
                                where w.Id == s.WardId
                                select new { s,p,d,w };
            var shippingpricevm = await shippingprice.Select(i => new PriceAndDestinationVM()
            {
                Id = i.s.Id,
                ProvinceId = i.s.ProvinceId,
                ProvinceName = i.p.Type +" "+ i.p.Name,
                DistrictId = i.s.DistricId,
                DistrictName = i.d.Type + " " + i.d.Name,
                WardId = i.s.WardId,
                WardName = i.w.Type + " " + i.w.Name,
                Note = i.s.Note,
                ShippingPrice = i.s.ShippingPrice
            }).ToListAsync();
            return shippingpricevm;
            //return await _context.ShippingTableRates.Select(i => new PriceAndDestinationVM()
            //{
            //    Id = i.Id,
            //    ProvinceId = i.ProvinceId,
            //    ProvinceName = province,
            //    DistrictId = i.DistricId,
            //    DistrictName = district,
            //    WardId = i.WardId,
            //    WardName = ward,
            //    Note = i.Note,
            //    ShippingPrice = i.ShippingPrice
            //}).ToListAsync();
        }

        public async Task<PriceAndDestinationVM> GetById(int id)
        {
            var shippingprice = await _context.ShippingTableRates.FindAsync(id);
            if (shippingprice == null) throw new FMNException($"Cannot find with id: {id}");
            var shippingViewModel = new PriceAndDestinationVM()
            {
                Id = shippingprice.Id,
                ProvinceId = shippingprice.ProvinceId,
                DistrictId = shippingprice.DistricId,
                WardId = shippingprice.WardId,
                Note = shippingprice.Note,
                ShippingPrice = shippingprice.ShippingPrice
            };
            return shippingViewModel;
        }

        public async Task<PriceAndDestinationVM> GetByProvinceId(int provinceId)
        {
            var shippingprice = await _context.ShippingTableRates.FirstOrDefaultAsync(x => x.ProvinceId == provinceId);
            if (shippingprice == null)
            {
                var shippingVM = new PriceAndDestinationVM()
                {
                    ShippingPrice = 30000
                };
                return shippingVM;
            }
            var shippingViewModel = new PriceAndDestinationVM()
            {
                Id = shippingprice.Id,
                ProvinceId = shippingprice.ProvinceId,
                Note = shippingprice.Note,
                ShippingPrice = shippingprice.ShippingPrice
            };
            return shippingViewModel;

        }
    }
}
