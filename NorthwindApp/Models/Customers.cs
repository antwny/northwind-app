using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindApp.Models
{
    
    public class Customers
    {
        [DisplayName("ID del Cliente")]
        public string CustomerID { get; set; }
        [DisplayName("Nombre de empresa")]
        public string CompanyName { get; set; }
        [DisplayName("Nombre de contacto")]
        public string ContactName { get; set; }
        [DisplayName("Título de contacto")]
        public string ContactTitle { get; set; }
        [DisplayName("Dirección")]
        public string Address { get; set; }
        [DisplayName("Ciudad")]
        public string City { get; set; }
        public string Region { get; set; }
        [DisplayName("Código Postal")]
        public string PostalCode { get; set; }
        [DisplayName("País")]
        public string Country { get; set; }
        [DisplayName("Telefono")]
        public string Phone { get; set; }
        public string Fax { get; set; }


        public Customers(string customerID, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            CustomerID = customerID;
            CompanyName = companyName;
            ContactName = contactName;
            ContactTitle = contactTitle;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            Fax = fax;
        }

        public Customers()
        {
            CustomerID = string.Empty;
            CompanyName = string.Empty;
            ContactName = string.Empty;
            ContactTitle = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            Region = string.Empty;
            PostalCode = string.Empty;
            Country = string.Empty;
            Phone = string.Empty;
            Fax = string.Empty;
        }

        public Customers(string customerID)
        {
            CustomerID = customerID;
        }
    }
}