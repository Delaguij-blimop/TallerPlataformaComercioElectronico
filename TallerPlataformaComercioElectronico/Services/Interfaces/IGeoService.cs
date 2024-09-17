using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Services.Interfaces
{
    public interface IGeoService
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<IEnumerable<State>> GetStates(int countryId);
        Task<IEnumerable<City>> GetCities(int stateId);
    }
}
