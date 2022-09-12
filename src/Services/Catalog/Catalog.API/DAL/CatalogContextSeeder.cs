using MongoDB.Driver;
using Catalog.API.Models.Entities;

namespace Catalog.API.DAL
{
    public class CatalogContextSeeder
    {
        public static void SeedData(IMongoCollection<Product> Products)
        {
            bool anyProducts = Products.Find(x => true).Any();

            if (!anyProducts)
            {
                Products.InsertMany(GetInitialProducts());
            }
        }

        public static IEnumerable<Product> GetInitialProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Test 1",
                    Category = "Category 1",
                    Description = "This is the description for this product",
                    ImageFile = "",
                    Price = 15,
                    Summary = "summary..."
                },
                new Product
                {
                    Name = "Test 2",
                    Category = "Category 1",
                    Description = "This is the description for this product",
                    ImageFile = "",
                    Price = 22,
                    Summary = "summary..."
                },
                new Product
                {
                    Name = "Test 3",
                    Category = "Category 2",
                    Description = "This is the description for this product",
                    ImageFile = "",
                    Price = 48,
                    Summary = "summary..."
                },
            };
        }
    }
}
