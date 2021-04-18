using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Catalog.Mangas;
using ViewModels.Common;

namespace ApiSer
{
    public interface IMangaApiClient
    {
        Task<List<MangaViewModel>> GetAll();
        Task<List<MangaViewModel>> GetMangaDiscount();
        Task<PagedResult<MangaViewModel>> GetMangaDiscountPaging(GetManageMangaPagingRequest request);
        Task<ApiResult<PagedResult<MangaViewModel>>> GetAllPaging(GetManageMangaPagingRequest request);
        Task<PagedResult<MangaViewModel>> GetAllByCategoryId(GetPublicMangaPagingRequest request);

        Task<MangaViewModel> GetById(int mangaId);

        Task<bool> Create(MangaCreateRequest request);

        Task<bool> Update(int mangaId, MangaUpdateRequest request);

        Task<ApiResult<bool>> Detele(int id);
        Task<ApiResult<bool>> CategoryAssign(int mangaId, CategoryAssignRequest request);
        Task<ApiResult<bool>> DiscountManga(int mangaId, DiscountMnRequest request);


    }
}