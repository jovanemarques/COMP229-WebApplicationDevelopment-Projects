﻿using System.Linq;

namespace SportStore.Models
{
    public class EntityFrameworkProductRepository : IProductRepository
    {
        private ApplicationDBContext context;

        public EntityFrameworkProductRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;

        public Product DeleteProduct(int productId)
        {
            Product product = context.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product productDb = context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);
                productDb.Name = product.Name;
                productDb.Description = product.Description;
                productDb.Price = product.Price;
                productDb.Category = product.Category;
            }
            context.SaveChanges();
        }
    }
}
