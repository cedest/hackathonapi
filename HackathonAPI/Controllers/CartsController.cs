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
    public class CartsController : Controller
    {
        CartRepository repo;

        public CartsController(IConfiguration configuration)
        {
            repo = new CartRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public List<Carts> Get()
        {
            return repo.ListAll();
        }

        [HttpGet("customer/{CustomerId}")]
        public List<Carts> GetByCustomer(int CustomerId)
        {
            return repo.List(CustomerId);
        }

        // GET api/values/5
        [HttpGet("{CartId}")]
        public Carts Get(int CartId)
        {
            return repo.Read(CartId);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]NewCarts value)
        {
            return repo.Create(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Carts value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{CartId}")]
        public Response Delete(int CartId)
        {
            return repo.Delete(CartId);
        }
    }
}
