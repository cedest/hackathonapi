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
    public class CategoryRepository
    {
        private string ConnectionString;

        public CategoryRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public List<Categories> List()
        {
            List<Categories> list = new List<Categories>();
            using(IDbConnection conn = GetConnection())
            {
                list = conn.GetList<Categories>().ToList();
            }
            return list;
        }

        public Categories Read(int CategoryId)
        {
            Categories categories = new Categories();
            using(IDbConnection conn = GetConnection())
            {
                categories = conn.Get<Categories>(CategoryId);
            }
            return categories;
        }

        public Response Create(NewCategories categories)
        {
            Response response = new Response();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    var merchant = conn.Get<Merchants>(categories.MerchantId);
                    Categories cat = new Categories()
                    {
                        CategoryName = categories.CategoryName,
                        Description = categories.Description,
                        MerchantId = categories.MerchantId,
                        MerchantName = merchant.MerchantName,
                        Picture = categories.Picture
                    };
                    conn.Insert(cat);
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

        public Response Update(Categories categories)
        {
            Response response = new Response();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    conn.Update(categories);
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

        public Response Delete(int CategoryId)
        {
            Response response = new Response();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    conn.Delete(CategoryId);
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
