using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfDeath { get; set; }
        public ICollection<Piece> Pieces { get; set; }
        public ICollection<ArtistMovement> Movements { get; set;} 
    }
}