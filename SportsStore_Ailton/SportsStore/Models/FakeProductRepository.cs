using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>()
        {
            new Product() { Name = "Football", Price = 25M },
            new Product() { Name = "Flag", Price = 20M },
            new Product() { Name = "Running shoes", Price = 70M }
        }.AsQueryable<Product>();
    }
}
