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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly OrderContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public OrderDetailRepository(OrderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public OrderDetail Add(OrderDetail orderDetail)
        {
            return _context.OrderDetails.Add(orderDetail).Entity;
        }

        public async Task<OrderDetail> GetAsync(int orderDetailId)
        {
            var orderDetails = await _context.OrderDetails.FindAsync(orderDetailId);


            return orderDetails;
        }

        public void Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }
    }
}
