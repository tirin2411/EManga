using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Common;
using ViewModels.Shipment;

namespace ApiSer
{
    public class PriceAndDestinationApiClient : BaseApiClient, IPriceAndDestinationApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PriceAndDestinationApiClient(IHttpClientFactory httpClientFactory,
                IConfiguration configuration,
                IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> Create(ShippingPriceRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/priceanddestinations", httpContent);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> Update(int id, ShippingPriceUpdate request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/priceanddestinations/{id}", httpContent);
            return response.IsSuccessStatusCode;
        }
        public async Task<ApiResult<bool>> Detele(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.DeleteAsync($"/api/priceanddestinations/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<List<PriceAndDestinationVM>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync("/api/priceanddestinations");
            var body = await response.Content.ReadAsStringAsync();
            var shippings = JsonConvert.DeserializeObject<List<PriceAndDestinationVM>>(body);
            return shippings;
        }

        public async Task<PriceAndDestinationVM> GetById(int id)
        {
            var data = await GetAsync<PriceAndDestinationVM>($"/api/priceanddestinations/{id}");
            return data;
        }

        public async Task<PriceAndDestinationVM> GetByProvinceId(int? provinceId)
        {
            //var data = await GetAsync<PriceAndDestinationVM>($"/api/priceanddestinations/getbyprovince/{provinceId}");
            //return data;
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/priceanddestinations/getbyprovince/{provinceId}");
            var body = await response.Content.ReadAsStringAsync();
            var locals = JsonConvert.DeserializeObject<PriceAndDestinationVM>(body);
            return locals;
        }
    }
}
