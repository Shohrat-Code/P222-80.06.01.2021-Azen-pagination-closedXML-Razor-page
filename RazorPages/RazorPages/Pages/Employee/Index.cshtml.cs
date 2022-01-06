using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;

namespace RazorPages.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<RazorPages.Models.Employee> employees; 

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            employees = _context.Employees.ToList();
        }
    }
}
