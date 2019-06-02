using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebMVC.Infrastructure;
using WebMVC.Models;
using WebMVC.ViewModels;

namespace WebMVC.Services
{
    public class OrderingService : IOrderingService
    {
        #region Fields

        private HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;
        private readonly IOptions<AppSettings> _settings;

        #endregion


        #region Constructors

        public OrderingService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;

            _remoteServiceBaseUrl = $"{settings.Value.OrderURL}/api/v1/orders";
        }

        #endregion


        public async Task<List<Order>> GetOrdersAsync()
        {
            var uri = API.Order.GetOrders(_remoteServiceBaseUrl);

            var response = await _httpClient.GetAsync(uri);

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("GetOrdersAsync -> InternalServerError");
            }


            return await response.Content.ReadAsAsync<List<Order>>();
        }


        public async Task<Result<Order>> CreateOrderAsync(Order order)
        {
            var uri = API.Order.CreateOrder(_remoteServiceBaseUrl);
            var orderContent = new StringContent(JsonConvert.SerializeObject(order), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, orderContent);

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("CreateOrderAsync -> InternalServerError");
            }


            return await response.Content.ReadAsAsync<Result<Order>>();
        }
    }
}
