using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Models
{
    public class ProductComment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(1500)]
        public string  Text { get; set; }
        public byte RatingValue { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Commenter")]
        public int CommenterId { get; set; }
        public Commenter Commenter { get; set; }
    }
}
