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
    public class ProductsController : Controller
    {
        ProductsRepository repo;

        public ProductsController(IConfiguration configuration)
        {
            repo = new ProductsRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public List<Products> Get()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{ProductId}")]
        public Products Get(int ProductId)
        {
            return repo.Read(ProductId);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]Products value)
        {
            return repo.Create(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Products value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{ProductId}")]
        public Response Delete(int ProductId)
        {
            return repo.Delete(ProductId);
        }
    }
}
