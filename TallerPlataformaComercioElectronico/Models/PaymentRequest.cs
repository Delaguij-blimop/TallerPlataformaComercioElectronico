namespace TallerPlataformaComercioElectronico.Models
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
    }
}
