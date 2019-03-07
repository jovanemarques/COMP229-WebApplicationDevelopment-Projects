using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;

namespace SportStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public IActionResult List(string category, int productPage = 1)
        {
            return View(new ProductListViewModel
            {
                Products = repository.Products
                        .Where(p=>category==null||p.Category==category)
                        .OrderBy(p => p.ProductID)
                        .Skip((productPage - 1) * PageSize)
                        .Take(PageSize),


                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    // TotalItems = repository.Products.Count()
                    TotalItems = category == null ?
                        repository.Products.Count() :
                        repository.Products.Where(e =>
                        e.Category == category).Count()
                },
                CurrentCategory = category
            });

           //return View(repository.Products.OrderBy(p=>p.ProductID).Skip((productPage-1)*PageSize).Take(PageSize)); //will be IQuarable of products // order by order ID
        }
    }
}