namespace TallerPlataformaComercioElectronico.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? UserName { get; set; }

        public bool? IsActive { get; set; }

        public virtual Product? Product { get; set; }

    }
}
