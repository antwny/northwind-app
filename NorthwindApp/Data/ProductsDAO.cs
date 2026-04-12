using NorthwindApp.Data.Interfaces;
using NorthwindApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NorthwindApp.Data
{
    public class ProductsDAO : IProducts
    {
        private string cadenaCnx;
        public ProductsDAO()
        {
            cadenaCnx = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;
        }
        public (List<Customers> items, int totalRegistros) BuscarPorNombre(string nombre, int pagina, int tamanoPagina)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public (List<Customers> items, int totalRegistros) ObtenerPaginado(int pagina, int tamanoPagina)
        {
            throw new NotImplementedException();
        }

        public Products ObtenerPorId(int id)
        {
            Products producto = new Products();
            using (var cnx = new SqlConnection(cadenaCnx))
            {
                var cmd = new SqlCommand("SELECT ProductID, ProductName FROM Products WHERE ProductID = @id", cnx);
                cmd.Parameters.AddWithValue("@id", id);
                cnx.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto.ProductID = reader.GetInt32(0);
                        producto.ProductName = reader.GetString(1);
                    }
                }
            }
            return producto;
        }

        bool ICRUD<IProducts>.Actualizar(IProducts entity)
        {
            throw new NotImplementedException();
        }

        List<IProducts> ICRUD<IProducts>.ListarTodo()
        {
            throw new NotImplementedException();
        }

        bool ICRUD<IProducts>.Registrar(IProducts entity)
        {
            throw new NotImplementedException();
        }
    }
}