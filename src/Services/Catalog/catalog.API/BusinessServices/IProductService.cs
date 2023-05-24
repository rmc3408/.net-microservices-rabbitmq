using catalog.API.Entities;

namespace catalog.API.BusinessServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(string id);
        Task<IEnumerable<Product>> GetProductsByCategory(string category);
        Task CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);

    }
}
