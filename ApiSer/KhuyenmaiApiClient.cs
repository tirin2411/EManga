using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Utilities.Constants;
using ViewModels.Catalog.Khuyenmai;
using ViewModels.Common;

namespace ApiSer
{
    public class KhuyenmaiApiClient : BaseApiClient, IKhuyenmaiApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public KhuyenmaiApiClient(IHttpClientFactory httpClientFactory,
                IConfiguration configuration,
                IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> Create(KhuyenmaiCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();
            
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(request.FromDate.ToString()), "fromDate");
            requestContent.Add(new StringContent(request.ToDate.ToString()), "toDate");
            requestContent.Add(new StringContent(request.ApplyForAll.ToString()), "applyForAll");
            requestContent.Add(new StringContent(request.DiscountPercent.ToString()), "discountPercent");
            requestContent.Add(new StringContent(request.DiscountAmount.ToString()), "discountAmount");
            requestContent.Add(new StringContent(request.Status.ToString()), "status");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.CouponCode) ? "" : request.CouponCode.ToString()), "couponCode");
            //requestContent.Add(new StringContent(request.MaximumDiscountedQuantity.ToString()), "maximumDiscountedQuantity");

            var response = await client.PostAsync($"/api/discounts/", requestContent);
            return response.IsSuccessStatusCode;
        }

        

        public async Task<PagedResult<KhuyenmaiVM>> GetAll(GetDiscountPagingRequest request)
        {
            var data = await GetAsync<PagedResult<KhuyenmaiVM>>
                ($"/api/discounts/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}");
            return data;
        }

        public async Task<KhuyenmaiVM> GetById(int id)
        {
            var data = await GetAsync<KhuyenmaiVM>($"/api/discounts/{id}");

            return data;
        }

        public async Task<bool> Update(int id, KhuyenmaiUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(request.ToDate.ToString()), "toDate");
            requestContent.Add(new StringContent(request.ApplyForAll.ToString()), "applyForAll");
            requestContent.Add(new StringContent(request.DiscountPercent.ToString()), "discountPercent");
            requestContent.Add(new StringContent(request.DiscountAmount.ToString()), "discountAmount");
            requestContent.Add(new StringContent(request.Status.ToString()), "status");
            //requestContent.Add(new StringContent(request.MaximumDiscountedQuantity.ToString()), "maximumDiscountedQuantity");

            var response = await client.PutAsync($"/api/discounts/{id}", requestContent);
            return response.IsSuccessStatusCode;
        }
        public async Task<ApiResult<bool>> Detele(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.DeleteAsync($"/api/discounts/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<List<KhuyenmaiVM>> GetAllDiscount()
        {
            return await GetListAsync<KhuyenmaiVM>("/api/discounts/getdiscount");
        }
    }
}
