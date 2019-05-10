using System;
using Dapper;

namespace HackathonAPI.Models
{
    [Table("frequencies")]
    public class Frequencies
    {
        [Key]
        public int FrequencyId { get; set; }
        public string Frequency { get; set; }
    }
}
