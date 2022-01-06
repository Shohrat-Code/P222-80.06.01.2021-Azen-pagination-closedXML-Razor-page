using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(15)]
        public string  Name { get; set; }
        public List<ColorToSizeToProduct> ColorToSizeToProducts { get; set; }
    }
}
