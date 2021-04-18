using Application.Common;
using Data.EF;
using Data.Entities;
using Utilities.Exceptions;
using ViewModels.Catalog.MangaImages;
using ViewModels.Catalog.Mangas;
using ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Catalog.Mangas
{
    public class MangaService : IMangaService
    {
        private readonly MnDbContext _context;
        private readonly IStorageService _storageService;

        public MangaService(MnDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> AddImage(int mamanga, MangaImageCreateRequest request)
        {
            var mangaImage = new MangaImage()
            {
                ChuThich = request.ChuThich,
                Anhmacdinh = request.Anhmacdinh,
                MangaId = mamanga,
                ThuTu = request.ThuTu
            };

            if (request.ImageFile != null)
            {
                mangaImage.LinkAnh = await this.SaveFile(request.ImageFile);
                mangaImage.FileSize = request.ImageFile.Length;
            }
            _context.MangaImages.Add(mangaImage);
            await _context.SaveChangesAsync();
            return mangaImage.Id;
        }

        public async Task<int> Create(MangaCreateRequest request)
        {
            var manga = new Manga()
            {
                Ten = request.Ten,
                Meta = request.Meta,
                Gia = request.Gia,
                Giagoc = request.Gia,
                Anhien = true,
                NgonnguId = request.NgonnguId,
                HinhAnh = await this.SaveFile(request.HinhNho),
                MangaDetails = new List<MangaDetail>()
                {
                    new MangaDetail()
                    {
                        SoLuong = request.SoLuong,
                        TinhtrangMn = request.TinhtrangMn,
                        Mota = request.Mota,
                        Tacgia = request.Tacgia,
                        NamXB =request.NamXB,
                        Sotrang = request.Sotrang
                    }
                },
                MnTheloais = new List<MnTheloai>()
                {
                    new MnTheloai()
                    {
                        TheLoaiId = request.TheloaiId
                    }
                },
                InforSells = new List<InforSell>()
                {
                    new InforSell()
                    {
                        UserId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE")
                    }
                }
            };

            _context.Mangas.Add(manga);
            await _context.SaveChangesAsync();
            return manga.Id;
        }

        public async Task<ApiResult<bool>> Detele(int id)
        {
            var manga = await _context.Mangas.FindAsync(id);
            if (manga == null) throw new FMNException($"Cannot find a manga: {id}");

            var hinhs = _context.MangaImages.Where(i => i.MangaId == id);
            foreach (var hinh in hinhs)
            {
                await _storageService.DeleteFileAsync(hinh.LinkAnh);
            }
            _context.Mangas.Remove(manga);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<MangaViewModel>>> GetAllPaging(GetManageMangaPagingRequest request)
        {
            //1. Select join
            var query = from m in _context.Mangas
                        join md in _context.MangaDetails on m.Id equals md.MangaId
                        //join im in _context.MangaImages on m.Id equals im.MangaId
                        //join mn in _context.MnTheloais on m.Id equals mn.MangaId
                        //join t in _context.Theloais on mn.TheLoaiId equals t.Id
                        join u in _context.InforSells on m.Id equals u.MangaId
                        join s in _context.AppUsers on u.UserId equals s.Id
                        select new { m, md, s };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.m.Ten.Contains(request.Keyword) || x.md.Tacgia.Contains(request.Keyword));
            //if (request.TheloaiId != null && request.TheloaiId != 0)
            //{
            //    query = query.Where(p => p.mn.TheLoaiId == request.TheloaiId);
            //}
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new MangaViewModel()
                {
                    mangaId = x.m.Id,
                    Ten = x.m.Ten,
                    Gia = x.m.Gia,
                    Giagoc = x.m.Giagoc,
                    LinkAnh = x.m.HinhAnh,
                    meta = x.m.Meta,
                    Anhien = x.m.Anhien
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<MangaViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<MangaViewModel>>(pagedResult);
        }
        public async Task<MangaViewModel> GetByIdWeb(string meta, int mangaId)
        {
            var mn = await _context.Mangas.FindAsync(mangaId);
            if (mn == null) throw new FMNException($"Cannot find a manga: {mangaId}");
            var mangadetail = await _context.MangaDetails.FirstOrDefaultAsync(x => x.MangaId == mangaId);
            var mangatheloai = await _context.MnTheloais.FirstOrDefaultAsync(x => x.MangaId == mangaId);
            var thongtinban = await _context.InforSells.FirstOrDefaultAsync(x => x.MangaId == mangaId);
            var categories = await (from c in _context.Theloais
                                        //join ct in _context.NgonnguMns on c.Id equals ct.Id
                                    join pic in _context.MnTheloais on c.Id equals pic.TheLoaiId
                                    where pic.MangaId == mangaId
                                    //&& ct.LanguageId == languageId
                                    select c.TenTL).ToListAsync();
            var discounts = await (from c in _context.Khuyenmais
                                   join pic in _context.KhuyenmaiMangas on c.Id equals pic.KhuyenmaiId
                                   where pic.MangaId == mangaId
                                   select c.Name).ToListAsync();
            var mangaViewModel = new MangaViewModel()
            {
                mangaId = mn.Id,
                Ten = mn.Ten,
                Giagoc = mn.Giagoc,
                Gia = mn.Gia,
                Mota = mangadetail != null ? mangadetail.Mota : null,
                SoLuong = mangadetail.SoLuong,
                TinhtrangMn = mangadetail.TinhtrangMn,
                Tacgia = mangadetail.Tacgia,
                NamXB = mangadetail.NamXB,
                Sotrang = mangadetail.Sotrang,
                TheloaiId = mangatheloai.TheLoaiId,
                UserId = thongtinban.UserId,
                LinkAnh = mn.HinhAnh,
                meta = mn.Meta,
                Anhien = mn.Anhien,
                Categories = categories,
                Discounts = discounts
            };
            return mangaViewModel;
        }

        public async Task<MangaViewModel> GetById(int mangaId)
        {
            var mn = await _context.Mangas.FindAsync(mangaId);

            var mangadetail = await _context.MangaDetails.FirstOrDefaultAsync(x => x.MangaId == mangaId);
            var mangatheloai = await _context.MnTheloais.FirstOrDefaultAsync(x => x.MangaId == mangaId);
            var thongtinban = await _context.InforSells.FirstOrDefaultAsync(x => x.MangaId == mangaId);
            var categories = await (from c in _context.Theloais
                                        //join ct in _context.NgonnguMns on c.Id equals ct.Id
                                    join pic in _context.MnTheloais on c.Id equals pic.TheLoaiId
                                    where pic.MangaId == mangaId
                                    //&& ct.LanguageId == languageId
                                    select c.TenTL).ToListAsync();
            var discounts = await (from c in _context.Khuyenmais
                                   join pic in _context.KhuyenmaiMangas on c.Id equals pic.KhuyenmaiId
                                   where pic.MangaId == mangaId
                                   select c.Name).ToListAsync();
            var mangaViewModel = new MangaViewModel()
            {
                mangaId = mn.Id,
                Ten = mn.Ten,
                Giagoc = mn.Giagoc,
                Gia = mn.Gia,
                Mota = mangadetail != null ? mangadetail.Mota : null,
                SoLuong = mangadetail.SoLuong,
                TinhtrangMn = mangadetail.TinhtrangMn,
                Tacgia = mangadetail.Tacgia,
                NamXB = mangadetail.NamXB,
                Sotrang = mangadetail.Sotrang,
                TheloaiId = mangatheloai.TheLoaiId,
                UserId = thongtinban.UserId,
                LinkAnh = mn.HinhAnh,
                meta = mn.Meta,
                Anhien = mn.Anhien,
                Categories = categories,
                Discounts = discounts
            };
            return mangaViewModel;
        }

        public async Task<MangaImageViewModel> GetImageById(int imageId)
        {
            var image = await _context.MangaImages.FindAsync(imageId);
            if (image == null)
                throw new FMNException($"Cannot find an image with id {imageId}");

            var viewModel = new MangaImageViewModel()
            {
                ChuThich = image.ChuThich,
                FileSize = image.FileSize,
                Id = image.Id,
                LinkAnh = image.LinkAnh,
                Anhmacdinh = image.Anhmacdinh,
                MangaId = image.MangaId,
                ThuTu = image.ThuTu
            };
            return viewModel;
        }

        public async Task<List<MangaImageViewModel>> GetListImages(int mamanga)
        {
            return await _context.MangaImages.Where(x => x.MangaId == mamanga)
                .Select(i => new MangaImageViewModel()
                {
                    ChuThich = i.ChuThich,
                    FileSize = i.FileSize,
                    Id = i.Id,
                    LinkAnh = i.LinkAnh,
                    Anhmacdinh = i.Anhmacdinh,
                    MangaId = i.MangaId,
                    ThuTu = i.ThuTu
                }).ToListAsync();
        }

        public async Task<int> RemoveImage(int imageId)
        {
            var mangaImage = await _context.MangaImages.FindAsync(imageId);
            if (mangaImage == null)
                throw new FMNException($"Cannot find an image with id {imageId}");
            _context.MangaImages.Remove(mangaImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(int mangaId, MangaUpdateRequest request)
        {
            var manga = await _context.Mangas.FindAsync(mangaId);
            var mangadetail = await _context.MangaDetails.FirstOrDefaultAsync(x => x.MangaId == mangaId);
            //var mangadetail = await _context.MangaDetails.FirstOrDefaultAsync(x => x.MangaId == request.Id);

            if (manga == null || mangadetail == null) throw new FMNException($"Cannot find a product with id: {request.Id}");

            manga.Ten = request.Ten;
            manga.Gia = request.Gia;
            //manga.HinhAnh = await this.SaveFile(request.HinhNho);
            manga.Anhien = request.Anhien;
            mangadetail.SoLuong = request.SoLuong;
            mangadetail.Mota = request.Mota;
            mangadetail.Tacgia = request.Tacgia;
            mangadetail.NamXB = request.NamXB;
            mangadetail.Sotrang = request.Sotrang;
            //Save image
            //if (request.HinhNho != null)
            //{
            //    var HinhNho = await _context.MangaImages.FirstOrDefaultAsync(h => h.Anhmacdinh == true && h.MangaId == request.Id);
            //    if (HinhNho != null)
            //    {
            //        HinhNho.FileSize = request.HinhNho.Length;
            //        HinhNho.LinkAnh = await this.SaveFile(request.HinhNho);
            //        _context.MangaImages.Update(HinhNho);
            //    }
            //}
            _context.Mangas.Update(manga);
            return await _context.SaveChangesAsync();
        }

        public async Task<ApiResult<bool>> UpdateGia(int MaManga, float NewGia)
        {
            var manga = await _context.Mangas.FindAsync(MaManga);
            if (manga == null) throw new FMNException($"Cannot find a product with id: {MaManga}");
            if (NewGia > 0)
            {
                manga.Gia = NewGia;
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<int> UpdateImage(int imageId, MangaImageUpdateRequest request)
        {
            var mangaImage = await _context.MangaImages.FindAsync(imageId);
            if (mangaImage == null)
                throw new FMNException($"Cannot find an image with id {imageId}");

            if (request.ImageFile != null)
            {
                mangaImage.LinkAnh = await this.SaveFile(request.ImageFile);
                mangaImage.FileSize = request.ImageFile.Length;
            }
            _context.MangaImages.Update(mangaImage);
            return await _context.SaveChangesAsync();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<List<MangaViewModel>> GetAll()
        {
            var query = from m in _context.Mangas
                        join md in _context.MangaDetails on m.Id equals md.MangaId
                        //join mn in _context.MnTheloais on m.Id equals mn.MangaId
                        //join t in _context.Theloais on mn.TheLoaiId equals t.Id
                        //join im in _context.MangaImages on m.Id equals im.Id
                        select new { m, md };

            var data = await query.Select(x => new MangaViewModel()
            {
                mangaId = x.m.Id,
                Ten = x.m.Ten,
                Gia = x.m.Gia,
                Giagoc = x.m.Giagoc,
                Anhien = x.m.Anhien,
                SoLuong = x.md.SoLuong,
                TinhtrangMn = x.md.TinhtrangMn,
                Tacgia = x.md.Tacgia,
                NamXB = x.md.NamXB,
                Sotrang = x.md.Sotrang,
                Mota = x.md.Mota,
                meta = x.m.Meta,
                LinkAnh = x.m.HinhAnh
                //TheloaiId = x.mn.TheLoaiId,
                //LinkAnh = x.im.LinkAnh
            }).Where(x => x.Anhien == true).ToListAsync();

            return data;
        }

        public async Task<PagedResult<MangaViewModel>> GetAllByCategoryId(string meta, GetPublicMangaPagingRequest request)
        {
            //1. Select join
            var query = from m in _context.Mangas
                        join md in _context.MangaDetails on m.Id equals md.MangaId
                        join mn in _context.MnTheloais on m.Id equals mn.MangaId
                        join t in _context.Theloais on mn.TheLoaiId equals t.Id
                        where mn.Theloai.Meta == meta
                        select new { m, md, mn };
            //2. filter
            if (request.TheloaiId != null && request.TheloaiId != 0)
            {
                query = query.Where(m => m.mn.TheLoaiId == request.TheloaiId);
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)

                .Select(x => new MangaViewModel()
                {
                    mangaId = x.m.Id,
                    Ten = x.m.Ten,
                    Gia = x.m.Gia,
                    meta = x.m.Meta,
                    Giagoc = x.m.Giagoc,
                    LinkAnh = x.m.HinhAnh,
                    Anhien = x.m.Anhien
                }).Where(x => x.Anhien == true).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<MangaViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<List<MangaViewModel>> GetMangaDiscount()
        {
            //1. Select join
            var query = from m in _context.Mangas
                        join md in _context.MangaDetails on m.Id equals md.MangaId
                        join mn in _context.KhuyenmaiMangas on m.Id equals mn.MangaId
                        join t in _context.Khuyenmais on mn.KhuyenmaiId equals t.Id
                        select new { m, md, mn };

            //3. Paging
            var data = await query.Select(x => new MangaViewModel()
            {
                mangaId = x.m.Id,
                Ten = x.m.Ten,
                Gia = x.m.Gia,
                Giagoc = x.m.Giagoc,
                Anhien = x.m.Anhien,
                SoLuong = x.md.SoLuong,
                TinhtrangMn = x.md.TinhtrangMn,
                Tacgia = x.md.Tacgia,
                NamXB = x.md.NamXB,
                Sotrang = x.md.Sotrang,
                meta = x.m.Meta,
                Mota = x.md.Mota,
                LinkAnh = x.m.HinhAnh
            }).Where(x => x.Anhien == true).ToListAsync();

            return data;
        }

        public async Task<ApiResult<bool>> CategoryAssign(int mangaId, CategoryAssignRequest request)
        {
            var manga = await _context.Mangas.FindAsync(mangaId);
            if (manga == null)
            {
                return new ApiErrorResult<bool>($"Sản phẩm với id {mangaId} không tồn tại");
            }
            foreach (var category in request.Categories)
            {
                var productInCategory = await _context.MnTheloais
                    .FirstOrDefaultAsync(x => x.TheLoaiId == int.Parse(category.Id)
                    && x.MangaId == mangaId);
                if (productInCategory != null && category.Selected == false)
                {
                    _context.MnTheloais.Remove(productInCategory);
                }
                else if (productInCategory == null && category.Selected)
                {
                    await _context.MnTheloais.AddAsync(new MnTheloai()
                    {
                        TheLoaiId = int.Parse(category.Id),
                        MangaId = mangaId
                    });
                }
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> DiscountManga(int mangaId, DiscountMnRequest request)
        {
            var manga = await _context.Mangas.FindAsync(mangaId);
            if (manga == null)
            {
                return new ApiErrorResult<bool>($"Sản phẩm với id {mangaId} không tồn tại");
            }
            foreach (var discountt in request.Discounts)
            {
                var productInCategory = await _context.KhuyenmaiMangas
                    .FirstOrDefaultAsync(x => x.KhuyenmaiId == int.Parse(discountt.Id)
                    && x.MangaId == mangaId);
                var discount = await _context.Khuyenmais.FindAsync(int.Parse(discountt.Id));
                if (productInCategory == null && discountt.Selected)
                {
                    var khuyenmai = await _context.Khuyenmais.FindAsync(int.Parse(discountt.Id));

                    if (DateTime.Now >= discount.FromDate && DateTime.Now <= discount.ToDate)
                    {
                        await _context.KhuyenmaiMangas.AddAsync(new KhuyenmaiManga()
                        {
                            KhuyenmaiId = int.Parse(discountt.Id),
                            MangaId = mangaId
                        });

                        float giamgia = (float)khuyenmai.DiscountAmount;
                        float gia = (float)(manga.Gia - khuyenmai.DiscountAmount);
                        manga.Gia = gia;
                    }
                    else
                    {
                        manga.Gia = manga.Giagoc;
                        return new ApiErrorResult<bool>($"Ưu đãi không còn hiệu lực");
                    }
                }
                else if (productInCategory != null && discountt.Selected == false)
                {
                    var khuyenmai = await _context.Khuyenmais.FindAsync(int.Parse(discountt.Id));

                    _context.KhuyenmaiMangas.Remove(productInCategory);
                    float giamgia = (float)khuyenmai.DiscountAmount;
                    float gia = (float)(manga.Gia + khuyenmai.DiscountAmount);
                    manga.Gia = gia;

                }
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<PagedResult<MangaViewModel>> GetMangaDiscountPaging(GetManageMangaPagingRequest request)
        {
            //1. Select join
            var query = from m in _context.Mangas
                        join md in _context.MangaDetails on m.Id equals md.MangaId
                        join mn in _context.KhuyenmaiMangas on m.Id equals mn.MangaId
                        join t in _context.Khuyenmais on mn.KhuyenmaiId equals t.Id
                        select new { m, md, mn };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.m.Ten.Contains(request.Keyword));
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)

                .Select(x => new MangaViewModel()
                {
                    mangaId = x.m.Id,
                    Ten = x.m.Ten,
                    Gia = x.m.Gia,
                    meta = x.m.Meta,
                    Giagoc = x.m.Giagoc,
                    LinkAnh = x.m.HinhAnh,
                    Anhien = x.m.Anhien
                }).Where(x => x.Anhien == true).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<MangaViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<List<string>> ListName(string keyword)
        {
            return await _context.Mangas.Where(m => m.Ten.Contains(keyword)).Select(n => n.Ten).ToListAsync();
        }
    }
}