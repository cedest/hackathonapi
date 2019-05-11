using System;
using Dapper;

namespace HackathonAPI.Models
{
    [Table("customers")]
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Editable(false)]
        public string FullName { get => string.Format("{0} {1}", FirstName, LastName); }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int MerchantId { get; set; }
        [Editable(false)]
        public string MerchantName { get; set; }
    }
}
