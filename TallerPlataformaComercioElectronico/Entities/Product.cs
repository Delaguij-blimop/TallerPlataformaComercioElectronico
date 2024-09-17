using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerPlataformaComercioElectronico.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? ImagePath { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }

        public virtual ICollection<ShoppingCart>? Carts { get; set; }
        public virtual ICollection<OrderDetail>? Detail { get; set; }

        [NotMapped]
        public virtual ICollection<SelectListItem>? Brands { get; set; }

        [NotMapped]
        public virtual ICollection<SelectListItem>? Categories { get; set; }

        [NotMapped]
        public string? Base64 { get; set; }

        [NotMapped]
        public string? Extension { get; set; }

    }
}
