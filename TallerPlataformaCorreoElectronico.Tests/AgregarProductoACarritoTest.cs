using Microsoft.EntityFrameworkCore;
using TallerPlataformaComercioElectronico.Data;
using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Repositories;
using TallerPlataformaComercioElectronico.Services;
using TallerPlataformaComercioElectronico.Services.Interfaces;

namespace TallerPlataformaComercioElectronico.Tests.Tests
{
    public class AgregarProductoACarritoTest
    {
        private ApplicationDbContext _context;
        private IShoppingCartService _shoppingCartService;
        private IProductService _productService;
        private IBrandService _brandService;
        private ICategoryService _categpryService;
        private int _productId;
        private int _productIdNoStock;


        [SetUp]
        public void Setup()
        {
            _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
            _shoppingCartService = new ShoppingCartService(new ShoppingCartRepository(_context));
            _brandService = new BrandService(new GenericRepository<Brand>(_context));
            _categpryService = new CategoryService(new GenericRepository<Category>(_context));
            _productService = new ProductService(new ProductRepository(_context));

            //Inicializa datos de prueba en la base de datos en memoria
            var brand = new Brand { Description = "Marca de prueba" };
            _brandService.Insert(brand);

            var category = new Category { Description = "Categoria de prueba" };
            _categpryService.Insert(category);

            var product = new Product { Description = "Producto de prueba", BrandId = brand.Id, CategoryId = category.Id, Price = 100, Stock = 5, RegisterDate = DateTime.Today };
            _productService.Insert(product);
            _productId = product.Id;

            var productNoStock = new Product { Description = "Producto de prueba Sin Stock", BrandId = brand.Id, CategoryId = category.Id, Price = 100, Stock = 0, RegisterDate = DateTime.Today };
            _productService.Insert(productNoStock);
            _productIdNoStock = productNoStock.Id;

            var cart = _shoppingCartService.Insert(new ShoppingCart { ProductId = _productId, UserName = "testUser", Quantity = 1, IsActive = true });
        }

        [Test]
        public void ProductoExistenteEnCarrito()
        {
            var exists = _shoppingCartService.ExistsProductInShoppingCart(_productId, "testUser").Result;
            Assert.That(exists, Is.True);
        }

        [Test]
        public void ProductoNoExistenteEnCarrito()
        {
            var exists = _shoppingCartService.ExistsProductInShoppingCart(999, "testUser").Result;
            Assert.That(exists, Is.False);
        }

        [Test]
        public void ProductoTieneStockDisponible()
        {
            var stock = _productService.GetProductStock(_productId).Result;
            Assert.That(stock, Is.Not.EqualTo(0));
        }

        [Test]
        public void ProductoNoTieneStockDisponible()
        {
            var stock = _productService.GetProductStock(_productIdNoStock).Result;
            Assert.That(stock, Is.EqualTo(0));
        }

    }
}
