using System.ComponentModel.DataAnnotations;

namespace TallerPlataformaComercioElectronico.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public int CurrencyId { get; set; }
        public DateTime Date { get; set; }
        public string? UserName { get; set; }

        public virtual ICollection<ShoppingCart>? Carts { get; set; }
        public virtual ICollection<OrderDetail>? Detail { get; set; }
        public virtual Currency? Currency { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}
