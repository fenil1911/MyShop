using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Services
{
    public class OrderService : IOrderService
    {
        IRepository<Order> orderContext;
        public OrderService(IRepository<Order> OrderContext)
        {
            this.orderContext = OrderContext;
        }
        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems)
        {
            foreach (var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.Id,
                    Image = item.Image,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                });
            }
            if (orderContext.Collection().Count() > 0)
            {
                var cnt = orderContext.Collection().Count();
                int lastId = cnt;
                lastId++;
                baseOrder.OrderViewId = "ORD" + lastId.ToString().PadLeft(4, '0'); 
            }
            else
            {
                int lastId = 0;
                lastId++;
                baseOrder.OrderViewId = "ORD" + lastId.ToString().PadLeft(4, '0');
            }
            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }

        public List<Order> GetOrderList()
        {
            return orderContext.Collection().OrderBy(x => x.OrderViewId).ToList();
        }

        public Order GetOrder(string Id)
        {
            return orderContext.Find(Id);
        }

        public void UpdateOrder(Order updateOrder)
        {
            orderContext.Update(updateOrder);
            orderContext.Commit();
        }
    }
}