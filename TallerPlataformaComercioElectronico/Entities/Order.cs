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
        public string? Contact { get; set; }
        public string? Phone { get; set; }
        public int BillingAddressId { get; set; }

        public virtual BillingAddress? BillingAddress { get; set; }
        public virtual Currency? Currency { get; set; }
        public virtual ICollection<OrderDetail>? Detail { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}
