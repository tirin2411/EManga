using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Utilities.Constants;
using ViewModels.Catalog.Mangas;
using ViewModels.Common;

namespace ApiSer
{
    public class MangaApiClient : BaseApiClient, IMangaApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MangaApiClient(IHttpClientFactory httpClientFactory,
                IConfiguration configuration,
                IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<PagedResult<MangaViewModel>> GetAllByCategoryId(GetPublicMangaPagingRequest request)
        {
            var data = await GetAsync<PagedResult<MangaViewModel>>
                ($"/api/mangas/getallbycategory?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&theloaiId={request.TheloaiId}");
            return data;
        }
        public async Task<bool> Create(MangaCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();
            if (request.HinhNho != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.HinhNho.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.HinhNho.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "HinhNho", request.HinhNho.FileName);
            }
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Ten) ? "" : request.Ten.ToString()), "ten");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Meta) ? "" : request.Meta.ToString()), "meta");
            requestContent.Add(new StringContent(request.Gia.ToString()), "gia");
            requestContent.Add(new StringContent(request.Anhien.ToString()), "anhien");
            requestContent.Add(new StringContent(request.NgonnguId.ToString()), "ngonnguId");
            requestContent.Add(new StringContent(request.SoLuong.ToString()), "soLuong");
            requestContent.Add(new StringContent(request.TinhtrangMn.ToString()), "tinhtrangMn");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Mota) ? "" : request.Mota.ToString()), "mota");
            requestContent.Add(new StringContent(request.Tacgia.ToString()), "tacgia");
            requestContent.Add(new StringContent(request.NamXB.ToString()), "namXB");
            requestContent.Add(new StringContent(request.Sotrang.ToString()), "sotrang");
            requestContent.Add(new StringContent(request.TheloaiId.ToString()), "theloaiId");
            requestContent.Add(new StringContent(request.UserId.ToString()), "userId");

            var response = await client.PostAsync($"/api/mangas/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<ApiResult<bool>> Detele(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.DeleteAsync($"/api/mangas/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<List<MangaViewModel>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync("/api/mangas/getManga");
            var body = await response.Content.ReadAsStringAsync();
            var mangas = JsonConvert.DeserializeObject<List<MangaViewModel>>(body);
            return mangas;
        }

        

        public async Task<ApiResult<PagedResult<MangaViewModel>>> GetAllPaging(GetManageMangaPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/mangas/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var mangas = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<MangaViewModel>>>(body);
            return mangas;
        }

        public async Task<MangaViewModel> GetById(int mangaId)
        {
            var data = await GetAsync<MangaViewModel>($"/api/mangas/{mangaId}");

            return data;
        }

        public async Task<bool> Update(int mangaId, MangaUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Ten) ? "" : request.Ten.ToString()), "ten");
            requestContent.Add(new StringContent(request.Gia.ToString()), "gia");
            requestContent.Add(new StringContent(request.Anhien.ToString()), "anhien");
            requestContent.Add(new StringContent(request.SoLuong.ToString()), "soLuong");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Mota) ? "" : request.Mota.ToString()), "mota");
            requestContent.Add(new StringContent(request.Tacgia.ToString()), "tacgia");
            requestContent.Add(new StringContent(request.NamXB.ToString()), "namXB");
            requestContent.Add(new StringContent(request.Sotrang.ToString()), "sotrang");
            var response = await client.PutAsync($"/api/mangas/{mangaId}", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<ApiResult<bool>> CategoryAssign(int mangaId, CategoryAssignRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/mangas/{mangaId}/categories", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }
        public async Task<ApiResult<bool>> DiscountManga(int mangaId, DiscountMnRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/mangas/{mangaId}/discount", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }

        public async Task<List<MangaViewModel>> GetMangaDiscount()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync("/api/mangas/getMangaDiscount");
            var body = await response.Content.ReadAsStringAsync();
            var mangas = JsonConvert.DeserializeObject<List<MangaViewModel>>(body);
            return mangas;
        }

        public async Task<PagedResult<MangaViewModel>> GetMangaDiscountPaging(GetManageMangaPagingRequest request)
        {
            var data = await GetAsync<PagedResult<MangaViewModel>>
               ($"/api/mangas/mangadiscountpaging?pageIndex={request.PageIndex}" +
               $"&pageSize={request.PageSize}" +
               $"&keyword ={ request.Keyword}");
            return data;
        }
    }
}