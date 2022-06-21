using Newtonsoft.Json;

namespace AtmiraWebAPI.Models
{
    public class NearEarthObjects
    {

        [JsonProperty("2020-09-16")]
        public List<Momentum>? _20200916 { get; set; }

        [JsonProperty("2020-09-09")]
        public List<Momentum>? _20200909 { get; set; }

        [JsonProperty("2020-09-11")]
        public List<Momentum>? _20200911 { get; set; }

        [JsonProperty("2020-09-10")]
        public List<Momentum>? _20200910 { get; set; }

        [JsonProperty("2020-09-15")]
        public List<Momentum>? _20200915 { get; set; }

        [JsonProperty("2020-09-14")]
        public List<Momentum>? _20200914 { get; set; }

        [JsonProperty("2020-09-13")]
        public List<Momentum>? _20200913 { get; set; }

        [JsonProperty("2020-09-12")]
        public List<Momentum>? _20200912 { get; set; }
    }
}
