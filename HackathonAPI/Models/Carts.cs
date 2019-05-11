using System;
using Dapper;

namespace HackathonAPI.Models
{
    public class Carts
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        [ReadOnly(true)]
        public DateTime DateCreated { get; set; }
        public int MerchantId { get; set; }
        [Editable(false)]
        public string MerchantName { get; set; }
    }

    public class NewCarts
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int MerchantId { get; set; }
    }
}
