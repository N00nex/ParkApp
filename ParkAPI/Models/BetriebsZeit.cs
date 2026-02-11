namespace ParkAPI.Models
{
    public class BetriebsZeit
    {
        public Guid Id { get; set; }
        public Guid ParkhausId { get; set; }
        public int TagVon { get; set; }
        public int TagBis { get; set; }
        public TimeSpan OeffnetUm { get; set; }
        public TimeSpan SchliesstUm { get; set; }
        
    }
}
