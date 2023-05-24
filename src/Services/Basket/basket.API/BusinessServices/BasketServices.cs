using basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace basket.API.BusinessServices
{
    public class BasketServices : IBasketServices
    {
        private readonly IDistributedCache _basketContext;

        public BasketServices(IDistributedCache basket)
        {
            this._basketContext = basket ?? throw new ArgumentNullException(nameof(basket));
        }

        public async Task DeleteBasket(string name)
        {
            await this._basketContext.RemoveAsync(name);
        }

        public async Task<Cart> GetBasket(string name)
        {
            var basketStored = await this._basketContext.GetStringAsync(name);
            if (basketStored == null)
            {
                return null;
            }
            Cart cart = JsonSerializer.Deserialize<Cart>(basketStored);
            return cart;
        }

        public async Task<Cart> UpdateBasket(Cart basket)
        {
            await this._basketContext.SetStringAsync(basket.Username, JsonSerializer.Serialize<Cart>(basket));
            return await GetBasket(basket.Username);
        }
    }
}
