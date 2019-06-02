using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Data.Entities;
using Ordering.Domain.Data.Interface;
using Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public OrderRepository(OrderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<List<Order>> GetAllAsync()
        {
            var orders = await _context.Orders.ToListAsync();


            return orders;
        }

        public async Task<Order> GetAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                await _context.Entry(order)
                    .Collection(i => i.OrderDetails).LoadAsync();
            }

            return order;
        }


        public Order Add(Order order)
        {
            return _context.Orders.Add(order).Entity;
        }
    }
}
