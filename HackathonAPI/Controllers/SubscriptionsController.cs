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
    public class SubscriptionsController : Controller
    {
        SubscriptionRepository repo;

        public SubscriptionsController(IConfiguration configuration)
        {
            repo = new SubscriptionRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public List<Subscriptions> GetAll()
        {
            return repo.ListAll();
        }

        [HttpGet("{CustomerId}")]
        public List<Subscriptions> GetByCustomer(int CustomerId)
        {
            return repo.List(CustomerId);
        }

        // GET api/values/5
        [HttpGet("{SubscriptionId}")]
        public Subscriptions Get(int SubscriptionId)
        {
            return repo.Read(SubscriptionId);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]NewSubscriptions value)
        {
            return repo.Create(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Subscriptions value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{SubscriptionId}")]
        public Response Delete(int SubscriptionId)
        {
            return repo.Delete(SubscriptionId);
        }
    }
}
