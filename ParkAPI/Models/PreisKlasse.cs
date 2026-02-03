namespace ParkAPI.Models
{
    public class PreisKlasse
    {
        public Guid Id { get; set; }

        public decimal StartPreis { get; set; }
        public decimal MaximalPreis { get; set; }
        public decimal PreisProStunde { get; set; }
    }
}
