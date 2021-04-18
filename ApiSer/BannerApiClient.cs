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
using ViewModels.Catalog.Banner;
using ViewModels.Common;

namespace ApiSer
{
    public class BannerApiClient : BaseApiClient, IBannerApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BannerApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Add(BannerCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();
            if (request.ImageFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ImageFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ImageFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "imageFile", request.ImageFile.FileName);
            }
            requestContent.Add(new StringContent(request.ThuTu.ToString()), "thuTu");
            requestContent.Add(new StringContent(request.Tieude.ToString()), "tieude");
            requestContent.Add(new StringContent(request.Noidung.ToString()), "noidung");
            requestContent.Add(new StringContent(request.Meta.ToString()), "meta");
            requestContent.Add(new StringContent(request.Anhien.ToString()), "anhien");


            var response = await client.PostAsync($"/api/banner/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<BannerViewModel>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync("/api/banner");
            var body = await response.Content.ReadAsStringAsync();
            var mangas = JsonConvert.DeserializeObject<List<BannerViewModel>>(body);
            return mangas;
        }

        public async Task<ApiResult<BannerViewModel>> GetById(int idBanner)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync($"/api/banner/{idBanner}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<BannerViewModel>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<BannerViewModel>>(body);
        }

        public async Task<ApiResult<bool>> Remove(int idBanner)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/banner/{idBanner}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<bool> Update(int bannerId, BannerUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/banner/{bannerId}", httpContent);
            return response.IsSuccessStatusCode;
        }
    }
}