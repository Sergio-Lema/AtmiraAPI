namespace AtmiraWebAPI.Models
{
    public class CloseApproachDatum
    {
        public string? Close_approach_date { get; set; }
        public string? Close_approach_date_full { get; set; }
        public object? Epoch_date_close_approach { get; set; }
        public RelativeVelocity? Relative_velocity { get; set; }
        public MissDistance? Miss_distance { get; set; }
        public string? Orbiting_body { get; set; }
    }
}
