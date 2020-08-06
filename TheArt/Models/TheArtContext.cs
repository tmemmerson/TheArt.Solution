using Microsoft.EntityFrameworkCore;

namespace TheArt.Models
{
  public class TheArtContext : DbContext
  {
    public DbSet<Movement> Movements { get; set; }
    public DbSet<Artist> Artists { get; set;}
    public DbSet<Piece> Pieces {get; set;}
    public DbSet<ArtistMovement> ArtistMovement { get; set; }
    
    public TheArtContext(DbContextOptions options) : base(options) {}
  }
}