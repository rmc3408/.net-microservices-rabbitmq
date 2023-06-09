﻿using catalog.API.Entities;
using catalog.API.Database;
using MongoDB.Driver;

namespace catalog.API.BusinessServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoContext _mongoContext;

        public ProductService(IMongoContext products)
        {
            this._mongoContext = products ?? throw new ArgumentNullException(nameof(products));
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await this._mongoContext.Products.Find(p => true).ToListAsync<Product>();
        }
        public async Task<Product> GetProductById(string id)
        {
            var builder = Builders<Product>.Filter;
            FilterDefinition<Product> filter = builder.Eq(product => product.Id, id);
            return await this._mongoContext.Products.Find(filter).FirstOrDefaultAsync<Product>();
        }
        public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            var builder = Builders<Product>.Filter;
            var filter = builder.Eq(product => product.Category, category);
            return await this._mongoContext.Products.Find(filter).ToListAsync();
        }
        public async Task CreateProduct(Product product)
        {
            await this._mongoContext.Products.InsertOneAsync(product);
        }
        public async Task<bool> DeleteProduct(string id)
        {
            var builder = Builders<Product>.Filter;
            var filter = builder.Eq(product => product.Id, id);
            DeleteResult result = await this._mongoContext.Products.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await this._mongoContext.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.IsModifiedCountAvailable;
        }
    }
}
