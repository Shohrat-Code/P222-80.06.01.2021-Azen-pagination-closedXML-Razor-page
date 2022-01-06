using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Models
{
    public class FAQ
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(1500)]
        public string Content { get; set; }
        [ForeignKey("FAQCategory")]
        public int CategoryId { get; set; }
        public FAQCategory FAQCategory { get; set; }
    }
}
