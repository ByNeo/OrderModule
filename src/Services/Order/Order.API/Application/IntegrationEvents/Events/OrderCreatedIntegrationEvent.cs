using EventBus.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Application.IntegrationEvents.Events
{
    public class OrderCreatedIntegrationEvent : IntegrationEvent
    {
        public long OrderId { get; set; }

        public OrderCreatedIntegrationEvent(long orderId)
            => OrderId = orderId;
    }
}
