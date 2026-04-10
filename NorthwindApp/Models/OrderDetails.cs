using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindApp.Models
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public Products Products { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public OrderDetails()
        {
            OrderID = 0;
            Products = new Products();
            UnitPrice = 0;
            Quantity = 0;
            Discount = 0;
        }


    }
}