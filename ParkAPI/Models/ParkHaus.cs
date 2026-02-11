namespace ParkAPI.Models
{
    public class ParkHaus
    {
        public Guid Id { get; set; }
        public String ParkHausName { get; set; }
        public int Distanz { get; set; }
        public int VerfuegbarePlaetze { get; set; }

        public String MapsLink { get; set; }

        public Guid PreisKlasseID { get; set; }

        public Guid AddressID { get; set; }

        public List<BetriebsZeit> BetriebsZeit { get; set; } = new();
        public PreisKlasse PreisKlasse { get; set; }
        public Address Address { get; set; }
    }
}

