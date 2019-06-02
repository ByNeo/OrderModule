using Microsoft.Extensions.Logging;
using Ordering.Domain.Data.Entities;
using Ordering.Domain.Data.Interface;
using Ordering.Domain.Models;
using Ordering.Infrastructure.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        #region Fields

        private readonly IOrderRepository _orderRepository;
        private readonly ILogger _logger;

        #endregion


        #region Constructors

        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion


        public async Task<List<Order>> GetOrdersAsync()
        {
            var _orders = await _orderRepository.GetOrdersAsync();


            return _orders;
        }

        public async Task<Result<Order>> CreateOrderAsync(Order order)
        {
            var result = new Result<Order>();

            try
            {
                var _order = _orderRepository.Add(order);

                await _orderRepository.UnitOfWork.SaveEntitiesAsync();

                result.IsSuccessful = true;
                result.Data = _order;
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.Message = ex.Message;
            }


            return result;
        }
    }
}
