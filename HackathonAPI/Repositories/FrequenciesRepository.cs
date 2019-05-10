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
    public class FrequenciesRepository
    {
        private string ConnectionString;

        public FrequenciesRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        public List<Frequencies> ListAll()
        {
            List<Frequencies> list = new List<Frequencies>();
            using (IDbConnection conn = GetConnection())
            {
                list = conn.GetList<Frequencies>().ToList();
            }
            return list;
        }

        public Frequencies Read(int FrequencyId)
        {
            Frequencies result = new Frequencies();
            using(IDbConnection conn = GetConnection())
            {
                result = conn.Get<Frequencies>(FrequencyId);
            }
            return result;
        }

        public Response Create(Frequencies frequency)
        {
            Response response = new Response();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    conn.Insert(frequency);
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

        public Response Update(Frequencies frequency)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Update(frequency);
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

        public Response Delete(int FrequencyId)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete(FrequencyId);
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
