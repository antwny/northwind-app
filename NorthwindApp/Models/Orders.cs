using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindApp.Models
{
    public class Orders
    {


        public int OrderID { get; set; }
        public Customers Customers { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public Orders()
        {
            OrderID = 0;
            Customers = new Customers();
            OrderDate = DateTime.MinValue;
            ShipName = string.Empty;
            ShipAddress = string.Empty;
            ShipCity = string.Empty;
            ShipPostalCode = string.Empty;
            ShipCountry = string.Empty;
        }

        public Orders(int orderID, Customers customers, DateTime orderDate, string shipName, string shipAddress, string shipcity, string shippostalcode, string shipcountry)
        {
            OrderID = orderID;
            Customers = customers;
            OrderDate = orderDate;
            ShipName = shipName;
            ShipAddress = shipAddress;
            ShipCity = shipcity;
            ShipPostalCode = shippostalcode;
            ShipCountry = shipcountry;
        }


    }
}