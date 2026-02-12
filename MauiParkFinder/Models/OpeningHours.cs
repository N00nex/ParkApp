namespace MauiParkFinder.Models
{
    public class OpeningHours
    {
        public Guid Id { get; set; }
        public Guid ParkingGarageId { get; set; }
        public TimeSpan? OpenMonFri { get; set; }
        public TimeSpan? CloseMonFri { get; set; }
        public TimeSpan? OpenSatSun { get; set; }
        public TimeSpan? CloseSatSun { get; set; }

    }
}

