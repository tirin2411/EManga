using Application.Common;
using Data.EF;
using Data.Entities;
using Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Exceptions;
using ViewModels.Catalog.Khuyenmai;
using ViewModels.Common;

namespace Application.Catalog.Khuyenmais
{
    public class KhuyenmaiiService : IKhuyenmaiiService
    {
        private readonly MnDbContext _context;

        public KhuyenmaiiService(MnDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(KhuyenmaiCreateRequest request)
        {
            var discount = new Khuyenmai()
            {
                FromDate = request.FromDate,
                ToDate = request.ToDate,
                ApplyForAll = request.ApplyForAll,
                DiscountPercent = request.DiscountPercent,
                DiscountAmount = request.DiscountAmount,
                Status = request.Status,
                Name = request.Name,
                CouponCode = request.CouponCode,
                //MaximumDiscountedQuantity = request.MaximumDiscountedQuantity
            };
            _context.Khuyenmais.Add(discount);
            await _context.SaveChangesAsync();
            return discount.Id;
        }

        public async Task<ApiResult<bool>> Detele(int id)
        {
            var discount = await _context.Khuyenmais.FindAsync(id);
            if (discount == null) throw new FMNException($"Cannot find a discount: {id}");
            _context.Khuyenmais.Remove(discount);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<PagedResult<KhuyenmaiVM>> GetAll(GetDiscountPagingRequest request)
        {
            //1. Select join
            var query = from d in _context.Khuyenmais
                        select new { d };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.d.Name.Contains(request.Keyword));
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)

                .Select(x => new KhuyenmaiVM()
                {
                    Id = x.d.Id,
                    FromDate = x.d.FromDate,
                    ToDate = x.d.ToDate,
                    ApplyForAll = x.d.ApplyForAll,
                    DiscountPercent = x.d.DiscountPercent,
                    DiscountAmount = x.d.DiscountAmount,
                    Status = x.d.Status,
                    Name = x.d.Name,
                    CouponCode = x.d.CouponCode,
                    //MaximumDiscountedQuantity = x.d.MaximumDiscountedQuantity
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<KhuyenmaiVM>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
         
        }

        public async Task<KhuyenmaiVM> GetById(int id)
        {
            var query = from c in _context.Khuyenmais
                        where c.Id == id
                        select new { c };
            return await query.Select(x => new KhuyenmaiVM()
            {
                Id = x.c.Id,
                FromDate = x.c.FromDate,
                ToDate = x.c.ToDate,
                ApplyForAll = x.c.ApplyForAll,
                DiscountPercent = x.c.DiscountPercent,
                DiscountAmount = x.c.DiscountAmount,
                Status = x.c.Status,
                Name = x.c.Name,
                CouponCode = x.c.CouponCode,
                //MaximumDiscountedQuantity = x.c.MaximumDiscountedQuantity
            }).FirstOrDefaultAsync();
        }

        public async Task<List<KhuyenmaiVM>> GetList()
        {
            var getlist = from d in _context.Khuyenmais
                          select d;
            return await getlist.Select(i => new KhuyenmaiVM()
            {
                Id = i.Id,
                FromDate = i.FromDate,
                ToDate = i.ToDate,
                Name = i.Name,
                ApplyForAll = i.ApplyForAll,
                Status = i.Status,
                DiscountAmount = i.DiscountAmount,
                DiscountPercent = i.DiscountPercent,
                CouponCode = i.CouponCode
            }).ToListAsync();
        }

        public async Task<int> Update(int id, KhuyenmaiUpdateRequest request)
        {
            var discount = await _context.Khuyenmais.FindAsync(id);
          
            if (discount == null) throw new FMNException($"Cannot find a product with id: {request.Id}");

            discount.Name = request.Name;
            discount.ToDate = request.ToDate;
            discount.ApplyForAll = request.ApplyForAll;
            discount.DiscountPercent = request.DiscountPercent;
            discount.DiscountAmount = request.DiscountAmount;
            discount.Status = request.Status;
            //discount.MaximumDiscountedQuantity = request.MaximumDiscountedQuantity;
            _context.Khuyenmais.Update(discount);
            return await _context.SaveChangesAsync();
        }
    }
}
