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
    public class SubscriptionRepository
    {
        private string ConnectionString;

        public SubscriptionRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public List<Subscriptions> ListAll()
        {
            List<Subscriptions> list = new List<Subscriptions>();
            using(IDbConnection conn = GetConnection())
            {
                list = conn.GetList<Subscriptions>().ToList();
            }
            return list;
        }

        public List<Subscriptions> List(int CustomerId)
        {
            List<Subscriptions> list = new List<Subscriptions>();
            using (IDbConnection conn = GetConnection())
            {
                list = conn.GetList<Subscriptions>("Where CustomerId = ?CustomerId", new { CustomerId }).ToList();
            }
            return list;
        }

        public Subscriptions Read(int SubscriptionId)
        {
            Subscriptions subscription = new Subscriptions();
            using(IDbConnection conn = GetConnection())
            {
                subscription = conn.Get<Subscriptions>(SubscriptionId);
            }
            return subscription;
        }

        public Response Create(NewSubscriptions subscription)
        {
            SubscriptionResponse response = new SubscriptionResponse();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    var exists = conn.GetList<Subscriptions>("Where CustomerId = ?CustomerId and ProductId = ?ProductId", subscription).ToList();
                    if(exists.Count > 0)
                    {
                        response.Status = false;
                        response.Description = "Record exists";
                        return response;
                    }
                    var customers = conn.Get<Customers>(subscription.CustomerId);
                    var products = conn.Get<Products>(subscription.ProductId);
                    var frequencies = conn.Get<Frequencies>(subscription.FrequencyId);
                    int MerchantId = subscription.MerchantId == 0 ? 1 : subscription.MerchantId;
                    var merchants = conn.Get<Merchants>(MerchantId);

                    Subscriptions sub = new Subscriptions()
                    {
                        CustomerId = subscription.CustomerId,
                        CustomerName = customers.FullName,
                        ProductId = subscription.ProductId,
                        ProductName = products.ProductName,
                        Quantity = subscription.Quantity,
                        Status = true,
                        FrequencyId = subscription.FrequencyId,
                        Frequency = frequencies.Frequency,
                        MerchantId = MerchantId,
                        MerchantName = merchants.MerchantName
                    };
                    sub.SubscriptionId = conn.Insert(sub).Value;
                    response.Status = true;
                    response.Description = "Record saved";
                    response.Subscription = sub;
                }
            }
            catch (Exception ex)
            {
                response.Description = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public SubscriptionResponse Update(Subscriptions subscription)
        {
            SubscriptionResponse response = new SubscriptionResponse();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    var customers = conn.Get<Customers>(subscription.CustomerId);
                    var products = conn.Get<Products>(subscription.ProductId);
                    var frequencies = conn.Get<Frequencies>(subscription.FrequencyId);
                    int MerchantId = subscription.MerchantId == 0 ? 1 : subscription.MerchantId;
                    var merchants = conn.Get<Merchants>(MerchantId);

                    Subscriptions sub = new Subscriptions()
                    {
                        CustomerId = subscription.CustomerId,
                        CustomerName = customers.FullName,
                        ProductId = subscription.ProductId,
                        ProductName = products.ProductName,
                        Quantity = subscription.Quantity,
                        Status = true,
                        FrequencyId = subscription.FrequencyId,
                        Frequency = frequencies.Frequency,
                        SubscriptionId = subscription.SubscriptionId,
                        MerchantId = MerchantId,
                        MerchantName = merchants.MerchantName
                    };
                    conn.Update(sub);
                    response.Status = true;
                    response.Description = "Record updated";
                    response.Subscription = sub;
                }
            }
            catch (Exception ex)
            {
                response.Description = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public Response Delete(int SubscriptionId, bool Status)
        {
            Response response = new Response();
            string sql = "Update subscriptions set status = ?Status where SubscriptionId = ?SubscriptionId";
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Query(sql, new { SubscriptionId, Status });
                    response.Status = true;
                    response.Description = "Record disabled";
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
