using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp.Data.Interfaces
{
    internal interface ICRUD<T>
    {
        bool Registrar(T entity);
        List<T> ListarTodo();
        bool Actualizar(T entity);
    }
}
