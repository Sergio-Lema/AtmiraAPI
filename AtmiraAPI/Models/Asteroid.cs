namespace AtmiraWebAPI.Models
{
    [Serializable]
    public class Asteroid
    {
        public string? Nombre { get; set; }
        public double? Diametro { get; set; }
        public string? Velocidad { get; set; }
        public string? Fecha { get; set; }
        public string? Planeta { get; set; }

        public Asteroid(string? name, double? diametro, string? velocidad, string? fecha, string? planet)
        {
            Nombre = name;
            Diametro = diametro;
            Velocidad = velocidad;
            Fecha = fecha;
            Planeta = planet;
        }
    }
}
