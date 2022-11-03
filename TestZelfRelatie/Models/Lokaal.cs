namespace TestZelfRelatie.Models
{
    public class Lokaal
    {
        public int LokaalId { get; set; }
        public string? Description { get; set; }

        public int GebouwId { get; set; }
        public Gebouw? Gebouw { get; set; }
    }
}
