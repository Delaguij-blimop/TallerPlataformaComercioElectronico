namespace TallerPlataformaComercioElectronico.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? CodigoISO { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }

    }
}
