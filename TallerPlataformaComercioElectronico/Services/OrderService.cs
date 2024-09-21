using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Repositories.Interfaeces;
using TallerPlataformaComercioElectronico.Services.Interfaces;

namespace TallerPlataformaComercioElectronico.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<ShoppingCart> _shoppingCartRepository;

        public OrderService(IGenericRepository<Order> orderRepository, IGenericRepository<ShoppingCart> shoppingCartRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<bool> Insert(Order order)
        {
            bool respuesta = true;
            try
            {
                await _orderRepository.InsertAsync(order);
                await _orderRepository.SaveAsync();

                var activeShoppingCarts = await _shoppingCartRepository.GetAllAsync();
                foreach (var cart in activeShoppingCarts.Where(x => x.UserName == order.UserName && x.IsActive == true))
                {
                    cart.IsActive = false;
                    cart.OrderId = order.Id;
                }
                await _shoppingCartRepository.SaveAsync();

            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            return respuesta;
        }
    }
}
