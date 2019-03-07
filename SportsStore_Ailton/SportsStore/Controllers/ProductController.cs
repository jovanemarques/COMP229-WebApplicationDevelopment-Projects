﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        
        public IActionResult List(string category, int productPage = 1)
        {
            return View(new ProductsListViewModel()
            {
                Products = repository.Products.Where(p => category == null || p.Category == category)
                        .OrderBy(p => p.ProductId).Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = (category == null) ? repository.Products.Count() :
                        repository.Products.Where(p => category == null || p.Category == category).Count()
                },
                CurrentCategory = category
            });
        }
    }
}