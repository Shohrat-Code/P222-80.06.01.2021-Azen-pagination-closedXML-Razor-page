using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public int InvoiceNo{ get; set; }
        public DateTime CreatedDate{ get; set; }
        [ForeignKey("Customer")]
        public int CutomerId { get; set; }
        public Customer Customer { get; set; }
        public List<SaleItem> SaleItems { get; set; }
    }
}
