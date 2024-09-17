using Microsoft.EntityFrameworkCore;
using TallerPlataformaComercioElectronico.Data;
using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Repositories.Interfaeces;

namespace TallerPlataformaComercioElectronico.Repositories
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetOrdersByUser(string userName)
        {
            return await _context.Orders
                .Where(o => o.UserName == userName)
                .Include(x => x.Detail)
                .ToListAsync();
        }

        public async Task<int> GetQuantityByUser(string userName)
        {
            return await _context.ShoppingCarts
                .Where(o => o.UserName == userName)
                .CountAsync();
        }

        public async Task<IEnumerable<ShoppingCart>> GetShoppingCartsByUser(string userName)
        {
            return await _context.ShoppingCarts
                .Where(o => o.UserName == userName)
                .Include(p => p.Product)
                .Include(b => b.Product.Brand)
                .Include(c => c.Product.Category)
                .ToListAsync();
        }
    }
}