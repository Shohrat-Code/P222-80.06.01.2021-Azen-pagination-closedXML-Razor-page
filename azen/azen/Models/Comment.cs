using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(1500)]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Blog")]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        [ForeignKey("Commenter")]
        public int CommenterId { get; set; }
        public Commenter Commenter { get; set; }
        [ForeignKey("ParentComment")]
        public int ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
    }
}
