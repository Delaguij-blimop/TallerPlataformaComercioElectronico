namespace TallerPlataformaComercioElectronico.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
