using NorthwindApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp.Data.Interfaces
{
    internal interface IProducts : ICRUD <IProducts>
    {
        Products ObtenerPorId(int id);
        (List<Customers> items, int totalRegistros) ObtenerPaginado(int pagina, int tamanoPagina);
        (List<Customers> items, int totalRegistros) BuscarPorNombre(string nombre, int pagina, int tamanoPagina);
    }
}
