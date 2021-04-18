using ViewModels.Catalog.MangaImages;
using ViewModels.Catalog.Mangas;
using ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Catalog.Mangas
{
    public interface IMangaService
    {
        Task<int> Create(MangaCreateRequest request);

        Task<int> Update(int mangaId, MangaUpdateRequest request);

        Task<ApiResult<bool>> Detele(int id);

        Task<MangaViewModel> GetById(int mangaId);
        Task<MangaViewModel> GetByIdWeb(string meta, int mangaId);


        //Task<ApiResult<MangaViewModel>> GetByTL(int tlId);

        Task<ApiResult<bool>> UpdateGia(int MaManga, float NewGia);

        Task<ApiResult<PagedResult<MangaViewModel>>> GetAllPaging(GetManageMangaPagingRequest request);

        Task<int> AddImage(int mamanga, MangaImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, MangaImageUpdateRequest request);

        Task<MangaImageViewModel> GetImageById(int imageId);

        Task<List<MangaImageViewModel>> GetListImages(int mamanga);

        Task<PagedResult<MangaViewModel>> GetAllByCategoryId(string meta,GetPublicMangaPagingRequest request);
        Task<PagedResult<MangaViewModel>> GetMangaDiscountPaging(GetManageMangaPagingRequest request);
        Task<List<MangaViewModel>> GetMangaDiscount();

        Task<List<MangaViewModel>> GetAll();
        Task<ApiResult<bool>> CategoryAssign(int mangaId, CategoryAssignRequest request);
        Task<ApiResult<bool>> DiscountManga(int mangaId, DiscountMnRequest request);
        Task<List<string>> ListName(string keyword);
    }
}