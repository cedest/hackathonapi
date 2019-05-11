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
    public class MerchantsController : Controller
    {
        MerchantRepository repo;

        public MerchantsController(IConfiguration configuration)
        {
            repo = new MerchantRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public List<Merchants> Get()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{MerchantId}")]
        public Merchants Get(int MerchantId)
        {
            return repo.Read(MerchantId);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]NewMerchant value)
        {
            return repo.Create(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Merchants value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{MerchantId}")]
        public Response Delete(int MerchantId)
        {
            return repo.Delete(MerchantId);
        }
    }
}
