using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Catalog.API.Models.Entities;

namespace Catalog.API.Models.Requests
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }

        public Product ToProductModel()
        {
            return new Product
            {
                Name = Name,
                Category = Category,
                Summary = Summary,
                Description = Description,
                ImageFile = ImageFile,
                Price = Price,
            };
        }
    }
}
