namespace TestZelfRelatie.Models
{
    public class RoutePoint
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<RoutePoint>? IncomingRelation { get; set; }
        public List<RoutePoint>? OutgoingRelation { get; set; }
    }
}
