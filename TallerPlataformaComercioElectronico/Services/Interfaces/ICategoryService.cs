using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<bool> Insert(Category category);
        Task<bool> Update(Category category);
        Task<bool> Delete(int id);
    }
}
