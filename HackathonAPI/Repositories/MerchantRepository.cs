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
    public class MerchantRepository
    {
        private string ConnectionString;

        public MerchantRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public List<Merchants> List()
        {
            List<Merchants> list = new List<Merchants>();
            using(IDbConnection conn = GetConnection())
            {
                list = conn.GetList<Merchants>().ToList();
            }
            return list;
        }

        public Merchants Read(int MerchantId)
        {
            Merchants merchant = new Merchants();
            using(IDbConnection conn = GetConnection())
            {
                merchant = conn.Get<Merchants>(MerchantId);
            }
            return merchant;
        }

        public Response Create(NewMerchant merchant)
        {
            Response response = new Response();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    Merchants obj = new Merchants()
                    {
                        IsActive = true,
                        MerchantAddress = merchant.MerchantAddress,
                        MerchantName = merchant.MerchantName,
                        MerchantPhone = merchant.MerchantPhone,
                        SubscriptionPlan = merchant.SubscriptionPlan
                    };
                    conn.Insert(obj);
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

        public Response Update(Merchants merchants)
        {
            Response response = new Response();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    conn.Update(merchants);
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

        public Response Delete(int MerchantId)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<Merchants>(MerchantId);
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
