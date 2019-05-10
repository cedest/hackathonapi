using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackathonAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HackathonAPI.Controllers
{
    [Route("api/[controller]")]
    public class SubscriptionsController : Controller
    {
        // GET: api/values
        [HttpGet]
        public List<Subscriptions> Get()
        {
            return new List<Subscriptions>();
        }

        // GET api/values/5
        [HttpGet("{SubscriptionId}")]
        public Subscriptions Get(int SubscriptionId)
        {
            return new Subscriptions();
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]Subscriptions value)
        {
            return new Response();
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Subscriptions value)
        {
            return new Response();
        }

        // DELETE api/values/5
        [HttpDelete("{SubscriptionId}")]
        public Response Delete(int SubscriptionId)
        {
            return new Response();
        }
    }
}
