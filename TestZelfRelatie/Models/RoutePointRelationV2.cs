namespace TestZelfRelatie.Models
{
    public class RoutePointRelationV2
    {
        public int RoutePointRelationV2Id { get; set; }
        public string? Description { get; set; }
        public int? Distance { get; set; }

        public int RoutePointV2FromId { get; set; }
        public RoutePointV2? RoutePointV2From { get; set; }

        public int RoutePointV2ToId { get; set; }
        public RoutePointV2? RoutePointV2To { get; set; }


    }
}
