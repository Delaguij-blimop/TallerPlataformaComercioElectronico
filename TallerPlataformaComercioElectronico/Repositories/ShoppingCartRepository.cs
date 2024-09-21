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
                .Include(x => x.Payments)
                .Include("Detail.Product")
                .Include("Detail.Product.Brand")
                .ToListAsync();
        }

        public async Task<int> GetQuantityByUser(string userName)
        {
            return await _context.ShoppingCarts
                .Where(o => o.UserName == userName)
                .Where(o => o.IsActive == true)
                .CountAsync();
        }

        public async Task<IEnumerable<ShoppingCart>> GetShoppingCartsByUser(string userName)
        {
            return await _context.ShoppingCarts
                .Where(o => o.UserName == userName)
                .Where(o => o.IsActive == true)
                .Include(p => p.Product)
                .Include(b => b.Product.Brand)
                .Include(c => c.Product.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<ShoppingCart>> GetShoppingCartsByUserAndProduct(string userName, int productId)
        {
            return await _context.ShoppingCarts
                .Where(o => o.UserName == userName)
                .Where(o => o.ProductId == productId)
                .Where(o => o.IsActive == true)
                .Include(p => p.Product)
                .Include(b => b.Product.Brand)
                .Include(c => c.Product.Category)
                .ToListAsync();
        }
    }
}