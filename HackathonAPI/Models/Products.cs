using System;
using Dapper;

namespace HackathonAPI.Models
{
    [Table("products")]
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }
        public int UnitInStocks { get; set; }
        public int CategoryId { get; set; }
        [Editable(false)]
        public string CategoryName { get; set; }
        public int MerchantId { get; set; }
        [Editable(false)]
        public string MerchantName { get; set; }
    }
}
