using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Repositories.Interfaeces;
using TallerPlataformaComercioElectronico.Services.Interfaces;

namespace TallerPlataformaComercioElectronico.Services
{
    public class GeoService : IGeoService
    {
        private readonly IGenericRepository<Country> _countryRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;

        public GeoService(IGenericRepository<Country> countryRepository, IStateRepository stateRepository, ICityRepository cityRepository)
        {
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            IEnumerable<Country> lst = new List<Country>();
            try
            {
                lst = await _countryRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                lst = new List<Country>();
            }
            return lst;
        }

        public async Task<IEnumerable<State>> GetStates(int countryId)
        {
            IEnumerable<State> lst = new List<State>();
            try
            {
                lst = await _stateRepository.GetStatesByCountryAsync(countryId);
            }
            catch (Exception ex)
            {
                lst = new List<State>();
            }
            return lst;
        }

        public async Task<IEnumerable<City>> GetCities(int stateId)
        {
            IEnumerable<City> lst = new List<City>();
            try
            {
                lst = await _cityRepository.GetCitiesByStateAsync(stateId);
            }
            catch (Exception ex)
            {
                lst = new List<City>();
            }
            return lst;
        }

    }
}
