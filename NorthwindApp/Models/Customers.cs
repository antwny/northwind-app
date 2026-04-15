using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindApp.Models
{
    public class Customers
    {
        [Required(ErrorMessage = "El ID es obligatorio")]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "Entre 5 a 6 caracteres")]
        [DisplayName("ID del Cliente")]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "El nombre de empresa es obligatorio")]
        [DisplayName("Nombre de empresa")]
        public string CompanyName { get; set; }

        [DisplayName("Nombre de contacto")]
        public string ContactName { get; set; }

        [DisplayName("Título de contacto")]
        public string ContactTitle { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Entre 3 y 100 caracteres")]
        [DisplayName("Dirección")]
        public string Address { get; set; }

        [StringLength(70, MinimumLength = 3, ErrorMessage = "Entre 3 y 70 caracteres")]
        [DisplayName("Ciudad")]
        public string City { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Entre 3 y 50 caracteres")]
        public string Region { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El código postal no puede ser negativo")]
        [DisplayName("Código Postal")]
        public string PostalCode { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Entre 3 y 50 caracteres")]
        [DisplayName("País")]
        public string Country { get; set; }

        [StringLength(24, MinimumLength = 9, ErrorMessage = "Entre 9 y 24 caracteres")]
        [DisplayName("Telefono")]
        public string Phone { get; set; }

        public string Fax { get; set; }

        public Customers(
            string customerID,
            string companyName,
            string contactName,
            string contactTitle,
            string address,
            string city,
            string region,
            string postalCode,
            string country,
            string phone,
            string fax
        )
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
