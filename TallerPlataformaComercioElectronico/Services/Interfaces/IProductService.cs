using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllWithIncludes();
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<bool> Insert(Product product);
        Task<bool> Update(Product product);
        Task<bool> UpdateImagePath(Product product);
        Task<bool> Delete(int id);
        Task<int> GetProductStock(int id);
    }
}
