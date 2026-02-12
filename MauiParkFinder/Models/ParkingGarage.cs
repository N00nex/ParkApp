namespace MauiParkFinder.Models
{
    public class ParkingGarage
    {
        public Guid Id { get; set; }
        public String PGName { get; set; }
        public int Distance { get; set; }
        public int AvailableSpaces { get; set; }

        public String MapsLink { get; set; }

        public Guid PriceID { get; set; }

        public Guid AddressID { get; set; }

        public OpeningHours OpeningHours { get; set; }
        public Price Price { get; set; }
        public Address Address { get; set; }
    }
}