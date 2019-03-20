using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using System.Linq;

namespace SportStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View(repository.Products);
        }
        public ViewResult Edit(int productId) =>
            View(repository.Products.FirstOrDefault(p => p.ProductID == productId));

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public ViewResult Create() =>
            View("Edit", new Product());
        public IActionResult Delete(int productId)
        {
            Product product = repository.DeleteProduct(productId);
            if (product != null)
            {
                TempData["message"] = $"{product.Name} has been deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
