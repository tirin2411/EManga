using Data.EF;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Exceptions;
using ViewModels.Catalog.Cart;

namespace Application.Catalog.Cart
{
    public class CartService : ICartService
    {
        private readonly MnDbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public CartService(MnDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public  Task<CartViewModel> GetCart(Guid userId)
        {
            //var user = await _userManager.FindByIdAsync(userId.ToString());
            //var query = from c in _context.GioHangs
            //            join ci in _context.GioHangDetails on c.Id equals ci.GioHangId
            //            where c.UserId == userId
            //            select new { c, ci};
            //var cartViewModel = new CartViewModel()
            //{
               
            //};
            //return cartViewModel;
            throw new NotImplementedException();

        }

        public  Task<int> AddToCart(Guid iduser, int mamanga, int quantity)
        {
            //var cart = await GetCart(iduser);
            //if(cart == null)
            //{
            //    cart = new GioHang()
            //    {
            //        UserId = iduser
            //    };
            //    _context.GioHangs.Add(cart);
            //}
            throw new NotImplementedException();
        }


        public Task<int> Remove(Guid iduser, int cartid)
        {
            throw new NotImplementedException();
        }

        //public async Task<int> Add(Guid iduser, int mamanga, AddItem request)
        //{
        //    var cart = new GioHang()
        //    {
        //        MangaId = mamanga,
        //        UserId = iduser
        //    };
        //    _context.GioHangs.Add(cart);
        //    await _context.SaveChangesAsync();
        //    return cart.Id;
        //}

        //public async Task<List<CartViewModel>> GetAll()
        //{
        //    var query = from c in _context.GioHangs
        //                join m in _context.Mangas on c.MangaId equals m.Id
        //                join im in _context.MangaImages on m.Id equals im.MangaId
        //                join u in _context.AppUsers on c.UserId equals u.Id
        //                select new { c, m, u, im };
        //    var data = await query.Select(x => new CartViewModel()
        //    {
        //        Id = x.c.Id,
        //        MangaId = x.c.MangaId,
        //        Ten = x.m.Ten,
        //        Gia = x.m.Gia,
        //        LinkAnh = x.im.LinkAnh,
        //        UserId = x.u.Id
        //    }).ToListAsync();

        //    return data;
        //}

        //public async Task<CartViewModel> GetById(int cartid)
        //{
        //    var cart = await _context.GioHangs.FindAsync(cartid);

        //    var cartViewModel = new CartViewModel()
        //    {
        //        Id = cart.Id,
        //        MangaId = cart.MangaId,
        //        Gia = cart.Gia,
        //        UserId = cart.UserId
        //    };
        //    return cartViewModel;
        //}

        //public async Task<List<CartViewModel>> GetByUserId(Guid userid)
        //{
        //    return await _context.GioHangs.Where(x => x.UserId == userid).Select(i => new CartViewModel()
        //    {
        //        Id = i.Id,
        //        MangaId = i.MangaId,
        //        Gia = i.Gia
        //    }).ToListAsync();
        //}

        //public Task<List<CartViewModel>> GetCart()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<int> Remove(Guid iduser, int cartid)
        //{
        //    var cart = await _context.GioHangs.FindAsync(cartid);
        //    if (cart == null)
        //        throw new FMNException($"Cannot find an manga with id {cartid}");
        //    _context.GioHangs.Remove(cart);
        //    return await _context.SaveChangesAsync();
        //}
    }
}