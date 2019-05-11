using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackathonAPI.Models;
using HackathonAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HackathonAPI.Controllers
{
    [Route("api/[controller]")]
    public class SuppliersController : Controller
    {
        // GET: api/values
        [HttpGet]
        public List<Suppliers> Get()
        {
            return new List<Suppliers>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Suppliers Get(int id)
        {
            return new Suppliers();
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]Suppliers value)
        {
            return new Response();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Response Put(int id, [FromBody]Suppliers value)
        {
            return new Response();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            return new Response();
        }
    }
}
