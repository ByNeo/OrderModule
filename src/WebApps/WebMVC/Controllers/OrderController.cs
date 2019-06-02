using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class OrderController : Controller
    {
        private IOrderingService _orderService;


        public OrderController(IOrderingService orderService)
        {
            _orderService = orderService;
        }


        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetOrdersAsync();


            return View(orders);
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var order = await _orderService.CreateOrderAsync(model);


                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }


            return View("Create", model);
        }
    }
}