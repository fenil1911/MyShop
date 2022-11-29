using System.Collections.Generic;

namespace MyShop.Core.Models
{
    public class Order : BaseEntity
    {
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string OrderStatus { get; set; }

        //thank you order id for client side
        public string OrderViewId { get; set; }
        public string OrderView { get; set; }


        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}