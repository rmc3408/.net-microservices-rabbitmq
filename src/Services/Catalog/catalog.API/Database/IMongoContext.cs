using catalog.API.Entities;
using MongoDB.Driver;

namespace catalog.API.Database
{
    public interface IMongoContext
    {
        IMongoCollection<Product> Products { get;  }
    }
}
