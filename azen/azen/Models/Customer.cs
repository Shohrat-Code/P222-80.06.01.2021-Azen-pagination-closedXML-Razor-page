using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string SurName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(1500)]
        public string Note { get; set; }
        [MaxLength(50)]
        public string Company { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(150)]
        public string Street { get; set; }
        [MaxLength(10)]
        public string PostCode { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
