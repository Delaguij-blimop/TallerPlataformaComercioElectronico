using System.ComponentModel.DataAnnotations.Schema;

namespace TallerPlataformaComercioElectronico.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual ICollection<Payment>? Payments { get; set; }

        [NotMapped]
        public string? Base64 { get; set; }

        [NotMapped]
        public string? Extension { get; set; }
    }
}
