using Microsoft.EntityFrameworkCore;
using TallerPlataformaComercioElectronico.Data;
using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Repositories.Interfaeces;

namespace TallerPlataformaComercioElectronico.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<City>> GetCitiesByStateAsync(int stateId)
        {
            return await _context.Cities
                .Where(st => st.StateId == stateId)
                .ToListAsync();
        }
    }
}