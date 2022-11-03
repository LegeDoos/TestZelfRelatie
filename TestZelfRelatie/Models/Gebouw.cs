namespace TestZelfRelatie.Models
{
    public class Gebouw
    {
        public int GebouwId { get; set; }
        public string? Description { get; set; }

        public List<Lokaal>? Lokalen { get; set; }
    }
}
