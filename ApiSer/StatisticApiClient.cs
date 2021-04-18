using Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiSer
{
    public class StatisticApiClient : IStatisticApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StatisticApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IEnumerable<RevenueStatisticViewModel>> GetRevenueStatistic(string fromDate, string toDate)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/statistic/getrevenue?fromDate={fromDate}&toDate={toDate}");
            var body = await response.Content.ReadAsStringAsync();
            var mangas = JsonConvert.DeserializeObject<List<RevenueStatisticViewModel>>(body);
            return mangas;
        }
    }
}
