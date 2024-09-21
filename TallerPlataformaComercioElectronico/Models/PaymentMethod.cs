namespace TallerPlataformaComercioElectronico.Models
{
    public class PaymentMethod
    {
        public PaymentMethodType? Type { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpirationDate { get; set; }
        public string? CVV { get; set; }
        public string? CardholderName { get; set; }
        public string? Email { get; set; }
    }

    public enum PaymentMethodType
    {
        None,
        CreditCard,
        PayPal
    }
}
