namespace LanguageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Category { get; set; } = "Watersports";
        public Product Related { get; set; }
        public bool InStock { get; }
        public bool StartsWithL() => Name?[0] == 'L';
        public Product(bool stock = true)
        {
            InStock = stock;
        }
        public static Product[] GetProducts()
        {
            Product kayak = new Product() { Name = "Kayak", Price = 275M, Category = "Water craft" };
            Product lifejacket = new Product(false) { Name = "LifeJacket", Price = 49.99M };
            kayak.Related = lifejacket;
            return new Product[] { kayak, lifejacket, null };
        }
    }
}
