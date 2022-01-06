using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public int PageCount = 6;
        public IndexModel()
        {
        }

        public void OnGet()
        {

        }
    }
}
