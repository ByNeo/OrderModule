using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Data.Interface;
using Ordering.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Order.API.Application.DomainEventHandlers.OrderStartedEvent
{
    public class SendEmailToCustomerWhenOrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILoggerFactory _logger;


        public SendEmailToCustomerWhenOrderStartedDomainEventHandler(
            IOrderRepository orderRepository,
            ILoggerFactory logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



        public async Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            //TBD - Send email logic
            _logger.CreateLogger<OrderStartedDomainEvent>()
                .LogTrace("Order with Id: {OrderId} has been successfully.", notification.Order.Id);


        }
    }
}
