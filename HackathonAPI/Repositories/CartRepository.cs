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
    public class CartRepository
    {
        private string ConnectionString;

        public CartRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public List<Carts> ListAll()
        {
            List<Carts> list = new List<Carts>();
            using (IDbConnection conn = GetConnection())
            {
                list = conn.GetList<Carts>().ToList();
            }
            return list;
        }

        public List<Carts> List(int CustomerId)
        {
            List<Carts> list = new List<Carts>();
            using (IDbConnection conn = GetConnection())
            {
                list = conn.GetList<Carts>("Where CustomerId = ?CustomerId", new { CustomerId }).ToList();

            }
            return list;
        }

        public Carts Read(int CartId)
        {
            Carts cart = new Carts();
            using (IDbConnection conn = GetConnection())
            {
                cart = conn.Get<Carts>(CartId);
            }
            return cart;
        }

        public NewOrderReponse Create(NewCarts cart)
        {
            NewOrderReponse response = new NewOrderReponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    var customer = conn.Get<Customers>(cart.CustomerId);

                    response.Status = true;
                    response.Description = "Record saved";
                }
            }
            catch (Exception ex)
            {
                response.Description = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public Response Update(Carts cart)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Update(cart);
                    response.Status = true;
                    response.Description = "Record updated";
                }
            }
            catch (Exception ex)
            {
                response.Description = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public Response Delete(int CartId)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<Carts>(CartId);
                    response.Status = true;
                    response.Description = "Record deleted";
                }
            }
            catch (Exception ex)
            {
                response.Description = ex.Message;
                response.Status = false;
            }
            return response;
        }
    }
}
