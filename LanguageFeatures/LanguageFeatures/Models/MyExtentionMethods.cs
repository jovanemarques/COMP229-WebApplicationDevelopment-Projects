using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public static class MyExtentionMethods
    {
        public static decimal TotalPrice(this IEnumerable<Product> products)
        //public static decimal TotalPrice(this ShoppingCart cart)
        {
            decimal total = 0;
            foreach (Product p in products)
            {
                total += p?.Price ?? 0;
            }
            return total;
        }
        public static IEnumerable<Product> FilterByPrice(this IEnumerable<Product> products, decimal minPrice)
        {
           // List<Product> result = new List<Product>();
            foreach (Product product in products)
            {
                if ((product?.Price ?? 0) >= minPrice) 
                {
                    yield return product;
                    //result.Add(product);
                }
            }
            //return result;
        }

        public static IEnumerable<Product> FilterByName(this IEnumerable<Product> products, char firstLetter)
        {
            foreach (Product product in products)
            {
                if (product?.Name?[0] == firstLetter)
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> products, 
            Func<Product, bool> selector )
        {
            foreach (Product product in products)
            {
                if (selector(product))
                {
                    yield return product;
                }
            }
        }
    }
}
