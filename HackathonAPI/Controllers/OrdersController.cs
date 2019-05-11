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
    public class OrdersController : Controller
    {
        OrderRepository repo;

        public OrdersController(IConfiguration configuration)
        {
            repo = new OrderRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public List<OrderHistory> Get()
        {
            return repo.ListAll();
        }

        // GET api/values/5
        [HttpGet("{OrderId}")]
        public OrderHistory GetOrder(int OrderId)
        {
            return repo.Read(OrderId);
        }

        [HttpGet("customer/{customerid}")]
        public List<OrderHistory> GetByCustomer(int customerid)
        {
            return repo.List(customerid);
        }

        [HttpGet("customer/{customerid}/suggestions")]
        public SuggestedItems GetSuggestedItems(int customerid)
        {
            return repo.Suggestions(customerid);
        }

        [HttpGet("customer/{customerid}/related")]
        public SuggestedItems GetRelatedProducts(int customerid)
        {
            return repo.RelatedProducts(customerid);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]NewOrder order)
        {
            return repo.Create(order);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]OrderHistory value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{OrderId}")]
        public Response Delete(int OrderId)
        {
            return repo.Delete(OrderId);
        }
    }
}
