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
    public class CustomersController : Controller
    {
        CustomerRepository repo;

        public CustomersController(IConfiguration configuration)
        {
            repo = new CustomerRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public List<Customers> Get()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{customerId}")]
        public Customers Get(int customerId)
        {
            return repo.Read(customerId);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]Customers request)
        {
            return repo.Create(request);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Customers request)
        {
            return repo.Update(request);
        }

        // DELETE api/values/5
        [HttpDelete("{customerId}")]
        public Response Delete(int customerId)
        {
            return repo.Delete(customerId);
        }
    }
}
