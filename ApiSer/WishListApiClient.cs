using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ViewModels.WishList;

namespace ApiSer
{
    public class WishListApiClient : BaseApiClient, IWishListApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WishListApiClient(IHttpClientFactory httpClientFactory,
                IConfiguration configuration,
                IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<WishListItemVM>> GetListMnByIdUser(Guid userId)
        {
            //var data = await GetAsync<List<WishListItemVM>>
            //    ($"/api/wishlists/getlistmn/{userId}");
            //return data;
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/wishlists/getlistmn/{userId}");
            var body = await response.Content.ReadAsStringAsync();
            var mangas = JsonConvert.DeserializeObject<List<WishListItemVM>>(body);
            return mangas;
        }
    }
}
