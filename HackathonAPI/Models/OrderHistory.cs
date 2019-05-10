using System;
using System.Collections.Generic;
using Dapper;

namespace HackathonAPI.Models
{
    [Table("OrderHistory")]
    public class OrderHistory
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
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
        public decimal Quantity { get; set; }
    }

    public class NewOrderReponse : Response
    {
        public bool SuggestSubscription { get; set; }
        public List<Products> SuggestedProducts { get; set; }
    }
}
