using Ordering.Domain.Data.Entities;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Services.Interface
{
    public interface IOrderService
    {
        Task<Result<Order>> CreateOrderAsync(Order order);
    }
}
