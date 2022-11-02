namespace TestZelfRelatie.Models
{
    /// <summary>
    /// Example with attributes on relation
    /// </summary>
    public class RoutePointV2
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<RoutePointRelationV2>? IncomingRelations { get; set; }
        public List<RoutePointRelationV2>? OutgoingRelations { get; set; }
    }
}
