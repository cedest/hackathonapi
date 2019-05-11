using System;
using System.Collections.Generic;
using Dapper;

namespace HackathonAPI.Models
{
    [Table("orders")]
    public class OrderHistory
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        [ReadOnly(true)]
        public DateTime PurchaseDate { get; set; }
    }

    public class NewOrder
    {
        public int CustomerId { get; set; }
        public List<MyOrder> orders { get; set; }
    }

    public class MyOrder
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class NewOrderReponse : Response
    {
        public bool SuggestSubscription { get; set; }
        public List<Products> SuggestedProducts { get; set; }
    }

    public class SuggestedItems
    {
        public bool SuggestSubscription { get; set; }
        public List<Products> SuggestedProducts { get; set; }
    }
}
