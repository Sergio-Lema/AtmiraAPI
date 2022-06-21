namespace AtmiraWebAPI.Models
{
    public class Momentum
    {
        public Links? Links { get; set; }
        public string? Id { get; set; }
        public string? Neo_reference_id { get; set; }
        public string? Name { get; set; }
        public string? Nasa_jpl_url { get; set; }
        public double Absolute_magnitude_h { get; set; }
        public EstimatedDiameter? Estimated_diameter { get; set; }
        public bool Is_potentially_hazardous_asteroid { get; set; }
        public List<CloseApproachDatum>? Close_approach_data { get; set; }
        public bool Is_sentry_object { get; set; }
    }
}
