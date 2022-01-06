using azen.Data;
using azen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azen.ViewComponents
{
    public class VcBasket : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public VcBasket(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

        }
        public IViewComponentResult Invoke()
        {
            string oldData = _httpContextAccessor.HttpContext.Request.Cookies["cart"];
            List<ColorToSizeToProduct> products = new List<ColorToSizeToProduct>();

            if (!string.IsNullOrEmpty(oldData))
            {
                List<string> dataList = oldData.Split("-").ToList();
                products = _context.ColorToSizeToProducts.Include(sp => sp.SizeToProduct).ThenInclude(pr=>pr.Product).ThenInclude(pi=>pi.ProductImages)
                                                                                    .Where(p => dataList.Any(d => d == p.Id.ToString())).ToList();
            }

            return View(products);
        }
    }
}
