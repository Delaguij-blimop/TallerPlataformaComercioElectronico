using System.Drawing.Drawing2D;
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

        public async Task<bool> Insert(ShoppingCart shoppingCart)
        {
            bool response = false;
            try
            {
                await _shoppingCartRepository.InsertAsync(shoppingCart);
                await _shoppingCartRepository.SaveAsync();
                response = true;
            }
            catch (Exception ex)
            {
                response = false;
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

        public async Task<IEnumerable<ShoppingCart>> GetShoppingCartsByUserAndProduct(string userName, int productId)
        {
            IEnumerable<ShoppingCart> lst = new List<ShoppingCart>();
            try
            {
                lst = await _shoppingCartRepository.GetShoppingCartsByUserAndProduct(userName, productId);
            }
            catch (Exception ex)
            {
                lst = new List<ShoppingCart>();
            }
            return lst;
        }

        public async Task<bool> Delete(int shoppingCartId)
        {
            bool response = true;
            try
            {
                await _shoppingCartRepository.DeleteAsync(shoppingCartId);
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

        public async Task<bool> ExistsProductInShoppingCart(int productId, string userName)
        {
            var cart = await GetShoppingCartsByUserAndProduct(userName, productId);
            return cart.Any();
        }

        public async Task<ShoppingCart> GetById(int shoppingCartId)
        {
            ShoppingCart response = new ShoppingCart();
            try
            {
                response = await _shoppingCartRepository.GetByIdAsync(shoppingCartId);
            }
            catch (Exception ex)
            {
                response = new ShoppingCart();
            }
            return response;
        }

        public async Task<bool> UpdateQuantity(ShoppingCart shoppingCart)
        {
            bool response = true;
            try
            {
                ShoppingCart cartToUpdate = await _shoppingCartRepository.GetByIdAsync(shoppingCart.Id);

                cartToUpdate.Quantity = shoppingCart.Quantity;

                await _shoppingCartRepository.UpdateAsync(cartToUpdate);
                await _shoppingCartRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }
    }
}
