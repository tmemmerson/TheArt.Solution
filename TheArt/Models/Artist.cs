using System;
using System.Collections.Generic;

namespace TheArt.Models
{
    public class Artist
    {
        public Artist()
        {
            this.Movements = new HashSet<ArtistMovement>();
            this.Pieces = new HashSet<Piece>();
        }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public virtual ICollection<Piece> Pieces { get; set; }
        public ICollection<ArtistMovement> Movements { get; set;} 
    }
}