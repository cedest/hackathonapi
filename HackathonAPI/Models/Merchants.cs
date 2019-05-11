using System;
using Dapper;

namespace HackathonAPI.Models
{
    [Table("merchants")]
    public class Merchants
    {
        [Key]
        public int MerchantId { get; set; }
        public string MerchantName { get; set; }
        public string MerchantAddress { get; set; }
        public string MerchantPhone { get; set; }
        public bool IsActive { get; set; }
        [ReadOnly(true)]
        public DateTime SubscriptionDate { get; set; }
        public string SubscriptionPlan { get; set; }
    }

    public class NewMerchant
    {
        public string MerchantName { get; set; }
        public string MerchantAddress { get; set; }
        public string MerchantPhone { get; set; }
        public string SubscriptionPlan { get; set; }
    }
}
