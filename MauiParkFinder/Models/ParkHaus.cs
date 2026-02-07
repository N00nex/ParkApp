namespace MauiParkFinder.Models
{
    public class ParkHaus
    {
        public Guid Id { get; set; }
        public string ParkHausName { get; set; }
        public int Distanz { get; set; }
        public int VerfuegbarePlaetze { get; set; }
        public string MapsLink { get; set; }
        public Guid PreisKlasseID { get; set; }
        
       
        public PreisKlasse PreisKlasse { get; set; }
    }
}