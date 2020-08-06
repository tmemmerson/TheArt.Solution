namespace TheArt.Models
{
  public class ArtistMovement
    {
        public int ArtistMovementId { get; set; }
        public int ArtistId { get; set; }
        public int MovementId { get; set; }
        public Artist Artist { get; set; }
        public Movement Movement { get; set; }
    }
}