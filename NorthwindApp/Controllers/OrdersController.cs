using NorthwindApp.Data;
using NorthwindApp.Data.Interfaces;
using NorthwindApp.Models;
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
        public ActionResult ListaOrders(int pagina = 1)
        {
            int tamanoPagina = 10;

            var (items, total) = ordersDAO.ObtenerPaginado(pagina, tamanoPagina);
            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)total / tamanoPagina);
            ViewBag.TotalRegistros = total;

            return View(items);
        }
        [HttpPost]
        public ActionResult ListaOrders(int orderid, int pagina = 1)
        {
            var lista = new List<Orders>();
            lista.Add(ordersDAO.BuscarPorId(orderid));
            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = 1;
            ViewBag.TotalRegistros = 1;

            return View(lista);
        }
        public ActionResult DetallesOrders(int orderId)
        {
            var order = ordersDAO.BuscarPorId(orderId);
            var orderDetails = ordersDAO.ObtenerOrderDetails(orderId);
            ViewBag.OrderDetails = orderDetails;
            return View(order);
        }
    }
}