using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthwindApp.Data;
using NorthwindApp.Data.Interfaces;
using NorthwindApp.Models;

namespace NorthwindApp.Controllers
{
    [Route("customers")]
    public class CustomersController : Controller
    {
        private CustomersDAO customersDAO;
        private OrdersDAO ordersDAO;

        public CustomersController()
        {
            customersDAO = new CustomersDAO();
            ordersDAO = new OrdersDAO();
        }

        [Route("lista")]
        [HttpGet]
        public ActionResult Lista(int pagina = 1)
        {
            int tamanoPagina = 10;

            var (items, total) = customersDAO.ObtenerPaginado(pagina, tamanoPagina);

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)total / tamanoPagina);
            ViewBag.TotalRegistros = total;

            return View(items);
        }

        [HttpPost]
        public ActionResult Lista(string nombre = "", int pagina = 1)
        {
            int tamanoPagina = 10;

            var (items, total) = customersDAO.BuscarPorNombre(nombre, pagina, tamanoPagina);

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)total / tamanoPagina);
            ViewBag.TotalRegistros = total;

            return View(items);
        }

        [Route("detalles")]
        [HttpGet]
        public ActionResult Detalles(string customerId = "")
        {
            var orders = ordersDAO.GetOrdersByCustomerId(customerId);
            ViewBag.Orders = orders;

            return View(customersDAO.BuscarPorId(customerId));
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View(new Customers());
        }

        [HttpPost]
        public ActionResult Registrar(Customers customer)
        {
            if (!ModelState.IsValid)
            {
                // 👈 Regresa a la vista con los errores
                return View(customer);
            }

            if (customersDAO.BuscarPorId(customer.CustomerID) != null)
            {
                ViewBag.Ok = false;
                ViewBag.Titulo = "Este cliente ya existe";
                ViewBag.Mensaje = $"El cliente con ID: {customer.CustomerID} ya fue registrado";
                return View(customer);
            }

            bool ok = customersDAO.Registrar(customer);
            ViewBag.Ok = ok;
            ViewBag.Titulo = ok ? "Cliente Registrado" : "Error al registrar!";
            ViewBag.Mensaje = ok ? "El cliente se registro correctamente." : "Codigo de error: 103";
            return View(customer);
        }

        public ActionResult Eliminar(string customerId)
        {
            bool ok = customersDAO.Eliminar(customerId);
            TempData["Ok"] = ok;
            TempData["Titulo"] = ok ? "Cliente Eliminado" : "Error al eliminar!";
            TempData["Mensaje"] = ok
                ? "El cliente se elimino correctamente."
                : "Codigo de error: 104";
            return RedirectToAction("Lista");
        }
    }
}
