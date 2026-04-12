using NorthwindApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NorthwindApp.Data.Interfaces
{
    public class OrdersDAO : IOrders
    {
        private string cadenaCnx;
        public OrdersDAO()
        {
            cadenaCnx = ConfigurationManager.ConnectionStrings["NorthwindContext"].ConnectionString;
        }
        public bool Actualizar(Orders entity)
        {
            throw new NotImplementedException();
        }

        public Orders BuscarPorId(int idpedido)
        {
            var order = new Orders();
            using (SqlConnection cn = new SqlConnection(cadenaCnx))
            {
                cn.Open();
                var cmd = new SqlCommand(@"SELECT OrderID, CustomerID, OrderDate, ShipName, ShipAddress, ShipCity, ShipPostalCode, ShipCountry  FROM Orders WHERE OrderID = @OrderID", cn);
                cmd.Parameters.AddWithValue("@OrderID", idpedido);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order = new Orders
                        {
                            OrderID = reader.GetInt32(0),
                            Customers = new Customers { CustomerID = reader.GetString(1) },
                            OrderDate = reader.GetDateTime(2),
                            ShipName = reader.GetString(3),
                            ShipAddress = reader.GetString(4),
                            ShipCity = reader.GetString(5),
                            ShipPostalCode = reader.GetString(6),
                            ShipCountry = reader.GetString(7)
                        };

                    }
                }
            }
            return order;
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Orders> GetOrdersByCustomerId(string customerId)
        {
            var lista = new List<Orders>();
            using (SqlConnection cn = new SqlConnection(cadenaCnx))
            {
                cn.Open();
                var cmd = new SqlCommand(@"SELECT OrderID, CustomerID, OrderDate, ShipName, ShipAddress, ShipCity, ShipPostalCode, ShipCountry  FROM Orders WHERE CustomerID = @CustomerID", cn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var order = new Orders
                        {
                            OrderID = reader.GetInt32(0),
                            Customers = new Customers { CustomerID = reader.GetString(1) },
                            OrderDate = reader.GetDateTime(2),
                            ShipName = reader.GetString(3),
                            ShipAddress = reader.GetString(4),
                            ShipCity = reader.GetString(5),
                            ShipPostalCode = reader.GetString(6),
                            ShipCountry = reader.GetString(7)
                        };
                        lista.Add(order);
                    }
                }

            }
            return lista;
        }

        public List<Orders> ListarTodo()
        {
            var lista = new List<Orders>();
            using (SqlConnection cn = new SqlConnection(cadenaCnx))
            {
                cn.Open();
                var cmd = new SqlCommand(@"SELECT OrderID, CustomerID, OrderDate, ShipName, ShipAddress, ShipCity, ShipPostalCode, ShipCountry FROM Orders", cn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var order = new Orders
                        {
                            OrderID = reader.GetInt32(0),
                            Customers = new Customers { CustomerID = reader.GetString(1) },
                            OrderDate = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                            ShipName = reader.GetString(3),
                            ShipAddress = reader.IsDBNull(4) ? null : reader.GetString(4),
                            ShipCity = reader.IsDBNull(5) ? null : reader.GetString(5),
                            ShipPostalCode = reader.IsDBNull(6) ? null : reader.GetString(6),
                            ShipCountry = reader.IsDBNull(7) ? null : reader.GetString(7)
                        };
                        lista.Add(order);
                    }
                }
            }
            return lista;
        }

        public (List<Orders> items, int totalRegistros) ObtenerPaginado(int pagina, int tamanoPagina)
        {
            var lista = new List<Orders>();
            int total = 0;
            int offset = (pagina - 1) * tamanoPagina;

            using (SqlConnection con = new SqlConnection(cadenaCnx))
            {
                con.Open();

                // Contar total de registros
                SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Orders", con);
                total = (int)cmdCount.ExecuteScalar();

                // Obtener página
                string sql = @"SELECT OrderID, CustomerID, OrderDate, ShipName, ShipAddress, ShipCity, ShipPostalCode, ShipCountry FROM Orders ORDER BY OrderID
                       OFFSET @offset ROWS FETCH NEXT @tamano ROWS ONLY";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@offset", offset);
                cmd.Parameters.AddWithValue("@tamano", tamanoPagina);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Orders
                        {
                            OrderID = reader.GetInt32(0),
                            Customers = new Customers { CustomerID = reader["CustomerID"].ToString() },
                            OrderDate = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                            ShipName = reader["ShipName"].ToString(),
                            ShipAddress = reader.IsDBNull(4) ? null : reader.GetString(4),
                            ShipCity = reader.IsDBNull(5) ? null : reader.GetString(5),
                            ShipPostalCode = reader.IsDBNull(6) ? null : reader.GetString(6),
                            ShipCountry = reader.IsDBNull(7) ? null : reader.GetString(7)
                        });
                    }
                }
            }
            return (lista, total);
        }

        public bool Registrar(Orders entity)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetails> ObtenerOrderDetails(int id)
        {
            List<OrderDetails> lista = new List<OrderDetails>();
            using (SqlConnection cn = new SqlConnection(cadenaCnx))
            {
                cn.Open();
                var cmd = new SqlCommand(@"SELECT o.OrderID, o.ProductID, p.ProductName, o.UnitPrice, o.Quantity, o.Discount
FROM [Order Details] o
inner JOIN Products p ON p.ProductID = o.ProductID
WHERE OrderID = @OrderID", cn);
                cmd.Parameters.AddWithValue("@OrderID", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var orderDetails = new OrderDetails
                        {
                            Orders = new Orders { OrderID = reader.GetInt32(0) },
                            Products = new Products { ProductID = reader.GetInt32(1), ProductName = reader.GetString(2) },
                            UnitPrice = reader.GetDecimal(3),
                            Quantity = reader.GetInt16(4),
                            Discount = reader.GetFloat(5)
                        };
                        lista.Add(orderDetails);
                    }
                }
            }

            return lista;
        }
    }
}