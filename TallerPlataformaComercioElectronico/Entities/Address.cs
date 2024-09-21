namespace TallerPlataformaComercioElectronico.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public AddressType? Type { get; set; }
        public int CityId { get; set; }

        public virtual City? City { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }

    public enum AddressType
    {
        Billing,
        Delivery
    }

}
