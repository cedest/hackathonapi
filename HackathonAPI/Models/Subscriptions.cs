using System;
using System.Collections.Generic;
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
        [ReadOnly(true)]
        public DateTime SubscriptionDate { get; set; }
        public int MerchantId { get; set; }
        [Editable(false)]
        public string MerchantName { get; set; }
    }

    public class NewSubscriptions : NewSub
    {
        public int CustomerId { get; set; }
    }

    public class NewBulkSubscriptions
    {
        public int CustomerId { get; set; }
        public List<NewSub> subscriptions { get; set; }
    }

    public class NewSub
    {
        public int ProductId { get; set; }
        public int FrequencyId { get; set; }
        public int Quantity { get; set; }
    }
}
