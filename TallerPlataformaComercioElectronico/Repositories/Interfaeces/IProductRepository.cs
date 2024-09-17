using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Repositories.Interfaeces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWithIncludesAsync();
    }
}