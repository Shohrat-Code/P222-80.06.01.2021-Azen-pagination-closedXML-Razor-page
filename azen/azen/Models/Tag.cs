﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string  Name { get; set; }
        public List<TagToBlog> TagToBlogs { get; set; }
    }
}
