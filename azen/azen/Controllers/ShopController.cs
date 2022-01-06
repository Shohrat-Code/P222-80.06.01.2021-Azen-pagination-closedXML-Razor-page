using azen.Data;
using azen.Models;
using azen.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace azen.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            VmProduct model = new VmProduct();
            model.Products = _context.Products
                                     .Include("ProductImages")
                                     .Include(c=>c.SizeToProducts)
                                     .ThenInclude(cs=>cs.ColorToSizeToProducts).ToList();

            string oldData = Request.Cookies["cart"];
            if (!string.IsNullOrEmpty(oldData))
            {
                model.Cart = oldData.Split("-").ToList();
            }
            return View(model);
        }

        public IActionResult AddToCart(int id)
        {
            string oldData = Request.Cookies["cart"];
            string newData = null;

            if (string.IsNullOrEmpty(oldData))
            {
                newData = id.ToString();
            }
            else
            {
                List<string> cartArr = oldData.Split("-").ToList();
                if (cartArr.Any(a => a == id.ToString()))
                {
                    cartArr.Remove(id.ToString());
                    newData = string.Join("-", cartArr);
                }
                else
                {
                    newData = oldData + "-" + id;
                }
            }


            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddYears(1)
            };
            Response.Cookies.Append("cart", newData, options);

            return RedirectToAction("index");
        }

        public IActionResult Cart()
        {
            string oldData = Request.Cookies["cart"];
            List<ColorToSizeToProduct> products = new List<ColorToSizeToProduct>();

            if (!string.IsNullOrEmpty(oldData))
            {
                List<string> dataList = oldData.Split("-").ToList();
                products = _context.ColorToSizeToProducts.Include(sp => sp.SizeToProduct).ThenInclude(pr => pr.Product).ThenInclude(pi => pi.ProductImages)
                                                                                    .Where(p => dataList.Any(d => d == p.Id.ToString())).ToList();
            }

            return View(products);
        }


        public IActionResult Checkout()
        {

            string oldData = Request.Cookies["cart"];
            VmCheckout model = new VmCheckout();
            if (!string.IsNullOrEmpty(oldData))
            {
                List<string> dataList = oldData.Split("-").ToList();
                model.Products = _context.ColorToSizeToProducts.Include(sp => sp.SizeToProduct).ThenInclude(pr => pr.Product)
                                                                                    .Where(p => dataList.Any(d => d == p.Id.ToString())).ToList();
                model.Countries = _context.Countries.ToList();
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Order(VmCheckout model)
        {
            if (ModelState.IsValid)
            {
                //Check stock
                string oldData = Request.Cookies["cart"];
                List<ColorToSizeToProduct> products = new List<ColorToSizeToProduct>();

                if (!string.IsNullOrEmpty(oldData))
                {
                    List<string> dataList = oldData.Split("-").ToList();
                    products = _context.ColorToSizeToProducts.Include(sp => sp.SizeToProduct).ThenInclude(pr => pr.Product)
                                                                                        .Where(p => dataList.Any(d => d == p.Id.ToString())).ToList();
                    foreach (var item in products)
                    {
                        if (item.Quantity<1)
                        {
                            HttpContext.Session.SetString("StockError", "Stock is not enought!");
                            return RedirectToAction("Checkout");
                        }
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }

                //Request to Bank
                bool IsOk = true;


                if (IsOk)
                {

                    Response.Cookies.Delete("cart");

                    //Update product
                    foreach (var item in products)
                    {
                        item.Quantity -= 1;
                        _context.ColorToSizeToProducts.Update(item);
                        _context.SaveChanges();
                    }

                    //Create new Customer
                    model.Customer.CreatedDate = DateTime.Now;
                    _context.Customers.Add(model.Customer);
                    _context.SaveChanges();

                    //Create sale
                    Sale lastSale = _context.Sales.OrderByDescending(o => o.CreatedDate).FirstOrDefault();
                    int InvoiceNo = lastSale != null ? lastSale.InvoiceNo + 1 : 1;

                    Sale sale = new Sale();
                    sale.CutomerId = model.Customer.Id;
                    sale.CreatedDate = DateTime.Now;
                    sale.InvoiceNo = InvoiceNo;

                    _context.Sales.Add(sale);
                    _context.SaveChanges();

                    foreach (var item in products)
                    {
                        SaleItem saleItem = new SaleItem();
                        saleItem.Price = item.SizeToProduct.Price;
                        saleItem.Quantity = 1;
                        saleItem.SaleId = sale.Id;
                        saleItem.ColorToSizeToProductId = item.Id;

                        _context.SaleItems.Add(saleItem);
                    }

                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Checkout", new { model });
                }
            }
            else
            {
                return RedirectToAction("Checkout", new { model });
            }
        }

    }
}
