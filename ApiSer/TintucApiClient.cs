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
using ViewModels.Catalog.Tintuc;
using ViewModels.Common;

namespace ApiSer
{
    public class TintucApiClient : BaseApiClient, ITintucApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TintucApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Create(TintucCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();
            if (request.Hinh != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.Hinh.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.Hinh.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "hinh", request.Hinh.FileName);
            }
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.TieuDe) ? "" : request.TieuDe.ToString()), "tieuDe");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.NoiDung) ? "" : request.NoiDung.ToString()), "noiDung");
            requestContent.Add(new StringContent(request.Meta.ToString()), "meta");
            requestContent.Add(new StringContent(request.NoiDungTomTat.ToString()), "noiDungTomTat");
            requestContent.Add(new StringContent(request.Anhien.ToString()), "anhien");

            var response = await client.PostAsync($"/api/news/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<ApiResult<bool>> Detele(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/news/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<ApiResult<PagedResult<TintucVM>>> GetAll(GetNewsPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/news/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var news = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<TintucVM>>>(body);
            return news;
        }

        public async Task<TintucVM> GetById(int id)
        {
            var data = await GetAsync<TintucVM>($"/api/news/{id}");
            return data;
        }

        public async Task<bool> Update(int id, TintucUpdate request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.TieuDe) ? "" : request.TieuDe.ToString()), "tieuDe");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.NoiDung) ? "" : request.NoiDung.ToString()), "noiDung");
            requestContent.Add(new StringContent(request.Meta.ToString()), "meta");
            requestContent.Add(new StringContent(request.NoiDungTomTat.ToString()), "noiDungTomTat");
            requestContent.Add(new StringContent(request.AnHien.ToString()), "AnHien");
            var response = await client.PutAsync($"/api/news/{id}", requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}