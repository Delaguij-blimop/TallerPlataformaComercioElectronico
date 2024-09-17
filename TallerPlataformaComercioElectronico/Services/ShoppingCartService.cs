using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Repositories.Interfaeces;
using TallerPlataformaComercioElectronico.Services.Interfaces;

namespace TallerPlataformaComercioElectronico.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<int> Insert(ShoppingCart shoppingCart)
        {
            int response = 0;
            try
            {
                await _shoppingCartRepository.InsertAsync(shoppingCart);
                await _shoppingCartRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                response = 0;
            }
            return response;
        }

        public async Task<int> GetQuantityByUser(string userName)
        {
            int response = 0;
            try
            {
                response = await _shoppingCartRepository.GetQuantityByUser(userName);
            }
            catch (Exception ex)
            {
                response = 0;
            }
            return response;
        }

        public async Task<IEnumerable<ShoppingCart>> GetShoppingCartsByUser(string userName)
        {
            IEnumerable<ShoppingCart> lst = new List<ShoppingCart>();
            try
            {
                lst = await _shoppingCartRepository.GetShoppingCartsByUser(userName);
            }
            catch (Exception ex)
            {
                lst = new List<ShoppingCart>();
            }
            return lst;
        }

        public async Task<bool> Delete(int idCarrito, int idProducto)
        {

            bool response = true;
            try
            {
                await _shoppingCartRepository.DeleteAsync(idCarrito);
                await _shoppingCartRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUser(string userName)
        {
            IEnumerable<Order> ordersList = new List<Order>();
            try
            {
                ordersList = await _shoppingCartRepository.GetOrdersByUser(userName);
            }
            catch (Exception ex)
            {
                ordersList = new List<Order>();
            }
            return ordersList;
        }
    }
}
