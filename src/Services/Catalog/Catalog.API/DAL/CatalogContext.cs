using MongoDB.Driver;
using Catalog.API.DAL.Interfaces;
using Catalog.API.Models.Entities;
using Catalog.API.Models.Settings;
using Microsoft.Extensions.Options;

namespace Catalog.API.DAL
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IOptions<CatalogDbSettings> configuration)
        {
            var mongoClient = new MongoClient(configuration.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(configuration.Value.DatabaseName);

            Products = mongoDatabase.GetCollection<Product>(configuration.Value.ProductsCollectionName);
            CatalogContextSeeder.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; set; }
    }
}
