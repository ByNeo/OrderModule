using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventBus.Core.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Order.API.Application.IntegrationEvents.Events;
using Ordering.Domain.Models;
using Ordering.Infrastructure.Services.Interface;

namespace Order.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        #region Fields

        private readonly IEventBus _eventBus;
        private readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> _logger;

        #endregion


        #region Constructors

        public OrdersController(
            IEventBus eventBus,
            IOrderService orderService,
            ILogger<OrdersController> logger)
        {
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion


        #region API

        [HttpGet]
        [Route("getorders")]
        public async Task<List<Ordering.Domain.Data.Entities.Order>> GetOrdersAsync()
        {
            _logger.LogInformation($"GetOrdersAsync! : {DateTime.UtcNow}");

            var orders = await _orderService.GetOrdersAsync();


            return orders;
        }


        [HttpPost]
        [Route("createorder")]
        public async Task<Result<Ordering.Domain.Data.Entities.Order>> CreateOrderAsync(Ordering.Domain.Data.Entities.Order order)
        {
            _logger.LogInformation($"CreateOrderAsync! : {DateTime.UtcNow}");

            var result = await _orderService.CreateOrderAsync(order);


            // generate event data for publish to event bus
            var @event = new OrderCreatedIntegrationEvent(result.Data.Id);


            // public order created event to event bus
            _eventBus.Publish(@event);

            return result;
        }


        #endregion
    }
}