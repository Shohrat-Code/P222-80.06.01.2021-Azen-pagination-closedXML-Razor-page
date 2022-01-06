using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        [MaxLength(1000)]
        public string About { get; set; }
        [Column(TypeName ="ntext")]
        public string Desc { get; set; }

        public List<CategoryToProduct> CategoryToProducts { get; set; }
        public List<ProductTagToProduct> ProductTagToProducts { get; set; }
        public List<ProductComment> ProductComments { get; set; }
        public List<SizeToProduct> SizeToProducts { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
