using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing.Drawing2D;
using System.Reflection;
using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Data.Helpers
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            var rootFolder = Directory.GetCurrentDirectory();
            var physicalPathProducts = Path.GetFullPath(Path.Combine(rootFolder, "wwwroot\\Images\\Products"));
            var physicalPathPaymentMethods = Path.GetFullPath(Path.Combine(rootFolder, "wwwroot\\Images\\PaymentMethods"));

            _modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin@carrito.com.ar",
                    NormalizedUserName = "ADMIN@CARRITO.COM.AR",
                    Email = "admin@carrito.com.ar",
                    NormalizedEmail = "ADMIN@CARRITO.COM.AR",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEBqKOI75zr0oD8Th8AJyDyEDbV+twvrleq/c/5SczRD+vY2y6ghxghAtNWEWZqg3tw==",
                    SecurityStamp = "CRNRUGJ7ALBDPBKP6ZTBSL3Q2R7A25YV",
                    ConcurrencyStamp = "073c407b-dcd0-4039-b2ad-1059ede19e7e",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    FraudReport = false,
                    IsAdmin = true
                });

            _modelBuilder.Entity<Currency>().HasData(
                new Currency { Id = 1, Description = "Peso Argentino", CodigoISO = "ARS", RegisterDate = DateTime.Today },
                new Currency { Id = 2, Description = "Dolar", CodigoISO = "USD", RegisterDate = DateTime.Today }
            );

            _modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Description = "Argentina", RegisterDate = DateTime.Today }
            );

            _modelBuilder.Entity<State>().HasData(
                new State { Id = 1, CountryId = 1, Description = "Buenos Aires", RegisterDate = DateTime.Today },
                new State { Id = 2, CountryId = 1, Description = "Catamarca", RegisterDate = DateTime.Today },
                new State { Id = 3, CountryId = 1, Description = "Chaco", RegisterDate = DateTime.Today },
                new State { Id = 4, CountryId = 1, Description = "Chubut", RegisterDate = DateTime.Today },
                new State { Id = 5, CountryId = 1, Description = "Córdoba", RegisterDate = DateTime.Today },
                new State { Id = 6, CountryId = 1, Description = "Corrientes", RegisterDate = DateTime.Today },
                new State { Id = 7, CountryId = 1, Description = "Entre Ríos", RegisterDate = DateTime.Today },
                new State { Id = 8, CountryId = 1, Description = "Formosa", RegisterDate = DateTime.Today },
                new State { Id = 9, CountryId = 1, Description = "Jujuy", RegisterDate = DateTime.Today },
                new State { Id = 10, CountryId = 1, Description = "La Pampa", RegisterDate = DateTime.Today },
                new State { Id = 11, CountryId = 1, Description = "La Rioja", RegisterDate = DateTime.Today },
                new State { Id = 12, CountryId = 1, Description = "Mendoza", RegisterDate = DateTime.Today },
                new State { Id = 13, CountryId = 1, Description = "Misiones", RegisterDate = DateTime.Today },
                new State { Id = 14, CountryId = 1, Description = "Neuquén", RegisterDate = DateTime.Today },
                new State { Id = 15, CountryId = 1, Description = "Río Negro", RegisterDate = DateTime.Today },
                new State { Id = 16, CountryId = 1, Description = "Salta", RegisterDate = DateTime.Today },
                new State { Id = 17, CountryId = 1, Description = "San Juan", RegisterDate = DateTime.Today },
                new State { Id = 18, CountryId = 1, Description = "San Luis", RegisterDate = DateTime.Today },
                new State { Id = 19, CountryId = 1, Description = "Santa Cruz", RegisterDate = DateTime.Today },
                new State { Id = 20, CountryId = 1, Description = "Santa Fe", RegisterDate = DateTime.Today },
                new State { Id = 21, CountryId = 1, Description = "Santiago del Estero", RegisterDate = DateTime.Today },
                new State { Id = 22, CountryId = 1, Description = "Tierra del Fuego", RegisterDate = DateTime.Today },
                new State { Id = 23, CountryId = 1, Description = "Tucumán", RegisterDate = DateTime.Today },
                new State { Id = 24, CountryId = 1, Description = "Ciudad Autónoma de Buenos Aires", RegisterDate = DateTime.Today }
            );

            _modelBuilder.Entity<City>().HasData(
                // Buenos Aires
                new City { Id = 1, StateId = 1, Description = "La Plata", RegisterDate = DateTime.Today },
                new City { Id = 2, StateId = 1, Description = "Mar del Plata", RegisterDate = DateTime.Today },
                // Catamarca
                new City { Id = 3, StateId = 2, Description = "San Fernando del Valle de Catamarca", RegisterDate = DateTime.Today },
                new City { Id = 4, StateId = 2, Description = "Belén", RegisterDate = DateTime.Today },
                // Chaco
                new City { Id = 5, StateId = 3, Description = "Resistencia", RegisterDate = DateTime.Today },
                new City { Id = 6, StateId = 3, Description = "Presidencia Roque Sáenz Peña", RegisterDate = DateTime.Today },
                // Chubut
                new City { Id = 7, StateId = 4, Description = "Rawson", RegisterDate = DateTime.Today },
                new City { Id = 8, StateId = 4, Description = "Comodoro Rivadavia", RegisterDate = DateTime.Today },
                // Córdoba
                new City { Id = 9, StateId = 5, Description = "Córdoba", RegisterDate = DateTime.Today },
                new City { Id = 10, StateId = 5, Description = "Villa Carlos Paz", RegisterDate = DateTime.Today },
                // Corrientes
                new City { Id = 11, StateId = 6, Description = "Corrientes", RegisterDate = DateTime.Today },
                new City { Id = 12, StateId = 6, Description = "Goya", RegisterDate = DateTime.Today },
                // Entre Ríos
                new City { Id = 13, StateId = 7, Description = "Paraná", RegisterDate = DateTime.Today },
                new City { Id = 14, StateId = 7, Description = "Concordia", RegisterDate = DateTime.Today },
                // Formosa
                new City { Id = 15, StateId = 8, Description = "Formosa", RegisterDate = DateTime.Today },
                new City { Id = 16, StateId = 8, Description = "Clorinda", RegisterDate = DateTime.Today },
                // Jujuy
                new City { Id = 17, StateId = 9, Description = "San Salvador de Jujuy", RegisterDate = DateTime.Today },
                new City { Id = 18, StateId = 9, Description = "Palpalá", RegisterDate = DateTime.Today },
                // La Pampa
                new City { Id = 19, StateId = 10, Description = "Santa Rosa", RegisterDate = DateTime.Today },
                new City { Id = 20, StateId = 10, Description = "General Pico", RegisterDate = DateTime.Today },
                // La Rioja
                new City { Id = 21, StateId = 11, Description = "La Rioja", RegisterDate = DateTime.Today },
                new City { Id = 22, StateId = 11, Description = "Chilecito", RegisterDate = DateTime.Today },
                // Mendoza
                new City { Id = 23, StateId = 12, Description = "Mendoza", RegisterDate = DateTime.Today },
                new City { Id = 24, StateId = 12, Description = "San Rafael", RegisterDate = DateTime.Today },
                // Misiones
                new City { Id = 25, StateId = 13, Description = "Posadas", RegisterDate = DateTime.Today },
                new City { Id = 26, StateId = 13, Description = "Oberá", RegisterDate = DateTime.Today },
                // Neuquén
                new City { Id = 27, StateId = 14, Description = "Neuquén", RegisterDate = DateTime.Today },
                new City { Id = 28, StateId = 14, Description = "San Martín de los Andes", RegisterDate = DateTime.Today },
                // Río Negro
                new City { Id = 29, StateId = 15, Description = "Viedma", RegisterDate = DateTime.Today },
                new City { Id = 30, StateId = 15, Description = "San Carlos de Bariloche", RegisterDate = DateTime.Today },
                // Salta
                new City { Id = 31, StateId = 16, Description = "Salta", RegisterDate = DateTime.Today },
                new City { Id = 32, StateId = 16, Description = "Tartagal", RegisterDate = DateTime.Today },
                // San Juan
                new City { Id = 33, StateId = 17, Description = "San Juan", RegisterDate = DateTime.Today },
                new City { Id = 34, StateId = 17, Description = "Caucete", RegisterDate = DateTime.Today },
                // San Luis
                new City { Id = 35, StateId = 18, Description = "San Luis", RegisterDate = DateTime.Today },
                new City { Id = 36, StateId = 18, Description = "Villa Mercedes", RegisterDate = DateTime.Today },
                // Santa Cruz
                new City { Id = 37, StateId = 19, Description = "Río Gallegos", RegisterDate = DateTime.Today },
                new City { Id = 38, StateId = 19, Description = "Caleta Olivia", RegisterDate = DateTime.Today },
                // Santa Fe
                new City { Id = 39, StateId = 20, Description = "Santa Fe", RegisterDate = DateTime.Today },
                new City { Id = 40, StateId = 20, Description = "Rosario", RegisterDate = DateTime.Today },
                // Santiago del Estero
                new City { Id = 41, StateId = 21, Description = "Santiago del Estero", RegisterDate = DateTime.Today },
                new City { Id = 42, StateId = 21, Description = "La Banda", RegisterDate = DateTime.Today },
                // Tierra del Fuego
                new City { Id = 43, StateId = 22, Description = "Ushuaia", RegisterDate = DateTime.Today },
                new City { Id = 44, StateId = 22, Description = "Río Grande", RegisterDate = DateTime.Today },
                // Tucumán
                new City { Id = 45, StateId = 23, Description = "San Miguel de Tucumán", RegisterDate = DateTime.Today },
                new City { Id = 46, StateId = 23, Description = "Tafí Viejo", RegisterDate = DateTime.Today },
                // Ciudad Autónoma de Buenos Aires
                new City { Id = 47, StateId = 24, Description = "Buenos Aires", RegisterDate = DateTime.Today }
            );

            _modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Description = "Tecnología", RegisterDate = DateTime.Today },
                new Category { Id = 2, Description = "Muebles", RegisterDate = DateTime.Today },
                new Category { Id = 3, Description = "Dormitorio", RegisterDate = DateTime.Today },
                new Category { Id = 4, Description = "Deportes", RegisterDate = DateTime.Today },
                new Category { Id = 5, Description = "Zapatos", RegisterDate = DateTime.Today },
                new Category { Id = 6, Description = "Accesorios", RegisterDate = DateTime.Today },
                new Category { Id = 7, Description = "Juguetería", RegisterDate = DateTime.Today },
                new Category { Id = 8, Description = "Electrohogar", RegisterDate = DateTime.Today }
            );

            _modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Description = "SONY", RegisterDate = DateTime.Today },
                new Brand { Id = 2, Description = "HP", RegisterDate = DateTime.Today },
                new Brand { Id = 3, Description = "LG", RegisterDate = DateTime.Today },
                new Brand { Id = 4, Description = "HYUNDAI", RegisterDate = DateTime.Today },
                new Brand { Id = 5, Description = "CANON", RegisterDate = DateTime.Today },
                new Brand { Id = 6, Description = "ROBERTA ALLEN", RegisterDate = DateTime.Today },
                new Brand { Id = 7, Description = "MICA", RegisterDate = DateTime.Today },
                new Brand { Id = 8, Description = "FORLI", RegisterDate = DateTime.Today },
                new Brand { Id = 9, Description = "BE CRAFTY", RegisterDate = DateTime.Today },
                new Brand { Id = 10, Description = "ADIDAS", RegisterDate = DateTime.Today },
                new Brand { Id = 11, Description = "BEST", RegisterDate = DateTime.Today },
                new Brand { Id = 12, Description = "REEBOK", RegisterDate = DateTime.Today },
                new Brand { Id = 13, Description = "FOSSIL", RegisterDate = DateTime.Today },
                new Brand { Id = 14, Description = "BILLABONG", RegisterDate = DateTime.Today },
                new Brand { Id = 15, Description = "POWCO", RegisterDate = DateTime.Today },
                new Brand { Id = 16, Description = "HOT WHEELS", RegisterDate = DateTime.Today },
                new Brand { Id = 17, Description = "LEGO", RegisterDate = DateTime.Today },
                new Brand { Id = 18, Description = "SAMSUNG", RegisterDate = DateTime.Today },
                new Brand { Id = 19, Description = "RECCO", RegisterDate = DateTime.Today },
                new Brand { Id = 20, Description = "INDURAMA", RegisterDate = DateTime.Today },
                new Brand { Id = 21, Description = "ALFANO", RegisterDate = DateTime.Today },
                new Brand { Id = 22, Description = "MABE", RegisterDate = DateTime.Today },
                new Brand { Id = 23, Description = "ELECTROLUX", RegisterDate = DateTime.Today }
            );

            _modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Description = "Consola de PS4 Pro 1TB Negro", BrandId = 1, CategoryId = 1, Price = 2000, Stock = 50, ImagePath = physicalPathProducts + "\\1.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 2, Description = "HP Laptop 15-EF1019LA", BrandId = 2, CategoryId = 1, Price = 2500, Stock = 60, ImagePath = physicalPathProducts + "\\2.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 3, Description = "Televisor 65 4K Ultra HD Smart 65UN710", BrandId = 3, CategoryId = 1, Price = 3000, Stock = 120, ImagePath = physicalPathProducts + "\\3.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 4, Description = "Televisor 50 4K Ultra HD Smart Android", BrandId = 4, CategoryId = 1, Price = 3200, Stock = 70, ImagePath = physicalPathProducts + "\\4.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 5, Description = "Cámara Reflex EOS Rebel T100", BrandId = 5, CategoryId = 1, Price = 1560, Stock = 90, ImagePath = physicalPathProducts + "\\5.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 6, Description = "Aparador Surat", BrandId = 6, CategoryId = 2, Price = 500, Stock = 60, ImagePath = physicalPathProducts + "\\6.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 7, Description = "Mesa de Comedor Donatello", BrandId = 7, CategoryId = 2, Price = 400, Stock = 90, ImagePath = physicalPathProducts + "\\7.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 8, Description = "Colchón Polaris 1 Plz + 1 Almohada", BrandId = 8, CategoryId = 3, Price = 500, Stock = 120, ImagePath = physicalPathProducts + "\\8.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 9, Description = "Juegos de Sábanas 180 Hilos Solid", BrandId = 6, CategoryId = 3, Price = 200, Stock = 130, ImagePath = physicalPathProducts + "\\9.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 10, Description = "Tocador Franca", BrandId = 7, CategoryId = 3, Price = 450, Stock = 60, ImagePath = physicalPathProducts + "\\10.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 11, Description = "Alfombra Infantil de Osa Melange", BrandId = 9, CategoryId = 3, Price = 120, Stock = 50, ImagePath = physicalPathProducts + "\\11.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 12, Description = "Mochila Unisex Deportivo Classic", BrandId = 10, CategoryId = 4, Price = 220, Stock = 45, ImagePath = physicalPathProducts + "\\12.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 13, Description = "Bicicleta de Montaña Best Inka 29 Roja", BrandId = 11, CategoryId = 4, Price = 890, Stock = 75, ImagePath = physicalPathProducts + "\\13.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 14, Description = "Zapatillas Urbanas Mujer adidas", BrandId = 10, CategoryId = 5, Price = 260, Stock = 80, ImagePath = physicalPathProducts + "\\14.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 15, Description = "Zapatillas Training Hombre Rebook", BrandId = 12, CategoryId = 5, Price = 230, Stock = 38, ImagePath = physicalPathProducts + "\\15.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 16, Description = "Reloj", BrandId = 13, CategoryId = 6, Price = 300, Stock = 20, ImagePath = physicalPathProducts + "\\16.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 17, Description = "Billetera Hombre", BrandId = 14, CategoryId = 6, Price = 87, Stock = 88, ImagePath = physicalPathProducts + "\\17.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 18, Description = "Auto Deportivo 45 cm Naranja", BrandId = 15, CategoryId = 7, Price = 90, Stock = 55, ImagePath = physicalPathProducts + "\\18.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 19, Description = "Set de Juego Hot Wheels", BrandId = 16, CategoryId = 7, Price = 130, Stock = 70, ImagePath = physicalPathProducts + "\\19.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 20, Description = "Set Lego Classic: Maletín Creativo", BrandId = 17, CategoryId = 7, Price = 110, Stock = 60, ImagePath = physicalPathProducts + "\\20.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 21, Description = "Refrigerador Samsung 295 litros", BrandId = 18, CategoryId = 8, Price = 2100, Stock = 90, ImagePath = physicalPathProducts + "\\21.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 22, Description = "Ventilador 3 En 1", BrandId = 19, CategoryId = 8, Price = 1100, Stock = 56, ImagePath = physicalPathProducts + "\\22.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 23, Description = "Frigobar 92 Lt Blanco", BrandId = 20, CategoryId = 8, Price = 940, Stock = 78, ImagePath = physicalPathProducts + "\\23.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 24, Description = "Aire Acondicionado Split", BrandId = 21, CategoryId = 8, Price = 1700, Stock = 56, ImagePath = physicalPathProducts + "\\24.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 25, Description = "Lavadora Mabe 16kg", BrandId = 22, CategoryId = 8, Price = 2800, Stock = 48, ImagePath = physicalPathProducts + "\\25.jpg", RegisterDate = DateTime.Today },
                new Product { Id = 26, Description = "Campana Extractora EJSE202", BrandId = 23, CategoryId = 8, Price = 1500, Stock = 56, ImagePath = physicalPathProducts + "\\26.jpg", RegisterDate = DateTime.Today }
            );

            _modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod { Id = 1, Description = "Tarjeta de Crédito", ImagePath = physicalPathPaymentMethods + "\\CreditCardIcon.png", RegisterDate = DateTime.Today },
                new PaymentMethod { Id = 2, Description = "PayPal", ImagePath = physicalPathPaymentMethods + "\\PayPalIcon.jpg", RegisterDate = DateTime.Today }
            );

        }
    }
}


