using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Models
{
    public class Commenter
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string  FullName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }   
        [MaxLength(1500)]
        public string Content { get; set; }
        [MaxLength(250)]
        public string WebSite { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ProductComment> ProductComments { get; set; }
    }
}
