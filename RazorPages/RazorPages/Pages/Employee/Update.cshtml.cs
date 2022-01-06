using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;

namespace RazorPages.Pages.Employee
{
    public class UpdateModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public RazorPages.Models.Employee Employee { get; set; }

        public UpdateModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            Employee = _context.Employees.Find(id);
        }

        public IActionResult OnPost()
        {
            _context.Employees.Update(Employee);
            _context.SaveChanges();
            return RedirectToPage("index");
        }
    }
}
