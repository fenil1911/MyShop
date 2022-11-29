using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderManagerController : Controller
    {
        IOrderService orderService;

        public OrderManagerController(IOrderService OrderService)
        {
            this.orderService = OrderService;

        }

        // GET: OrderManager
        public ActionResult Index()
        {
            var orders = orderService.GetOrderList();

            return View(orders);
        }

        public ActionResult UpdateOrder(string Id)
        {
            ViewBag.StatusList = new List<String>()
            {
                "Order Created",
                "Payment Processed",
                "Order Shipped",
                "Order Complete"
            };
            Order order = orderService.GetOrder(Id);
            return View(order);
        }

        [HttpPost]
        public ActionResult UpdateOrder(Order UpdateOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);
            order.OrderStatus = UpdateOrder.OrderStatus;
            orderService.UpdateOrder(order);
            return RedirectToAction("Index");
        }
    }
}