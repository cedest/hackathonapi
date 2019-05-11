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
    public class CategoriesController : Controller
    {
        CategoryRepository repo;

        public CategoriesController(IConfiguration configuration)
        {
            repo = new CategoryRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public List<Categories> Get()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{CategoryId}")]
        public Categories Get(int CategoryId)
        {
            return repo.Read(CategoryId);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]NewCategories value)
        {
            return repo.Create(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Categories value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{CategoryId}")]
        public Response Delete(int CategoryId)
        {
            return repo.Delete(CategoryId);
        }
    }
}
