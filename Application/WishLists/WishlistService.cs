using Data.EF;
using Data.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.WishList;
using Microsoft.EntityFrameworkCore;

namespace Application.WishLists
{
    public class WishlistService : IWishListService
    {
        private readonly MnDbContext _context;

        public WishlistService(MnDbContext context)
        {
            _context = context;
        }

        public async Task<List<WishListItemVM>> GetWishListByIdUser(Guid userId)
        {

            //var wishlist = await _context.WishLists.FindAsync(userId);
            //var wishlist = from w in _context.WishLists
            //               join u in _context.AppUsers on w.UserId equals u.Id
            //               where w.UserId == userId
            //               select w.Id;
            var query = from wi in _context.WishListItems
                        join mn in _context.Mangas on wi.MangaId equals mn.Id
                        join w in _context.WishLists on wi.WishListId equals w.Id
                        join u in _context.AppUsers on w.UserId equals u.Id
                        //where w.UserId == userId
                        select new { wi,mn,w};
            //.Where(x => x.wi.WishListId == wishlist)
            var data = await query.Where(c=>c.w.UserId == userId).Select(x => new WishListItemVM()
            {
                WishListId = x.w.Id,
                MangaId = x.mn.Id,
                MangaName = x.mn.Ten,
                MangaImg = x.mn.HinhAnh,
                MangaPrice = x.mn.Gia,
                Quantity = x.wi.Soluongdat
            }).ToListAsync();
            //.Where(x => x.w.UserId == userId)
            //var wishlistviewmodel = await query.Select(x=> new WishListVM()
            //{
            //    //Id = query.w.Id,
            //    Items = data
            //}).ToListAsync();
            return data;
        }

        public async Task<int> Create(Guid userId, int mangaId)
        {
            List<WishListItemVM> wishlistitems = await GetWishListByIdUser(userId);

            var wishlistid =await _context.WishLists.SingleOrDefaultAsync(x => x.UserId == userId);
            if (wishlistid == null)
            {
                var wishlist = new WishList()
                {
                    UserId = userId,
                    //            WishListItems = new List<WishListItem>()
                    //            {
                    //                new WishListItem()
                    //                {
                    //                    MangaId = mangaId
                    //                }
                    //            },
                };
                _context.WishLists.Add(wishlist);
                await _context.SaveChangesAsync();
                return wishlist.Id;

            }
            if (wishlistitems.FirstOrDefault(m => m.MangaId == mangaId) == null)
            {
                Manga mn = _context.Mangas.Find(mangaId);
                var listitems = new WishListItem()
                {
                    WishListId = wishlistid.Id,
                    MangaId = mangaId,
                    Gia = mn.Gia,
                    Soluongdat = 1
                };
                _context.WishListItems.Add(listitems);
                await _context.SaveChangesAsync();
                return listitems.Id;
            }
            else
            {
                var items = wishlistitems.FirstOrDefault(m => m.MangaId == mangaId);
                items.Quantity = +1;
                await _context.SaveChangesAsync();
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid userId, int mangaId)
        {
            List<WishListItemVM> wishlistitems = await GetWishListByIdUser(userId);
            if (wishlistitems.FirstOrDefault(m => m.MangaId == mangaId) != null)
            {
                var wishlistid = await _context.WishListItems.SingleOrDefaultAsync(x => x.MangaId == mangaId);
                _context.WishListItems.Remove(wishlistid);
                return await _context.SaveChangesAsync();

            }
            return await _context.SaveChangesAsync();
        }
    }
}
