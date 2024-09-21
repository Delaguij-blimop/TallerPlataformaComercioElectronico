namespace TallerPlataformaComercioElectronico.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PaymentMethodId { get; set; }
        public string? CardNumber { get; set; }
        public string? CardHolderName { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? CVV { get; set; }
        public string? Correo { get; set; }
        public decimal Amount { get; set; }
        public int BillingAddressId { get; set; }
        public string? TransactionId { get; set; }

        public virtual Address? BillingAddress { get; set; }
        public virtual Order? Order { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
    }
}
