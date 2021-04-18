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
using ViewModels.Catalog.Menus;
using ViewModels.Common;

namespace ApiSer
{
    public class MenuApiClient : IMenuApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MenuApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<int>> Create(MenuCreate request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/menus", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<int>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<int>>(result);
        }

        public async Task<ApiResult<bool>> Detele(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/menus/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<List<MenuViewModel>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync("/api/menus/getmenu");
            var body = await response.Content.ReadAsStringAsync();
            var mangas = JsonConvert.DeserializeObject<List<MenuViewModel>>(body);
            return mangas;
        }

        public async Task<List<MenuItemVM>> GetAllItem(int? menuId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/menus/getmenuitem/{menuId}");
            var body = await response.Content.ReadAsStringAsync();
            var mangas = JsonConvert.DeserializeObject<List<MenuItemVM>>(body);
            return mangas;
        }

        public async Task<ApiResult<MenuViewModel>> GetById(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync($"/api/menus/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<MenuViewModel>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<MenuViewModel>>(body);
        }

        public async Task<ApiResult<MenuItemVM>> GetItemById(int id, int menuId)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync($"/api/menus/{id}/{menuId}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<MenuItemVM>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<MenuItemVM>>(body);
        }

        public async Task<ApiResult<bool>> Update(int id, MenuUpdate request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/menus/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }
    }
}