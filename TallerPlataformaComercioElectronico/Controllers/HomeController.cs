using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;
using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Helpers;
using TallerPlataformaComercioElectronico.Models;
using TallerPlataformaComercioElectronico.Services.Interfaces;

namespace TallerPlataformaComercioElectronico.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;
        private readonly string _webRootPath;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IBrandService brandService, IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _categoryService = categoryService;
            _brandService = brandService;
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
            _webRootPath = _webHostEnvironment.WebRootPath;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category()
        {
            return View();
        }

        public IActionResult Brand()
        {
            return View();
        }

        public async Task<IActionResult> Product()
        {
            List<SelectListItem> brandsList = new List<SelectListItem>();
            foreach (var brand in await _brandService.GetAll())
            {
                brandsList.Add(new SelectListItem { Value = brand.Id.ToString(), Text = brand.Description });
            }

            List<SelectListItem> categoriesList = new List<SelectListItem>();
            foreach (var category in await _categoryService.GetAll())
            {
                categoriesList.Add(new SelectListItem { Value = category.Id.ToString(), Text = category.Description });
            }

            Product model = new Product { 
                Brands = brandsList,
                Categories = categoriesList
            };

            return View(model);
        }

        public IActionResult Store()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetCategories()
        {
            IEnumerable<Category> oList = new List<Category>();
            oList = await _categoryService.GetAll();
            return Json(new { data = oList });
        }

        [HttpPost]
        public async Task<JsonResult> SaveCategory(Category category)
        {
            bool response = false;
            response = (category.Id == 0) ? await _categoryService.Insert(category) : await _categoryService.Update(category);
            return Json(new { result = response });
        }

        [HttpPost]
        public async Task<JsonResult> DeleteCategory(int id)
        {
            bool response = false;
            response = await _categoryService.Delete(id);
            return Json(new { result = response });
        }

        [HttpGet]
        public async Task<JsonResult> GetBrands()
        {
            IEnumerable<Brand> oList = new List<Brand>();
            oList = await _brandService.GetAll();
            var jsonResult = Json(new { data = oList });
            return jsonResult;
        }

        [HttpPost]
        public async Task<JsonResult> SaveBrand(Brand brand)
        {
            bool response = false;
            response = (brand.Id == 0) ? await _brandService.Insert(brand) : await _brandService.Update(brand);
            return Json(new { result = response });
        }

        [HttpPost]
        public async Task<JsonResult> DeleteBrand(int id)
        {
            bool response = false;
            response = await _brandService.Delete(id);
            return Json(new { result = response });
        }

        [HttpGet]
        public async Task<JsonResult> GetProductsWithIncludes()
        {
            IEnumerable<Product> oList = new List<Product>();
            oList = await _productService.GetAllWithIncludes();
            var result = (from o in oList
                          select new Product()
                          {
                              Id = o.Id,
                              Description = o.Description,
                              BrandId = o.BrandId,
                              Brand = new Brand { Id = o.Brand.Id, Description = o.Brand.Description },
                              CategoryId = o.CategoryId,
                              Category = new Category { Id = o.Category.Id, Description = o.Category.Description },
                              Price = o.Price,
                              Stock = o.Stock,
                              ImagePath = o.ImagePath,
                              Base64 = o.ImagePath != null ? Utilities.convertirBase64(Path.Combine(_webRootPath, o.ImagePath)) : null,
                              Extension = o.ImagePath != null ? Path.GetExtension(o.ImagePath).Replace(".", "") : null
                          }).ToList();

            return Json(new { data = result });
        }

        [HttpGet]
        public async Task<JsonResult> GetProducts()
        {
            IEnumerable<Product> oList = new List<Product>();
            oList = await _productService.GetAll();
            var result = (from o in oList
                          select new Product()
                          {
                              Id = o.Id,
                              Description = o.Description,
                              BrandId = o.BrandId,
                              CategoryId = o.CategoryId,
                              Price = o.Price,
                              Stock = o.Stock,
                              ImagePath = o.ImagePath,
                              Base64 = o.ImagePath != null ? Utilities.convertirBase64(Path.Combine(_webRootPath, o.ImagePath)) : null,
                              Extension = o.ImagePath != null ? Path.GetExtension(o.ImagePath).Replace(".", "") : null
                          }).ToList();

            return Json(new { data = result });
        }

        [HttpPost]
        public async Task<JsonResult> SaveProduct(string oProduct, IFormFile imageFile)
        {
            GenericResponse response = new GenericResponse() { Result = true, Message = "" };

            try
            {
                Product product = new Product();
                product = JsonConvert.DeserializeObject<Product>(oProduct);

                string physicalPath = Path.Combine(_webRootPath, "Images\\Products");

                if (!Directory.Exists(physicalPath))
                    Directory.CreateDirectory(physicalPath);

                if (product.Id == 0)
                {
                    await _productService.Insert(product);
                    response.Result = product.Id == 0 ? false : true;
                }
                else
                {
                    response.Result = await _productService.Update(product);
                }

                if (product.Id != 0 && imageFile != null && imageFile.Length > 0)
                {
                    string ext = Path.GetExtension(imageFile.FileName);
                    string fileName = product.Id.ToString() + ext;
                    string savePath = Path.Combine(physicalPath, fileName);
                    product.ImagePath = savePath;
                    using (Stream fileStream = new FileStream(savePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }
                    response.Result = await _productService.UpdateImagePath(product);
                }
            }
            catch (Exception e)
            {
                response.Result = false;
                response.Message = e.Message;
            }

            return Json(new { result = response });
        }

        [HttpPost]
        public async Task<JsonResult> DeleteProduct(int id)
        {
            bool response = false;
            response = await _productService.Delete(id);
            return Json(new { result = response });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
