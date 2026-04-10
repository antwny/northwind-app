using NorthwindApp.Data;
using NorthwindApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Lista(int pagina = 1)
        {
            int tamanoPagina = 10;

            var (items, total) = customersDAO.ObtenerPaginado(pagina, tamanoPagina);

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

        
    }
}