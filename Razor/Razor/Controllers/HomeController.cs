using Microsoft.AspNetCore.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Product myProduct = new Product
            Product[] productArray = new[]{
                new Product
                {
                    ProductID = 1,
                    Name = "Kayak",
                    Description = "A boat",
                    Price = 275M,
                    Category = "Watersports"
                },
                  new Product
                  {
                      Name = "Lifejacket",
                      Price = 99M
                  },
                new Product
                {
                    Name = "Ball",
                    Price = 29.99M
                },
                new Product
                {
                    Name = "Lifejacket",
                    Price = 99M
                } }
                ;

            //ViewBag.StockLevel = 4;
            //ViewBag.StockLevel = 0;
            ViewBag.StockLevel = 2;

            //return View(myProduct);
            return View(productArray);
        }
    }
}