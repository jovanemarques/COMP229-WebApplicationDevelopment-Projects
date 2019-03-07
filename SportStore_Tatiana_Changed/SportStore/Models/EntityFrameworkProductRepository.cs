using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
