using Basket.API.Models.Entities;

namespace Basket.API.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<ShoppingCart?> GetCart(string username);
        Task<ShoppingCart?> UpdateCart(ShoppingCart basket);
        Task DeleteCart(string username);
    }
}
