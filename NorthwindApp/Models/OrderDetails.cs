using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NorthwindApp.Models
{
    public class OrderDetails
    {
        public Orders Orders { get; set; }
        public Products Products { get; set; }
        [Range(0.01, 99999.99, ErrorMessage = "El precio debe estar entre 0.01 y 99999.99")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public OrderDetails()
        {
            Orders = new Orders();
            Products = new Products();
            UnitPrice = 0;
            Quantity = 0;
            Discount = 0;
        }

        public OrderDetails(Orders order, Products products, decimal unitPrice, short quantity, float discount)
        {
            Orders = order;
            Products = products;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Discount = discount;
        }


    }
}