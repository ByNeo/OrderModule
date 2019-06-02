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
        Order Add(Order order);

        void Update(Order order);

        Task<Order> GetAsync(int orderId);
    }
}
