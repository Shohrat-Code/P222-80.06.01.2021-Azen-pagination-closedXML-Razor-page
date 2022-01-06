using azen.Data;
using azen.Models;
using azen.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(VmSearch search)
        {
            VmBlog model = new VmBlog();
            if (search == null || search.page == null)
            {
                search.page = 1;
            }

            double itemCount = 6;
            List<Blog> blogs = _context.Blogs
                                      .Include(u => u.CustomUser)
                                      .Include(c => c.BlogCategory)
                                      .Where(b => (search.tagId != null ? b.TagToBlogs.Any(tb => tb.TagId == search.tagId) : true) &&
                                                  (search.catId != null ? b.BlogCategoryId == search.catId : true) &&
                                                  (search.searchData != null ? b.Title.Contains(search.searchData) : true)
                                      ).ToList();

            int pageCount = (int)Math.Ceiling(Convert.ToDecimal(blogs.Count / itemCount));


            model.Blogs = blogs.Skip(((int)search.page - 1) * (int)itemCount).Take((int)itemCount).ToList();

            ViewBag.PageCount = pageCount;
            ViewBag.Page = search.page;

            model.Search = search;
            model.BlogCategories = _context.BlogCategories.ToList();
            model.Tags = _context.Tags.ToList();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            return View(_context.Blogs.Include(u => u.CustomUser).Include(c => c.BlogCategory).Include(tb => tb.TagToBlogs).ThenInclude(t => t.Tag).FirstOrDefault(p => p.Id == id));
        }
    }
}
