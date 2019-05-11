using Dapper;
using System;

namespace HackathonAPI.Models
{
    [Table("suppliers")]
    public class Suppliers
    {
        [Key]
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string HomePage { get; set; }
        public int MerchantId { get; set; }
        [Editable(false)]
        public string MerchantName { get; set; }
    }

    public class NewSuppliers
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string HomePage { get; set; }
        public int MerchantId { get; set; }
    }
}
