using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Models
{
    public class ColorToSizeToProduct
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Color")]
        public int ColorId { get; set; }
        public Color Color { get; set; }
        [ForeignKey("SizeToProduct")]
        public int SizeToProductId { get; set; }
        public SizeToProduct SizeToProduct { get; set; }
        public decimal Quantity { get; set; }
        public List<SaleItem> SaleItems { get; set; }
    }
}
