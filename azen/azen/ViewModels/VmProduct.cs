using azen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azen.ViewModels
{
    public class VmProduct
    {
        public List<Product> Products { get; set; }
        public List<string> Cart { get; set; }
    }
}
