using Application.Common;
using Data.EF;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Utilities.Exceptions;
using ViewModels.Catalog.Tintuc;
using ViewModels.Common;

namespace Application.Catalog.Tintuc
{
    public class TintucService : ITintucServer
    {
        private readonly MnDbContext _context;
        private readonly IStorageService _storageService;

        public TintucService(MnDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(TintucCreateRequest request)
        {
            var news = new TinTuc()
            {
                TieuDe = request.TieuDe,
                Meta = request.Meta,
                NoiDungTomTat = request.NoiDungTomTat,
                NoiDung = request.NoiDung,
                NgayCapNhat = DateTime.Now,
                HinhAnhtintuc = await this.SaveFile(request.Hinh),
                Tacgia = "Tirin",
                AnHien = request.Anhien,
            };
            _context.TinTucs.Add(news);
            await _context.SaveChangesAsync();
            return news.Id;
        }

        public async Task<ApiResult<bool>> Detele(int id)
        {
            var manga = await _context.TinTucs.FindAsync(id);
            if (manga == null) throw new FMNException($"Cannot find a news: {id}");
            _context.TinTucs.Remove(manga);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<TintucVM>>> GetAll(GetNewsPagingRequest request)
        {
            //1. Select join
            var query = from m in _context.TinTucs
                        select m;
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.TieuDe.Contains(request.Keyword));
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TintucVM()
                {
                    Id = x.Id,
                    TieuDe = x.TieuDe,
                    Meta = x.Meta,
                    NoiDung = x.NoiDung,
                    NgayCapNhat = x.NgayCapNhat,
                    Hinh = x.HinhAnhtintuc,
                    AnHien = x.AnHien
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<TintucVM>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<TintucVM>>(pagedResult);
        }

        public async Task<TintucVM> GetById(int id)
        {
            var news = await _context.TinTucs.FindAsync(id);

            var newsViewModel = new TintucVM()
            {
                Id = news.Id,
                TieuDe = news.TieuDe,
                Meta = news.Meta,
                NoiDungTomTat = news.NoiDungTomTat,
                NoiDung = news.NoiDung,
                NgayCapNhat = news.NgayCapNhat,
                Hinh = news.HinhAnhtintuc,
                AnHien = news.AnHien
            };
            return newsViewModel;
        }

        public async Task<int> Update(int id, TintucUpdate request)
        {
            var news = await _context.TinTucs.FindAsync(id);
            if (news == null) throw new FMNException($"Cannot find a news with id: {request.Id}");
            news.TieuDe = request.TieuDe;
            news.Meta = request.Meta;
            news.NoiDungTomTat = request.NoiDungTomTat;
            news.NoiDung = request.NoiDung;
            news.NgayCapNhat = DateTime.Now;
            news.AnHien = request.AnHien;
            _context.TinTucs.Update(news);
            return await _context.SaveChangesAsync();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}