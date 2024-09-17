namespace TallerPlataformaComercioElectronico.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PaymentTypeId { get; set; }
        public string? CardNumber { get; set; }
        public string? CardHolderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? CVV { get; set; }
        public decimal Amount { get; set; }

        public virtual Order? Order { get; set; }
        public virtual PaymentType? PaymentType { get; set; }

    }
}
