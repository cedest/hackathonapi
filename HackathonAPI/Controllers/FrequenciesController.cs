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
    public class FrequenciesController : Controller
    {
        FrequenciesRepository repo;

        public FrequenciesController(IConfiguration configuration)
        {
            repo = new FrequenciesRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public List<Frequencies> Get()
        {
            return repo.ListAll();
        }

        // GET api/values/5
        [HttpGet("{FrequencyId}")]
        public Frequencies Get(int FrequencyId)
        {
            return repo.Read(FrequencyId);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]Frequencies value)
        {
            return repo.Create(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Frequencies value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{FrequencyId}")]
        public Response Delete(int FrequencyId)
        {
            return repo.Delete(FrequencyId);
        }
    }
}
