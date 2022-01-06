using azen.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Products
                                         .Include(pi => pi.ProductImages)
                                         .Include(b => b.Brand)
                                         .Include(cp => cp.CategoryToProducts).ThenInclude(c => c.ProductCategory)
                                         .Include(s => s.SizeToProducts).ThenInclude(cs => cs.ColorToSizeToProducts)
                                         .Include(s => s.SizeToProducts).ThenInclude(si => si.Size)
                                         .ToList());
        }

        public IActionResult Size(int id)
        {
            return View(_context.SizeToProducts
                                                .Include(p => p.Product)
                                                .Include(cs=>cs.ColorToSizeToProducts).ThenInclude(c=>c.Color)
                                                .Include(s=>s.Size)
                                                .FirstOrDefault(c => c.Id == id));
        }
    }
}
