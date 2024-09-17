using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Services.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAll();
        Task<bool> Insert(Brand brand);
        Task<bool> Update(Brand brand);
        Task<bool> Delete(int id);
    }
}
