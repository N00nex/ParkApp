namespace ParkAPI.Models
{
    public class ParkHaus
    {
        public Guid Id { get; set; }
        public String ParkHausName { get; set; }
        public int Distanz { get; set; }
        public int VerfuegbarePlaetze { get; set; }

        public String MapsLink { get; set; }

        public Guid PreisID { get; set; }
    }
}
