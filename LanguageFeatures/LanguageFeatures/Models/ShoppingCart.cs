using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class ShoppingCart:IEnumerable<Product>
    //public class ShoppingCart
    {
        public IEnumerable<Product> Products { get; set; }

        public IEnumerator<Product> GetEnumerator()
        {
            return Products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // can not do that because the class can be a lib.. have to do a extension method
        //public decimal? TotalPrice()
        //{
        //    decimal? total = 0;
        //    foreach (Product p in Products)
        //    {
        //        total += p.Price;
        //    }
        //    return total;
        //}
    }
}
