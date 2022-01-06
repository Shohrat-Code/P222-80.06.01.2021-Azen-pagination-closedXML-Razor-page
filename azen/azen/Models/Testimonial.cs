using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Models
{
    public class Testimonial
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string  Fullname { get; set; }
       
        [Column(TypeName ="ntext")]
        public string Content { get; set; }
    }
}
