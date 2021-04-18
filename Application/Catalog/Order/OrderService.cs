using Data.EF;
using Data.Entities;
using Data.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Exceptions;
using ViewModels.Catalog.Order;
using ViewModels.Common;

namespace Application.Catalog.Order
{
    public class OrderService : IOrderService
    {
        private readonly MnDbContext _context;

        public OrderService(MnDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> Create(Guid iduser, OrderCreate request)
        {
            var order = new DonHang()
            {
                UserId = iduser,
                NguoiNhan = request.NguoiNhan,
                DiaChiNhan = request.DiaChiNhan,
                SDT = request.SDT,
                DonHangDetails = new List<DonHangDetail>()
                {
                    new DonHangDetail()
                    {
                        MangaId = request.MangaId,
                        Gia = request.Gia,
                        Soluongdat = request.Soluongdat
                    }
                },
            };
            _context.DonHangs.Add(order);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>(order.Id);
        }

        public async Task<List<OrderViewModel>> GetAll()
        {
            var query = from c in _context.DonHangs
                        join u in _context.AppUsers on c.UserId equals u.Id
                        //join od in _context.DonHangDetails on c.Id equals od.DonHangId
                        //join m in _context.Mangas on od.MangaId equals m.Id
                        select new { c, u };

            var data = await query.Select(x => new OrderViewModel()
            {
                Id = x.c.Id,
                NgayDat = x.c.NgayDat,
                UserId = x.u.Id,
                NguoiNhan = x.c.NguoiNhan,
                DiaChiNhan = x.c.DiaChiNhan,
                SDT = x.c.SDT,
                Tinhtrang = x.c.Tinhtrang,
                //Tongtien = x.c.TongTien
                //MangaId = x.od.MangaId,
                //TenMn = x.m.Ten,
                //Gia = x.od.Gia,
                //Soluongdat = x.od.Soluongdat
            }).ToListAsync();

            return data;
        }

        public async Task<ApiResult<OrderViewModel>> GetById(int orderid)
        {
            var order = await _context.DonHangs.FindAsync(orderid);
            var orderdetail = await _context.DonHangDetails.FirstOrDefaultAsync(x => x.DonHangId == orderid);
            var orderViewModel = new OrderViewModel()
            {
                Id = order.Id,
                NgayDat = order.NgayDat,
                NguoiNhan = order.NguoiNhan,
                DiaChiNhan = order.DiaChiNhan,
                SDT = order.SDT,
                Tinhtrang = order.Tinhtrang,
                MangaId = orderdetail.MangaId,
                Gia = orderdetail.Gia,
                Soluongdat = orderdetail.Soluongdat
            };
            return new ApiSuccessResult<OrderViewModel>(orderViewModel);
        }

        public async Task<ApiResult<PagedResult<OrderVM>>> GetList(GetOrderPagingRequest request)
        {
            //1. Select join
            var query = from c in _context.DonHangs
                        join u in _context.AppUsers on c.UserId equals u.Id
                        //join od in _context.DonHangDetails on c.Id equals od.DonHangId
                        //join m in _context.Mangas on od.MangaId equals m.Id
                        select new { c, u};
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.c.SDT.Contains(request.Keyword) || x.c.NguoiNhan.Contains(request.Keyword));

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new OrderVM()
                {
                    Id = x.c.Id,
                    NgayDat = x.c.NgayDat,
                    UserId = x.u.Id,
                    NguoiNhan = x.c.NguoiNhan,
                    DiaChiNhan = x.c.DiaChiNhan,
                    SDT = x.c.SDT,
                    Email = x.c.Email,
                    Tinhtrang = x.c.Tinhtrang,
                    TinhtrangThanhtoan = x.c.TinhtrangThanhtoan,
                    Tongtien = x.c.TongTien
                    //Gia = x.od.Gia,
                    //Soluongdat = x.od.Soluongdat
                    //MangaId = x.od.MangaId,
                    //TenMn = x.m.Ten,
                    //Gia = x.od.Gia,
                    //Soluongdat = x.od.Soluongdat,
                    //Tongtien = x.od.Tongtien
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<OrderVM>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<OrderVM>>(pagedResult);
        }

        public async Task<ApiResult<List<OrderViewModel>>> GetListMnById(int orderid)
        {
            var query = from c in _context.DonHangDetails
                        join m in _context.Mangas on c.MangaId equals m.Id
                        select new { c, m };
            var orderviewmodel = await query.Where(x => x.c.DonHangId == orderid)
                .Select(i => new OrderViewModel()
                {
                    MangaId = i.c.MangaId,
                    TenMn = i.m.Ten,
                    Gia = i.m.Gia,
                    LinkAnh = i.m.HinhAnh,
                    Soluongdat = i.c.Soluongdat
                }).ToListAsync();
            return new ApiSuccessResult<List<OrderViewModel>>(orderviewmodel);
        }

        

        public async Task<ApiResult<bool>> Update(int orderid, OrderUpdate request)
        {
            var order = await _context.DonHangs.FindAsync(orderid);
            var orderdetail = await _context.DonHangDetails.FirstOrDefaultAsync(x => x.DonHangId == request.Id
            && x.DonHangId == request.Id);

            if (order == null || orderdetail == null) throw new FMNException($"Cannot find a product with id: {request.Id}");

            order.Tinhtrang = request.Tinhtrang;

            _context.DonHangs.Update(order);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }
    }
}