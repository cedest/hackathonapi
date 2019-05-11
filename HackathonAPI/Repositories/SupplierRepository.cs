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
    public class SupplierRepository
    {
        private string ConnectionString;

        public SupplierRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public List<Suppliers> ListAll()
        {
            List<Suppliers> list = new List<Suppliers>();
            using (IDbConnection conn = GetConnection())
            {
                list = conn.GetList<Suppliers>().ToList();
            }
            return list;
        }

        public List<Suppliers> List(int MerchantId)
        {
            List<Suppliers> list = new List<Suppliers>();
            using (IDbConnection conn = GetConnection())
            {
                list = conn.GetList<Suppliers>("Where MerchantId = ?MerchantId", new { MerchantId }).ToList();
            }
            return list;
        }

        public Suppliers Read(int SupplierId)
        {
            Suppliers suppliers = new Suppliers();
            using(IDbConnection conn = GetConnection())
            {
                suppliers = conn.Get<Suppliers>(SupplierId);
            }
            return suppliers;
        }

        public Response Create(NewSuppliers suppliers)
        {
            Response response = new Response();
            return response;
        }
    }
}
