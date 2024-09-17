using Microsoft.EntityFrameworkCore;
using TallerPlataformaComercioElectronico.Data;
using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Repositories.Interfaeces;

namespace TallerPlataformaComercioElectronico.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetAllWithIncludesAsync()
        {
            return await _context.Products
                .Include(c => c.Category)
                .Include(c => c.Brand)
                .ToListAsync();
        }
    }
}