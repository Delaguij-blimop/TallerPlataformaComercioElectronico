namespace TallerPlataformaComercioElectronico.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int CountryId { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<City>? Cities { get; set; }
    }
}
