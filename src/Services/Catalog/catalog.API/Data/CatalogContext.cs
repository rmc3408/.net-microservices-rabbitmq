using catalog.API.Entities;
using MongoDB.Driver;

namespace catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private MongoClient _client;
        public IMongoCollection<Product> Products { get; }

        // From Dep Injection
        public CatalogContext(IConfiguration config)
        {
            string collectionName = config.GetValue<string>("DatabaseSettings:CollectionName");
            string databaseName = config.GetValue<string>("DatabaseSettings:DatabaseName");
            string connectionString = config.GetValue<string>("DatabaseSettings:ConnectionStrings");

            this._client = new MongoClient(connectionString);
            var databaseCreated = this._client.GetDatabase(databaseName);
            this.Products = databaseCreated.GetCollection<Product>(collectionName);
            SeedProductData.populateData(Products);
        }
    }
}
