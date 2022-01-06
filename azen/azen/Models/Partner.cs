using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string  Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
