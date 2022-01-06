using azen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azen.ViewModels
{
    public class VmBlog
    {
        public List<Blog> Blogs { get; set; }
        public List<BlogCategory> BlogCategories{ get; set; }
        public List<Tag> Tags { get; set; }
        public VmSearch Search { get; set; }
    }
}
