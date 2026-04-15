using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using NorthwindApp.Data.Interfaces;
using NorthwindApp.Models;

namespace NorthwindApp.Data
{
    public class CustomersDAO : ICustomers
    {
        private string cadenaCnx;

        public CustomersDAO()
        {
            cadenaCnx = ConfigurationManager.ConnectionStrings["NorthwindContext"].ConnectionString;
        }

        public bool Actualizar(Customers entity)
        {
            throw new NotImplementedException();
        }

        public Customers BuscarPorId(string id)
        {
            try
            {
                Customers c = null;
                using (var cnx = new System.Data.SqlClient.SqlConnection(cadenaCnx))
                {
                    cnx.Open();
                    using (
                        var cmd = new SqlCommand(
                            "SELECT * FROM Customers where CustomerID = @id",
                            cnx
                        )
                    )
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                c = new Customers()
                                {
                                    CustomerID = reader["CustomerID"].ToString(),
                                    CompanyName = reader["CompanyName"].ToString(),
                                    ContactName = reader["ContactName"].ToString(),
                                    ContactTitle = reader["ContactTitle"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    City = reader["City"].ToString(),
                                    Region = reader["Region"].ToString(),
                                    PostalCode = reader["PostalCode"].ToString(),
                                    Country = reader["Country"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Fax = reader["Fax"].ToString(),
                                };
                            }
                        }
                    }
                }
                return c;
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error al obtener datos: " + ex.Message, ex);
            }
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customers> ListarTodo()
        {
            try
            {
                List<Customers> lista = new List<Customers>();
                using (var cnx = new SqlConnection(cadenaCnx))
                {
                    cnx.Open();
                    using (var cmd = new SqlCommand("SELECT * FROM Customers", cnx))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customers c = new Customers()
                                {
                                    CustomerID = reader["CustomerID"].ToString(),
                                    CompanyName = reader["CompanyName"].ToString(),
                                    ContactName = reader["ContactName"].ToString(),
                                    ContactTitle = reader["ContactTitle"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    City = reader["City"].ToString(),
                                    Region = reader["Region"].ToString(),
                                    PostalCode = reader["PostalCode"].ToString(),
                                    Country = reader["Country"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Fax = reader["Fax"].ToString(),
                                };
                                lista.Add(c);
                            }
                        }
                    }
                }
                return lista;
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error al obtener datos: " + ex.Message, ex);
            }
        }

        public bool Registrar(Customers entity)
        {
            throw new NotImplementedException();
        }

        public (List<Customers> items, int totalRegistros) ObtenerPaginado(
            int pagina,
            int tamanoPagina
        )
        {
            try
            {
                var lista = new List<Customers>();
                int total = 0;
                int offset = (pagina - 1) * tamanoPagina;

                using (SqlConnection con = new SqlConnection(cadenaCnx))
                {
                    con.Open();

                    // Contar total de registros
                    using (
                        SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Customers", con)
                    )
                    {
                        total = (int)cmdCount.ExecuteScalar();
                    }
                    // Obtener página
                    string sql =
                        @"SELECT * FROM Customers ORDER BY CustomerID
                       OFFSET @offset ROWS FETCH NEXT @tamano ROWS ONLY";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@offset", offset);
                        cmd.Parameters.AddWithValue("@tamano", tamanoPagina);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(
                                    new Customers
                                    {
                                        CustomerID = reader["CustomerID"].ToString(),
                                        CompanyName = reader["CompanyName"].ToString(),
                                        ContactName = reader["ContactName"].ToString(),
                                        ContactTitle = reader["ContactTitle"].ToString(),
                                        Address = reader["Address"].ToString(),
                                        City = reader["City"].ToString(),
                                        Region = reader["Region"].ToString(),
                                        PostalCode = reader["PostalCode"].ToString(),
                                        Country = reader["Country"].ToString(),
                                        Phone = reader["Phone"].ToString(),
                                        Fax = reader["Fax"].ToString(),
                                    }
                                );
                            }
                        }
                    }
                }
                return (lista, total);
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error al obtener datos: " + ex.Message, ex);
            }
        }

        public (List<Customers> items, int totalRegistros) BuscarPorNombre(
            string nombre,
            int pagina,
            int tamanoPagina
        )
        {
            try
            {
                var lista = new List<Customers>();
                int total = 0;
                int offset = (pagina - 1) * tamanoPagina;

                using (var cnx = new SqlConnection(cadenaCnx))
                {
                    cnx.Open();

                    // Contar total de registros
                    using (
                        SqlCommand cmdCount = new SqlCommand(
                            "SELECT COUNT(*) FROM Customers where CompanyName like @nombre",
                            cnx
                        )
                    )
                    {
                        cmdCount.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                        total = (int)cmdCount.ExecuteScalar();
                    }

                    using (
                        var cmd = new SqlCommand(
                            @" SELECT * FROM Customers 
                       where CompanyName like @nombre
                       ORDER BY CustomerID
                       OFFSET @offset ROWS FETCH NEXT @tamano ROWS ONLY",
                            cnx
                        )
                    )
                    {
                        cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                        cmd.Parameters.AddWithValue("@offset", offset);
                        cmd.Parameters.AddWithValue("@tamano", tamanoPagina);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var c = new Customers()
                                {
                                    CustomerID = reader["CustomerID"].ToString(),
                                    CompanyName = reader["CompanyName"].ToString(),
                                    ContactName = reader["ContactName"].ToString(),
                                    ContactTitle = reader["ContactTitle"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    City = reader["City"].ToString(),
                                    Region = reader["Region"].ToString(),
                                    PostalCode = reader["PostalCode"].ToString(),
                                    Country = reader["Country"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Fax = reader["Fax"].ToString(),
                                };
                                lista.Add(c);
                            }
                        }
                    }
                }
                return (lista, total);
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error al buscar por nombre: " + ex.Message, ex);
            }
        }
    }
}
