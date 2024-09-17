namespace TallerPlataformaComercioElectronico.Entities
{
    public class BillingAddress
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public int CityId { get; set; }

        public virtual City? City { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
