using azen.Data;
using azen.Models;
using azen.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Subscribe(string email)
        {
            VmSubscribeResponse response = new VmSubscribeResponse();

            if (string.IsNullOrEmpty(email))
            {
                response.Status = false;
                response.Message = "Subscribtion faild! You must enter your email";
                return Json(response);
            }

            bool isExist = _context.Subscribes.Any(s => s.Email == email);

            if (isExist)
            {
                response.Status = false;
                response.Message = "Your have already subscribed!";
                return Json(response);
            }

            Subscribe subscribe = new Subscribe();
            subscribe.CreatedDate = DateTime.Now;
            subscribe.Email = email;
            _context.Subscribes.Add(subscribe);
            _context.SaveChanges();

            response.Status = true;
            response.Message = "You subscribe successfully!";
            return Json(response);
        }
    }
}
