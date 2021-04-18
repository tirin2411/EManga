using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Exceptions;
using ViewModels.Catalog.Theloai;
using ViewModels.Common;

namespace Application.Catalog.Categorys
{
    public class TheloaiService : ITheloaiService
    {
        private readonly MnDbContext _context;

        public TheloaiService(MnDbContext context)
        {
            _context = context;
        }

        public async Task<List<TheloaiViewModel>> GetListAd()
        {
            return await _context.Theloais.OrderBy(y => y.Thutu).Select(i => new TheloaiViewModel()
            {
                Id = i.Id,
                TenTL = i.TenTL,
                Thutu = i.Thutu,
                Meta = i.Meta
            }).ToListAsync();
        }
        public async Task<List<TheloaiViewModel>> GetList()
        {
            return await _context.Theloais.Where(x => x.Anhien == true).OrderBy(y => y.Thutu).Select(i => new TheloaiViewModel()
            {
                Id = i.Id,
                TenTL = i.TenTL,
                Thutu = i.Thutu,
                Meta = i.Meta
            }).ToListAsync();
        }

        public async Task<TheloaiViewModel> GetById(int theloaiId)
        {
            var query = from c in _context.Theloais
                        where  c.Id == theloaiId
                        select new { c };
            return await query.Select(x => new TheloaiViewModel()
            {
                Id = x.c.Id,
                TenTL = x.c.TenTL,
                Meta = x.c.Meta,
                Thutu = x.c.Thutu,
                Anhien = x.c.Anhien
            }).FirstOrDefaultAsync();
        }

        public async Task<ApiResult<int>> Create(TheloaiCreateRequest request)
        {
            var theloai = new Theloai()
            {
                TenTL = request.TenTL,
                Thutu = request.Thutu,
                Meta = request.Meta,
                Anhien = request.Anhien
            };
            _context.Theloais.Add(theloai);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>(theloai.Id);
        }

        public async Task<ApiResult<bool>> Update(int idTL, TheloaiUpdateRequest request)
        {
            var tl = await _context.Theloais.FindAsync(idTL);
            if (tl == null) throw new FMNException($"Cannot find a category with id: {request.Id}");
            idTL = request.Id;
            tl.Thutu = request.Thutu;
            tl.Meta = request.Meta;
            tl.Anhien = request.Anhien;

            _context.Theloais.Update(tl);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Detele(int id)
        {
            var manga = await _context.Theloais.FindAsync(id);
            if (manga == null) throw new FMNException($"Cannot find a theloai: {id}");
            _context.Theloais.Remove(manga);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<List<NgonnguVM>> GetListNgonngu()
        {
            return await _context.NgonnguMns.Select(i => new NgonnguVM()
            {
                Id = i.Id,
                Name = i.Name,
            }).ToListAsync();
        }
    }
}