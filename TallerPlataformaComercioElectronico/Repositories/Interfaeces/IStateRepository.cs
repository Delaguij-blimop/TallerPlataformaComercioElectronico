using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Repositories.Interfaeces
{
    public interface IStateRepository : IGenericRepository<State>
    {
        Task<IEnumerable<State>> GetStatesByCountryAsync(int countryid);
    }
}