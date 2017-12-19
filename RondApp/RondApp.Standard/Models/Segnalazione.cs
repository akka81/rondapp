using SQLite;

namespace RondApp.Models
{
    public class Segnalazione
    {
        public string Name { get; set; }
     
        public string Description { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
