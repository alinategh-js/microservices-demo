using Catalog.API.Models.Entities;
using MongoDB.Driver;

namespace Catalog.API.DAL.Interfaces
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
