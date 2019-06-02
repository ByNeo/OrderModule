using Ordering.Domain.Data.Entities;
using Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Data.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetOrdersAsync();

        Task<Order> GetAsync(int orderId);

        Order Add(Order order);
    }
}
