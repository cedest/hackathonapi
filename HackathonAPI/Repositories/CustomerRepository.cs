using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using HackathonAPI.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace HackathonAPI.Repositories
{
    public class CustomerRepository
    {
        private string ConnectionString;

        public CustomerRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public List<Customers> List()
        {
            List<Customers> list = new List<Customers>();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    list = conn.GetList<Customers>().ToList();
                }
            }
            catch(Exception ex)
            {
                var response = ex.Message;
            }
            return list;
        }

        public Customers Read(int CustomerId)
        {
            Customers customer = new Customers();
            using(IDbConnection conn = GetConnection())
            {
                customer = conn.Get<Customers>(CustomerId);
            }
            return customer;
        }

        public Response Create(Customers customer)
        {
            Response response = new Response();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    conn.Insert(customer);
                    response.Status = true;
                    response.Description = "Record saved";
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Description = ex.Message;
            }
            return response;
        }

        public Response Update(Customers customer)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Update(customer);
                    response.Status = true;
                    response.Description = "Record updated";
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Description = ex.Message;
            }
            return response;
        }

        public Response Delete(int ProductId)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<Customers>(ProductId);
                    response.Status = true;
                    response.Description = "Record deleted";
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Description = ex.Message;
            }
            return response;
        }
    }
}
