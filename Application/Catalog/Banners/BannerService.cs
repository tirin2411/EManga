using Application.Common;
using Data.EF;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Utilities.Exceptions;
using ViewModels.Catalog.Banner;
using ViewModels.Common;

namespace Application.Catalog.Banners
{
    public class BannerService : IBannerService
    {
        private readonly MnDbContext _context;
        private readonly IStorageService _storageService;

        public BannerService(MnDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<List<BannerViewModel>> GetAll()
        {
            return await _context.Banners.Select(i => new BannerViewModel()
            {
                Id = i.Id,
                Hinh = i.Hinh,
                ThuTu = i.ThuTu,
                Tieude = i.Tieude,
                Noidung = i.Noidung,
                Meta = i.Meta,
                Anhien = i.Anhien
            }).ToListAsync();
        }

        public async Task<ApiResult<BannerViewModel>> GetById(int idBanner)
        {
            var banner = await _context.Banners.FindAsync(idBanner);

            var bannerViewModel = new BannerViewModel()
            {
                Id = banner.Id,
                Hinh = banner.Hinh,
                ThuTu = banner.ThuTu,
                Tieude = banner.Tieude,
                Noidung = banner.Noidung,
                Meta = banner.Meta,
                Anhien = banner.Anhien
            };
            return new ApiSuccessResult<BannerViewModel>(bannerViewModel);
        }

        public async Task<int> Add(BannerCreateRequest request)
        {
            var banner = new Banner()
            {
                ThuTu = request.ThuTu,
                Tieude = request.Tieude,
                Noidung = request.Noidung,
                Meta = request.Meta,
                Anhien =request.Anhien
            };
            banner.Hinh = await this.SaveFile(request.ImageFile);
            banner.FileSize = request.ImageFile.Length;

            _context.Banners.Add(banner);
            await _context.SaveChangesAsync();
            return banner.Id;
        }

        public async Task<ApiResult<bool>> Remove(int idBanner)
        {
            var bannerImage = await _context.Banners.FindAsync(idBanner);
            if (bannerImage == null)
                throw new FMNException($"Cannot find an image with id {idBanner}");
            _context.Banners.Remove(bannerImage);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<int> Update(int bannerId, BannerUpdateRequest request)
        {
            var banner = await _context.Banners.FindAsync(bannerId);

            banner.ThuTu = request.ThuTu;
            banner.Tieude = request.Tieude;
            banner.Noidung = request.Noidung;
            banner.Meta = request.Meta;
            banner.Anhien = request.Anhien;
            
            _context.Banners.Update(banner);
            return await _context.SaveChangesAsync();
        }
    }
}