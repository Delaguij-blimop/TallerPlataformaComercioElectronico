using Microsoft.EntityFrameworkCore;
using TallerPlataformaComercioElectronico.Data;
using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Repositories.Interfaeces;

namespace TallerPlataformaComercioElectronico.Repositories
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        public StateRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<State>> GetStatesByCountryAsync(int countryId)
        {
            return await _context.States
                .Where(st => st.CountryId == countryId)
                .ToListAsync();
        }
    }
}