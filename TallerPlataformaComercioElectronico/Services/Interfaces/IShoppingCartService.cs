using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Services.Interfaces
{
    public interface IShoppingCartService
    {
        Task<int> Insert(ShoppingCart shoppingCart);
        Task<bool> Delete(int shoppingCartId, int productId);
        Task<int> GetQuantityByUser(string userName);
        Task<IEnumerable<ShoppingCart>> GetShoppingCartsByUser(string userName);
        Task<IEnumerable<ShoppingCart>> GetShoppingCartsByUserAndProduct(string userName, int productId);
        Task<IEnumerable<Order>> GetOrdersByUser(string userName);
    }
}
