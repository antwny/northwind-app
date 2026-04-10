using NorthwindApp.Data;
using NorthwindApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindApp.Controllers
{
    public class OrdersController : Controller
    {
        private OrdersDAO ordersDAO;
        public OrdersController()
        {
            ordersDAO = new OrdersDAO();
        }
        public ActionResult ListaOrders(int pagina=1)
        {
            int tamanoPagina = 10;

            var (items, total) = ordersDAO.ObtenerPaginado(pagina, tamanoPagina);
            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)total / tamanoPagina);
            ViewBag.TotalRegistros = total;

            return View(items);
        }
        public ActionResult DetallesOrders(int orderId)
        {
            return View();
        }
    }
}