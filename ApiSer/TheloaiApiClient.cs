using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Theloai;
using ViewModels.Common;

namespace ApiSer
{
    public class TheloaiApiClient : BaseApiClient, ITheloaiApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TheloaiApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<int>> Create(TheloaiCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/categorys", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<int>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<int>>(result);
        }

        public async Task<ApiResult<bool>> Detele(int Id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/categorys/{Id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<List<TheloaiViewModel>> GetAll()
        {

            return await GetListAsync<TheloaiViewModel>("/api/categorys/getcategory");
            
        }
        public async Task<List<TheloaiViewModel>> GetAllAd()
        {

            return await GetListAsync<TheloaiViewModel>("/api/categorys/getcategoryad");

        }
        public async Task<TheloaiViewModel> GetById(int idTL)
        {
            return await GetAsync<TheloaiViewModel>($"/api/categorys/{idTL}");
        }

        public async Task<List<NgonnguVM>> GetListNgonngu()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync("/api/categorys/getlanguage");
            var body = await response.Content.ReadAsStringAsync();
            var mangas = JsonConvert.DeserializeObject<List<NgonnguVM>>(body);
            return mangas;
        }

        public async Task<ApiResult<bool>> Update(int idTL, TheloaiUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/categorys/{idTL}", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }
    }
}