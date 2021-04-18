using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ViewModels.System.Locals;

namespace ApiSer
{
    public class LocalApiClient : ILocalApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocalApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<ProvinceVM>> GetProvince()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync("/api/locals/getprovince");
            var body = await response.Content.ReadAsStringAsync();
            var locals = JsonConvert.DeserializeObject<List<ProvinceVM>>(body);
            return locals;
        }

        public async Task<List<DistrictVM>> GetDistrict(int? provinceId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/locals/getdistrict/{provinceId}");
            var body = await response.Content.ReadAsStringAsync();
            var locals = JsonConvert.DeserializeObject<List<DistrictVM>>(body);
            return locals;
        }
        
        public async Task<List<WardVM>> GetWard(int? districtId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/locals/getward/{districtId}");
            var body = await response.Content.ReadAsStringAsync();
            var locals = JsonConvert.DeserializeObject<List<WardVM>>(body);
            return locals;
        }

        public async Task<ProvinceVM> GetProvinceId(int? provinceId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/locals/getprovinceid/{provinceId}");
            var body = await response.Content.ReadAsStringAsync();
            var locals = JsonConvert.DeserializeObject<ProvinceVM>(body);
            return locals;
        }

        public async Task<DistrictVM> GetDistrictId(int? districtId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/locals/getdistrictid/{districtId}");
            var body = await response.Content.ReadAsStringAsync();
            var locals = JsonConvert.DeserializeObject<DistrictVM>(body);
            return locals;
        }

        public async Task<WardVM> GetWardId(int? wardId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/locals/getwardid/{wardId}");
            var body = await response.Content.ReadAsStringAsync();
            var locals = JsonConvert.DeserializeObject<WardVM>(body);
            return locals;
        }
    }
}
