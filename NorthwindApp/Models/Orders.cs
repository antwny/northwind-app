using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NorthwindApp.Models
{
    public class Orders
    {

        [DisplayName("ID del Pedido")]
        public int OrderID { get; set; }
        public Customers Customers { get; set; }
        [DisplayName("Fecha del Pedido")]
        public DateTime? OrderDate { get; set; }
        [DisplayName("Nombre del Envío")]
        public string ShipName { get; set; }
        [DisplayName("Dirección del Envío")]
        public string ShipAddress { get; set; }
        [DisplayName("Ciudad del Envío")]
        public string ShipCity { get; set; }
        [DisplayName("Código Postal del Envío")]
        public string ShipPostalCode { get; set; }
        [DisplayName("País del Envío")]
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