namespace MauiParkFinder.Models
{
    public class ParkHaus
    {
        public Guid Id { get; set; }
        public string ParkHausName { get; set; }
        public int Distanz { get; set; }
        public int VerfuegbarePlaetze { get; set; }
        public string MapsLink { get; set; }
        public Guid PreisID { get; set; }

        // Navigation Property: 
        // If your API sends the price details nested inside the JSON,
        // this property will be populated automatically.
        public PreisKlasse PreisDetails { get; set; }
    }
}