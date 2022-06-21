using AtmiraWebAPI.Models;
using Newtonsoft.Json;

namespace AtmiraAPI.DataHelper
{
    public class DataHelper
    {
        private static async Task<Root?> GetJsonData(string dataPath)
        {

            HttpClient client = new()
            {
                BaseAddress = new Uri(dataPath)
            };

            var response = client.GetAsync(client.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Root>(contents);
            }
            else
            {
                return null;
            }
        }

        public static async Task<List<Asteroid>?> GetDangerousAsteroid(string dataPath, string planet)
        {
            var jsonRoot = await GetJsonData(dataPath);

            List<Asteroid> asteroids = new();

            List<Momentum>?[] momentums = { jsonRoot?.Near_earth_objects?._20200909,
                                        jsonRoot?.Near_earth_objects?._20200910,
                                        jsonRoot?.Near_earth_objects?._20200911,
                                        jsonRoot?.Near_earth_objects?._20200912,
                                        jsonRoot?.Near_earth_objects?._20200913,
                                        jsonRoot?.Near_earth_objects?._20200914,
                                        jsonRoot?.Near_earth_objects?._20200915,
                                        jsonRoot?.Near_earth_objects?._20200916};

            ListDangerousAsteroid(ref asteroids, momentums, planet);

            if (asteroids.Any())
            {
                if (asteroids.Count >= 3)
                {
                    return asteroids.OrderByDescending(c => c.Diametro).Take(3).ToList();
                }
                else
                {
                    return asteroids;
                }
            }
            return null;

        }

        private static void ListDangerousAsteroid(ref List<Asteroid> asteroids, List<Momentum>?[] momentums, string planet)
        {

            for (int dayIndex = 0; dayIndex < momentums.Length; dayIndex++)
            {
                var day = momentums[dayIndex];
                for (int i = 0; i < day?.Count; i++)
                {
                    if (day[i].Is_potentially_hazardous_asteroid && day[i].Close_approach_data?[0].Orbiting_body == planet)
                    {
                        string? name = day[i].Name;
                        string? velocidad = day[i]?.Close_approach_data?[0].Relative_velocity?.Kilometers_per_hour;
                        double? diameterMin = day[i].Estimated_diameter?.Kilometers?.Estimated_diameter_min;
                        double? diameterMax = day[i].Estimated_diameter?.Kilometers?.Estimated_diameter_max;
                        double? diametro = diameterMax - diameterMin;
                        string? fecha = day[i]?.Close_approach_data?[0].Close_approach_date;

                        asteroids.Add(new Asteroid(name, diametro, velocidad, fecha, planet));

                    }
                }
            }

        }
    }
}
