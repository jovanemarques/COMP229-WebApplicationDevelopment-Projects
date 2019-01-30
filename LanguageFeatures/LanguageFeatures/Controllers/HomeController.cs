using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ViewResult> Index()
        {
            long? length = await MyAsyncMethod.GetPageLength();
            return View(new[] { $"Length: {length}" });
        }
        // -- 6
        //public ViewResult Index()
        //{
        //    var products = new[]
        //    {
        //        new Product{ Name="Ball", Price=10M},
        //        new Product{ Name="Flag", Price=5M}
        //    };
        //    return View(products.Select(p => p.Name));
        //    //return View(products.Select(p => p.GetType().Name));
        //}
        //public ViewResult Index() => View(Product.GetProducts().Select(p => p?.Name));

        // -- 5
        //bool FilterByName(Product p) {
        //    return (p?.Name?[0] == 'L');
        //}
        //bool FilterByPrice(Product p)
        //{
        //    return (p?.Price >= 7M);
        //}
        //        public ViewResult Index()
        //        {

        //            return View(Product.GetProducts().Select(p => p?.Name));

        //            //ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
        //            //decimal? total = cart.TotalPrice();

        //            //Product[] prodArray = new Product[]
        //            //{
        //            //    new Product{ Name="Ball", Price=10M},
        //            //    new Product{ Name="Flag", Price=5M}
        //            //};

        //            //Func<Product, bool> filterName = delegate (Product p) { return (p?.Price >= 7M); };

        //            //decimal arrayTotal = prodArray.Filter(p => (p?.Price >= 7M)).TotalPrice();
        //            ////decimal arrayTotal = prodArray.Filter(filterName).TotalPrice();
        //            ////            decimal arrayTotal = prodArray.Filter(FilterByPrice).TotalPrice();
        //            ////decimal arrayTotal = prodArray.FilterByPrice(7M).TotalPrice();
        //            ////decimal arrayTotal = prodArray.TotalPrice();
        //            //decimal shoppingCartTotal = cart.Filter(FilterByName).TotalPrice();
        //            ////decimal shoppingCartTotal = cart.FilterByName('L').TotalPrice();
        //            ////decimal shoppingCartTotal = cart.FilterByPrice(100M).TotalPrice();

        //            //return View(new string[] { $"Cart total: {total}", $"Array total: {arrayTotal}",
        //            //    $"Shopping cart total: {shoppingCartTotal}" });

        //            //--3
        //            //object[] data = new object[] { 12M, 11, "ten", 23, 1.0, "two", 1M };
        //            //decimal totalDecimal = 0;
        //            //int totalInt = 0;
        //            //for (int i = 0; i < data.Length; i++)
        //            //{
        //            //    switch (data[i])
        //            //    {
        //            //        case decimal d:
        //            //            totalDecimal += d;
        //            //            break;
        //            //        case int k when k > 15:
        //            //        //case int k:
        //            //            totalInt += k;
        //            //            break;
        //            //        default:
        //            //            break;
        //            //    }

        //            //if (data[i] is decimal d)
        //            //{
        //            //    total += d;
        //            //}

        //            //return View(new string[] { $"Decimal total: {totalDecimal}, Integer total: {totalInt}" });
        ////--2
        //            //Dictionary<string, Product> products = new Dictionary<string, Product>()
        //            //{
        //            //    ["Kayak"] = new Product() { Name = "Kayak", Price = 275M, Category = "Water craft" },
        //            //    ["LifeJacket"] = new Product(false) { Name = "LifeJacket", Price = 49.99M }
        //            //    //{ "Kayak", new Product() { Name = "Kayak", Price = 275M, Category = "Water craft" } },
        //            //    //{ "LifeJacket", new Product(false) { Name = "LifeJacket", Price = 49.99M } }
        //            //};
        //            ////products["Kayak"] = new Product() { Name = "Kayak", Price = 275M, Category = "Water craft" };
        //            //return View(products.Keys);

        //        //--1
        //            //List<string> result = new List<string>();
        //            //foreach (Product p in Product.GetProducts())
        //            //{
        //            //    string name = p?.Name ?? "<No name>";
        //            //    decimal? price = p?.Price ?? 0;
        //            //    string related = p?.Related?.Name ?? "<No related product>";
        //            //    string category = p?.Category ?? "<No category>";
        //            //    bool? inStock = p?.InStock ?? false;
        //            //    result.Add($"Name: {name}, Price: {price:c}, Related: {related}, Category: {category}, InStock: {inStock}");
        //            //}
        //            ////return View(new string[] { "COMP229", "Advanced Web Dev", "ASP.NET Core" });
        //            //return View(result);
        //        }
    }
}