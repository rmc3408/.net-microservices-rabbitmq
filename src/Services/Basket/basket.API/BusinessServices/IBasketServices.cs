using basket.API.Entities;

namespace basket.API.BusinessServices
{
    public interface IBasketServices
    {
        Task<Cart> GetBasket(string name);
        Task<Cart> UpdateBasket(Cart basket);
        Task DeleteBasket(string name);
    }
}
