using MongoDB.Driver;
using Catalog.API.DAL.Interfaces;
using Catalog.API.Models.Entities;
using Catalog.API.Repositories.Interfaces;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context
                .Products
                .Find(p => true)
                .ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _context
                .Products
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await _context
                .Products
                .Find(p => p.Name == name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            return await _context
                .Products
                .Find(p => p.Category == category)
                .ToListAsync();
        }

        public async Task CreateProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var result = await _context.Products.DeleteOneAsync(p => p.Id == id);

            bool isSuccessful = result.IsAcknowledged && result.DeletedCount > 0;
            return isSuccessful;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x.Id, product.Id);

            var result = await _context.Products.ReplaceOneAsync(filter, product);
            bool isSuccessful = result.IsAcknowledged && result.ModifiedCount > 0;

            return isSuccessful;
        }
    }
}
