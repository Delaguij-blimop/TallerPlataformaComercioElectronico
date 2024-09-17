using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Repositories.Interfaeces
{
    public interface ICityRepository : IGenericRepository<City>
    {
        Task<IEnumerable<City>> GetCitiesByStateAsync(int stateId);
    }
}