using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;
using WebMVC.ViewModels;

namespace WebMVC.Services
{
    public interface IOrderingService
    {
        Task<Result<Order>> CreateOrderAsync(Order order);
    }
}
