using System;
using Dapper;

namespace HackathonAPI.Models
{
    [Table("categories")]
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int MerchantId { get; set; }
        [Editable(false)]
        public string MerchantName { get; set; }
    }

    public class NewCategories
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int MerchantId { get; set; }
    }
}
