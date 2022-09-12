namespace Catalog.API.Models.Settings
{
    public class CatalogDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ProductsCollectionName { get; set; }
    }
}
