namespace TallerPlataformaComercioElectronico.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? UserName { get; set; }
        public int Quantity { get; set; }
        public bool? IsActive { get; set; }
        public int? OrderId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Order? Order { get; set; }
    }
}
