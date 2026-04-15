using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindApp.Models;

namespace NorthwindApp.Data.Interfaces
{
    internal interface ICustomers : ICRUD<Customers>
    {
        (List<Customers> items, int totalRegistros) ObtenerPaginado(int pagina, int tamanoPagina);
        (List<Customers> items, int totalRegistros) BuscarPorNombre(
            string nombre,
            int pagina,
            int tamanoPagina
        );
    }
}
