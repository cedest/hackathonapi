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
    public class OrderRepository
    {
        private string ConnectionString;

        public OrderRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public List<OrderHistory> ListAll()
        {
            List<OrderHistory> list = new List<OrderHistory>();
            using(IDbConnection conn = GetConnection())
            {
                list = conn.GetList<OrderHistory>().ToList();
            }
            return list;
        }

        public List<OrderHistory> List(int CustomerId)
        {
            List<OrderHistory> list = new List<OrderHistory>();
            using (IDbConnection conn = GetConnection())
            {
                list = conn.GetList<OrderHistory>("Where CustomerId = ?CustomerId", new { CustomerId }).ToList();
                 
            }
            return list;
        }

        public OrderHistory Read(int OrderId)
        {
            OrderHistory history = new OrderHistory();
            using(IDbConnection conn = GetConnection())
            {
                history = conn.Get<OrderHistory>(OrderId);
            }
            return history;
        }

        public NewOrderReponse Create(NewOrder order)
        {
            NewOrderReponse response = new NewOrderReponse();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    var customer = conn.Get<Customers>(order.CustomerId);
                    order.orders.ForEach(item =>
                    {
                        var product = conn.Get<Products>(item.ProductId);
                        OrderHistory orders = new OrderHistory()
                        {
                            CustomerId = order.CustomerId,
                            CustomerName = customer.FullName,
                            ProductId = item.ProductId,
                            ProductName = product.ProductName,
                            ImageUrl = product.ImageUrl,
                            UnitPrice=product.UnitPrice

                        };
                        conn.Insert(orders);
                    });
                    string sql = @"select * from products where productid in (
                                SELECT a.productid from orders a 
                                where a.customerid = 1 and productid not in (select productid from subscriptions where customerid = a.customerid)
                                group by a.productid
                                having count(a.productid) > 1)";
                    var products = conn.Query<Products>(sql).ToList();
                    if(products.Count > 0)
                    {
                        response.SuggestSubscription = true;
                        response.SuggestedProducts = products;
                    }
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

        public Response Update(OrderHistory order)
        {
            Response response = new Response();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    conn.Update(order);
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

        public Response Delete(int OrderId)
        {
            Response response = new Response();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    conn.Delete<OrderHistory>(OrderId);
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
    }
}
