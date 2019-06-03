using MediatR;
using Ordering.Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Events
{
    /// <summary>
    /// Event used when an order is created
    /// </summary>
    public class OrderStartedDomainEvent : INotification
    {
        public Order Order { get; }

        public OrderStartedDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
