using NorthwindApp.Data.Interfaces;
using NorthwindApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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
            Customers c = null;
            using (var cnx = new System.Data.SqlClient.SqlConnection(cadenaCnx))
            {
                cnx.Open();
                var cmd = new System.Data.SqlClient.SqlCommand("SELECT * FROM Customers where CustomerID = @id", cnx);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
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
                        Fax = reader["Fax"].ToString()
                    };
                    
                }
            }
            return c;
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customers> ListarTodo()
        {
            List<Customers> lista = new List<Customers>();
            using (var cnx = new System.Data.SqlClient.SqlConnection(cadenaCnx))
            {
                cnx.Open();
                var cmd = new System.Data.SqlClient.SqlCommand("SELECT * FROM Customers", cnx);
                var reader = cmd.ExecuteReader();
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
                        Fax = reader["Fax"].ToString()
                    };
                    lista.Add(c);
                }
            }
            return lista;

        }

        public bool Registrar(Customers entity)
        {
            throw new NotImplementedException();
        }

        public (List<Customers> items, int totalRegistros) ObtenerPaginado(int pagina, int tamanoPagina)
        {
            var lista = new List<Customers>();
            int total = 0;
            int offset = (pagina - 1) * tamanoPagina;

            using (SqlConnection con = new SqlConnection(cadenaCnx))
            {
                con.Open();

                // Contar total de registros
                SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Customers", con);
                total = (int)cmdCount.ExecuteScalar();

                // Obtener página
                string sql = @"SELECT * FROM Customers ORDER BY CustomerID
                       OFFSET @offset ROWS FETCH NEXT @tamano ROWS ONLY";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@offset", offset);
                cmd.Parameters.AddWithValue("@tamano", tamanoPagina);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Customers
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
                        Fax = reader["Fax"].ToString()
                    });
                }
            }
            return (lista, total);
        }

        
        }
    }