using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string  Name { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
