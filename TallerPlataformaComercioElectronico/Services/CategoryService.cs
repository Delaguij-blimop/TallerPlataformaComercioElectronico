using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Repositories.Interfaeces;
using TallerPlataformaComercioElectronico.Services.Interfaces;

namespace TallerPlataformaComercioElectronico.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                var categoryList = await _categoryRepository.GetAllAsync();
                return categoryList;
            }
            catch (Exception ex)
            {
                return new List<Category>();
            }
        }


        public async Task<bool> Insert(Category category)
        {
            bool response = true;
            try
            {
                await _categoryRepository.InsertAsync(category);
                await _categoryRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }

        public async Task<bool> Update(Category category)
        {
            bool response = true;
            try
            {
                var categoryToUpdate = await _categoryRepository.GetByIdAsync(category.Id);
                categoryToUpdate.Description = category.Description;

                await _categoryRepository.UpdateAsync(categoryToUpdate);
                await _categoryRepository.SaveAsync();
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
                await _categoryRepository.DeleteAsync(id);
                await _categoryRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;

        }

    }
}
