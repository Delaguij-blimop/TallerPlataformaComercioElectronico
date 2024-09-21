using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Services.Interfaces
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart> GetById(int shoppingCartId);
        Task<int> Insert(ShoppingCart shoppingCart);
        Task<bool> Delete(int shoppingCartId);
        Task<bool> UpdateQuantity(ShoppingCart shoppingCart);
        Task<int> GetQuantityByUser(string userName);
        Task<IEnumerable<ShoppingCart>> GetShoppingCartsByUser(string userName);
        Task<IEnumerable<ShoppingCart>> GetShoppingCartsByUserAndProduct(string userName, int productId);
        Task<IEnumerable<Order>> GetOrdersByUser(string userName);
        Task<bool> ExistsProductInShoppingCart(int productId, string userName);
    }
}
