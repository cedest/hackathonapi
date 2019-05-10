using System;
using Dapper;

namespace HackathonAPI.Models
{
    [Table("subscriptions")]
    public class Subscriptions
    {
        [Key]
        public int SubscriptionId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int FrequencyId { get; set; }
        public string Frequency { get; set; }
        public bool Status { get; set; }
        public DateTime SubscriptionDate { get; set; }
    }

    public class NewSubscriptions
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int FrequencyId { get; set; }
    }
}
