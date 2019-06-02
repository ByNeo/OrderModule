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


        public IActionResult Index()
        {
            var orders = new List<Order>();


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


                    //Redirect to historic list.
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "It was not possible to create a new order, please try later on. (Business Msg Due to Circuit-Breaker)");
            }


            return View("Create", model);
        }
    }
}