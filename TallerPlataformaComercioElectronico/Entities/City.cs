namespace TallerPlataformaComercioElectronico.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int StateId { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual State? State { get; set; }
        public virtual ICollection<BillingAddress>? BillingAddresses { get; set; }
    }
}
