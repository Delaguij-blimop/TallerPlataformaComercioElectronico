using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Repositories.Interfaeces;
using TallerPlataformaComercioElectronico.Services.Interfaces;

namespace TallerPlataformaComercioElectronico.Services
{
    public class BrandService : IBrandService
    {
        private readonly IGenericRepository<Brand> _brandRepository;

        public BrandService(IGenericRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<IEnumerable<Brand>> GetAll()
        {

            try
            {
                var brandsList = await _brandRepository.GetAllAsync();
                return brandsList;

            }
            catch (Exception ex)
            {
                return new List<Brand>();
            }
        }


        public async Task<bool> Insert(Brand brand)
        {
            bool response = true;
            try
            {
                await _brandRepository.InsertAsync(brand);
                await _brandRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }

        public async Task<bool> Update(Brand brand)
        {
            bool response = true;
            try
            {
                Brand brandToUpdate = await _brandRepository.GetByIdAsync(brand.Id);
                brandToUpdate.Description = brand.Description;
                await _brandRepository.UpdateAsync(brandToUpdate);
                await _brandRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }

        public async Task<bool> Delete(int id)
        {
            bool response = true;
            try
            {
                await _brandRepository.DeleteAsync(id);
                await _brandRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }
    }
}
