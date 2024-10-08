﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Helpers;
using TallerPlataformaComercioElectronico.Services.Interfaces;

namespace TallerPlataformaComercioElectronico.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IGeoService _geoService;
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly string _webRootPath;
        private string? _userName;

        public StoreController(ILogger<StoreController> logger, ICategoryService categoryService, IProductService productService, IShoppingCartService shoppingCartService, IGeoService geoService, IOrderService orderService, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _categoryService = categoryService;
            _productService = productService;
            _shoppingCartService = shoppingCartService;
            _geoService = geoService;
            _orderService = orderService;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _webRootPath = _webHostEnvironment.WebRootPath;
        }

        public async Task<IActionResult> Index(int id)
        {
            var model = await _productService.GetById(id);
            return View(model);
        }

        public async Task<IActionResult> ProductDetail(int productId = 0)
        {
            Product oProduct = new Product();
            IEnumerable<Product> oList = new List<Product>();

            oList = await _productService.GetAllWithIncludes();
            oProduct = (from o in oList
                         where o.Id == productId
                        select new Product()
                         {
                             Id = o.Id,
                             Description = o.Description,
                             Brand = o.Brand,
                             BrandId = o.BrandId,
                             Category = o.Category,
                             CategoryId = o.CategoryId,
                             Price = o.Price,
                             Stock = o.Stock,
                             ImagePath = o.ImagePath,
                             Base64 = Utilities.convertirBase64(Path.Combine(_webRootPath, o.ImagePath)),
                             Extension = Path.GetExtension(o.ImagePath).Replace(".", "")
                         }).FirstOrDefault(new Product());
            return View(oProduct);
        }

        public IActionResult ShoppingCart()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetProductsByCategory(int categoryId = 0)
        {
            IEnumerable<Product> oList = new List<Product>();

            oList = await _productService.GetAll();
            oList = (from o in oList
                      select new Product()
                      {
                          Id = o.Id,
                          Description = o.Description,
                          BrandId = o.BrandId,
                          CategoryId = o.CategoryId,
                          Category = o.Category,
                          Brand = o.Brand,
                          Price = o.Price,
                          Stock = o.Stock,
                          ImagePath = o.ImagePath,
                          Base64 = Utilities.convertirBase64(Path.Combine(_webRootPath, o.ImagePath)),
                          Extension = Path.GetExtension(o.ImagePath).Replace(".", "")
                      }).ToList();

            if (categoryId != 0)
            {
                oList = oList.Where(x => x.CategoryId == categoryId).ToList();
            }

            var json = Json(new { data = oList });
            return json;
        }

        [HttpGet]
        public async Task<JsonResult> GetCategories()
        {
            IEnumerable<Category> oList = new List<Category>();
            oList = await _categoryService.GetAll();
            return Json(new { data = oList });
        }

        [HttpPost]
        public async Task<JsonResult> AddProductToShoppingCart(int productId)
        {
            string _userName = await GetCurrentUserName();
            ShoppingCart cart = new ShoppingCart();
            bool _response;
            string _message;

            if (await _shoppingCartService.ExistsProductInShoppingCart(productId, _userName) == true)
            {
                //El producto ya existe en el carrito
                _response = false;
                _message = "El producto ya existe en el carrito";
                return Json(new { response = _response, message = _message });
            }
            if (await _productService.GetProductStock(productId) <= 1)
            {
                //No hay stock del producto
                _response = false;
                _message = "No hay stock disponible";
                return Json(new { response = _response, message = _message });
            }

            cart.UserName = _userName;
            cart.ProductId = productId;
            cart.Quantity = 1;
            cart.IsActive = true;
            await _shoppingCartService.Insert(cart);
            _response = cart.Id == 0 ? false : true;
            _message = cart.Id == 0 ? "No se pudo agregar el producto" : "Producto agregado al carrito";

            return Json(new { response = _response, message = _message });
        }

        [HttpGet]
        public async Task<JsonResult> GetShoppingCartsQuantity()
        {
            int _response = 0;
            string _userName = await GetCurrentUserName();
            _response = await _shoppingCartService.GetQuantityByUser(_userName);
            return Json(new { response = _response });
        }

        [HttpGet]
        public async Task<JsonResult> GetShoppingCarts()
        {
            string _userName = await GetCurrentUserName();
            IEnumerable<ShoppingCart> oList = new List<ShoppingCart>();
            oList = await _shoppingCartService.GetShoppingCartsByUser(_userName);

            if (oList.Count() != 0)
            {
                oList = (from d in oList
                          select new ShoppingCart()
                          {
                              Id = d.Id,
                              Quantity = d.Quantity,
                              Product = new Product()
                              {
                                  Id = d.Product.Id,
                                  Description = d.Product.Description,
                                  Brand = new Brand() { Description = d.Product.Brand.Description },
                                  Price = d.Product.Price,
                                  ImagePath = d.Product.ImagePath,
                                  Base64 = Utilities.convertirBase64(Path.Combine(_webRootPath, d.Product.ImagePath)),
                                  Extension = Path.GetExtension(d.Product.ImagePath).Replace(".", ""),
                              }
                          }).ToList();
            }

            return Json(new { list = oList });
        }

        [HttpPost]
        public async Task<JsonResult> DeleteProductFromShoppingCart(int shoppingCartId)
        {
            bool response = false;
            response = await _shoppingCartService.Delete(shoppingCartId);
            return Json(new { result = response });
        }

        [HttpPost]
        public async Task<JsonResult> UpdateProductQuantity(int shoppingCartId, int quantity)
        {
            bool response = false;

            var shoppingCartToUpdate = await _shoppingCartService.GetById(shoppingCartId);
            shoppingCartToUpdate.Quantity = quantity;

            response = await _shoppingCartService.UpdateQuantity(shoppingCartToUpdate);

            return Json(new { result = response });
        }

        [HttpPost]
        public async Task<JsonResult> GetCountries()
        {
            IEnumerable<Country> oList = new List<Country>();
            oList = await _geoService.GetCountries();
            return Json(new { lista = oList });
        }

        [HttpPost]
        public async Task<JsonResult> GetStates(int countryId)
        {
            IEnumerable<State> oList = new List<State>();
            oList = await _geoService.GetStates(countryId);
            return Json(new { lista = oList });
        }

        [HttpPost]
        public async Task<JsonResult> GetCities(int stateId)
        {
            IEnumerable<City> oList = new List<City>();
            oList = await _geoService.GetCities(stateId);
            return Json(new { lista = oList });
        }

        [HttpPost]
        public async Task<JsonResult> GenerateOrder(Order order)
        {
            bool response = false;
            string _userName = await GetCurrentUserName();

            order.UserName = _userName;
            order.Date = DateTime.Today;
            order.CurrencyId = 1;

            response = await _orderService.Insert(order);
            var orderInfo = new Order { Id = order.Id, UserName = order.UserName, TotalAmount = order.TotalAmount, TotalQuantity = order.TotalQuantity };
            return Json(new { result = response, order = orderInfo });
        }

        [HttpGet]
        public async Task<JsonResult> GetOrders()
        {
            IEnumerable<Order> oList = new List<Order>();
            string _userName = await GetCurrentUserName();

            oList = await _shoppingCartService.GetOrdersByUser(_userName);

            oList = (from c in oList
                      select new Order()
                      {
                          Id = c.Id,
                          UserName = c.UserName,
                          TotalAmount = c.TotalAmount,
                          TotalQuantity = c.TotalQuantity,
                          Date = c.Date,
                          Payments = (from p in c.Payments
                                    select new Payment()
                                    {
                                        OrderId = p.OrderId
                                    }).ToList(),
                          Detail = (from dc in c.Detail
                                            select new OrderDetail()
                                            {
                                                OrderId = dc.OrderId,
                                                Product = new Product()
                                                {
                                                    Id = dc.ProductId,
                                                    Brand = new Brand() { Description = dc.Product.Brand.Description },
                                                    Description = dc.Product.Description,
                                                    ImagePath = dc.Product.ImagePath,
                                                    Base64 = Utilities.convertirBase64(Path.Combine(_webRootPath, dc.Product.ImagePath)),
                                                    Extension = Path.GetExtension(dc.Product.ImagePath).Replace(".", ""),
                                                },
                                                Amount = dc.Amount,
                                                Quantity = dc.Quantity
                                            }).ToList()
                      }).ToList();
            return Json(new { list = oList });
        }

        private async Task<string> GetCurrentUserName()
        {
            if (string.IsNullOrEmpty(_userName))
            {
                var user = await _userManager.GetUserAsync(User);
                _userName = user.UserName;
            }
            return _userName;
        }

        private async Task<bool> UserHasFraudReport()
        {
            var user = await _userManager.GetUserAsync(User);
            return user.FraudReport;
        }

        private async Task<bool> UserIsAdmin()
        {
            var user = await _userManager.GetUserAsync(User);
            return user.IsAdmin;
        }

    }
}
