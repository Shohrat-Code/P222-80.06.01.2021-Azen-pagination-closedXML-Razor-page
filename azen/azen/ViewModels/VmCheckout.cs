using azen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azen.ViewModels
{
    public class VmCheckout
    {
        public List<ColorToSizeToProduct> Products { get; set; }
        public List<Country> Countries { get; set; }
        public Customer Customer { get; set; }
    }
}
