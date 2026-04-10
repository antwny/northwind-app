using NorthwindApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp.Data.Interfaces
{
    internal interface IOrders : ICRUD<Orders>
    {
        List<Orders> GetOrdersByCustomerId(string customerId);
        Orders BuscarPorId(int idpedido);
    }
}
