using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Repositories.Interfaeces
{
    public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
    {
        Task<int> GetQuantityByUser(string userName);
        Task<IEnumerable<ShoppingCart>> GetShoppingCartsByUser(string userName);
        Task<IEnumerable<ShoppingCart>> GetShoppingCartsByUserAndProduct(string userName, int productId);
        Task<IEnumerable<Order>> GetOrdersByUser(string userName);
    }
}