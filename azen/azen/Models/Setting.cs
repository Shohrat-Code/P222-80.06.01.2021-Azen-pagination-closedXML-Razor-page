using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string  Logo { get; set; }
        [NotMapped]
        public IFormFile LogoFile { get; set; }
        [MaxLength(1500)]
        public string  ContactInfo { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(250)]
        public string WorkTime { get; set; }
        [Column(TypeName="ntext")]
        public string About { get; set; }
        [MaxLength(250)]
        public string AboutVideo { get; set; }
        [NotMapped]
        public IFormFile AboutVideoFile { get; set; }
    }
}
