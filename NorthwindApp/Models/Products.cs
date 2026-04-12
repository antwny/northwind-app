using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindApp.Models
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public Products()
        {
            ProductID = 0;
            ProductName = string.Empty;
        }

        public Products(int productid)
        {
            ProductID = productid;

        }

        public Products(int productid, string productname)
        {
            ProductID = productid;
            ProductName = productname;

        }
    }
}