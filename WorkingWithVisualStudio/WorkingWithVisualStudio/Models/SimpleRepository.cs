using System.Collections.Generic;

namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository
    {
        private static SimpleRepository sharedRepository = new SimpleRepository();
        private Dictionary<string, Product> products = new Dictionary<string, Product>();
        public static SimpleRepository SharedRepository => sharedRepository;
        public SimpleRepository()
        {
            var initialItems = new[]
            {
                new Product{ Name="Kayak", Price=275M},
                new Product{ Name="Lifejacket", Price=49.99M},
                new Product{ Name="Ball", Price=29.99M},
                new Product{ Name="Flag", Price=9.99M}
            };
            foreach (var p in initialItems)
            {
                AddProducts(p);
            }
        }

        public void AddProducts(Product p) => products.Add(p.Name, p);
        public IEnumerable<Product> Produtcs => products.Values;
    }
}
