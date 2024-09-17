namespace TallerPlataformaComercioElectronico.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual ICollection<State>? States { get; set; }
    }
}
