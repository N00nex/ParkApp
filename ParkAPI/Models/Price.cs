namespace ParkAPI.Models
{
    public class Price
    {
        public Guid Id { get; set; }
        public decimal Entrance { get; set; }
        public decimal MaxDaily { get; set; }
        public decimal PerHour { get; set; }
    }
}
