namespace TallerPlataformaComercioElectronico.Entities
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual ICollection<Payment>? Payments { get; set; }
    }
}
