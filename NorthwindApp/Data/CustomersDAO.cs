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
            try
            {
                using (var cnx = new SqlConnection(cadenaCnx))
                {
                    cnx.Open();
                    string sql =
                        @"UPDATE Customers SET CompanyName = @CompanyName, ContactName = @ContactName, ContactTitle = @ContactTitle, 
                        Address = @Address, City = @City, Region = @Region, PostalCode = @PostalCode, Country = @Country, 
                        Phone = @Phone, Fax = @Fax WHERE CustomerID = @CustomerID";
                    using (var cmd = new SqlCommand(sql, cnx))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", entity.CustomerID);
                        cmd.Parameters.AddWithValue("@CompanyName", entity.CompanyName);
                        cmd.Parameters.AddWithValue("@ContactName", entity.ContactName);
                        cmd.Parameters.AddWithValue("@ContactTitle", entity.ContactTitle);
                        cmd.Parameters.AddWithValue("@Address", entity.Address);
                        cmd.Parameters.AddWithValue("@City", entity.City);
                        cmd.Parameters.AddWithValue("@Region", entity.Region);
                        cmd.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
                        cmd.Parameters.AddWithValue("@Country", entity.Country);
                        cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                        cmd.Parameters.AddWithValue("@Fax", entity.Fax);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                return false;
                throw new ApplicationException("Error al actualizar datos: " + ex.Message, ex);
            }
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

        public bool Eliminar(string id)
        {
            try
            {
                using (var cnx = new SqlConnection(cadenaCnx))
                {
                    cnx.Open();
                    using (
                        var cmd = new SqlCommand(
                            "delete from Customers where CustomerID like @ID",
                            cnx
                        )
                    )
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                return false;
                throw new ApplicationException("Error al eliminar datos: " + ex.Message, ex);
            }
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
            try
            {
                bool ok = false;
                using (var cnx = new SqlConnection(cadenaCnx))
                {
                    cnx.Open();
                    string sql =
                        @"INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax)
                        VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)";

                    using (var cmd = new SqlCommand(sql, cnx))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", entity.CustomerID);
                        cmd.Parameters.AddWithValue("@CompanyName", entity.CompanyName);
                        cmd.Parameters.AddWithValue("@ContactName", entity.ContactName);
                        cmd.Parameters.AddWithValue("@ContactTitle", entity.ContactTitle);
                        cmd.Parameters.AddWithValue("@Address", entity.Address);
                        cmd.Parameters.AddWithValue("@City", entity.City);
                        cmd.Parameters.AddWithValue("@Region", entity.Region);
                        cmd.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
                        cmd.Parameters.AddWithValue("@Country", entity.Country);
                        cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                        cmd.Parameters.AddWithValue("@Fax", entity.Fax);

                        ok = cmd.ExecuteNonQuery() > 0;
                    }
                }
                return ok;
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error al registrar datos: " + ex.Message, ex);
            }
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
