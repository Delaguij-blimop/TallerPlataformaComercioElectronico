using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Repositories.Interfaeces;
using TallerPlataformaComercioElectronico.Services.Interfaces;

namespace TallerPlataformaComercioElectronico.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllWithIncludes()
        {
            IEnumerable<Product> productList = new List<Product>();
            try
            {
                productList = await _productRepository.GetAllWithIncludesAsync();
            }
            catch (Exception ex)
            {
                productList = new List<Product>();
            }
            return productList;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            IEnumerable<Product> productList = new List<Product>();
            try
            {
                productList = await _productRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                productList = new List<Product>();
            }
            return productList;
        }

        public async Task<Product> GetById(int id)
        {
            Product product = new Product();
            try
            {
                product = await _productRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                product = new Product();
            }
            return product;
        }

        public async Task<bool> Insert(Product product)
        {
            bool respuesta = true;
            try
            {
                await _productRepository.InsertAsync(product);
                await _productRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            return respuesta;
        }

        public async Task<bool> Update(Product product)
        {
            bool respuesta = true;
            try
            {
                Product productOrig = await _productRepository.GetByIdAsync(product.Id);
                productOrig.Description = product.Description;
                productOrig.BrandId = product.BrandId;
                productOrig.CategoryId = product.CategoryId;
                productOrig.Price = product.Price;
                productOrig.Stock = product.Stock;
                productOrig.ImagePath = product.ImagePath;
                productOrig.RegisterDate = product.RegisterDate;

                await _productRepository.UpdateAsync(productOrig);
                await _productRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            return respuesta;
        }


        public async Task<bool> UpdateImagePath(Product product)
        {
            bool respuesta = true;
            try
            {
                Product productOrig = await _productRepository.GetByIdAsync(product.Id);
                productOrig.ImagePath = product.ImagePath;

                await _productRepository.UpdateAsync(productOrig);
                await _productRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            return respuesta;
        }

        public async Task<bool> Delete(int id)
        {
            bool respuesta = true;
            try
            {
                await _productRepository.DeleteAsync(id);
                await _productRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            return respuesta;

        }

    }
}
