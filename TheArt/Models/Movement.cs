using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheArt.Models
{
    public class Movement
    {
      public Movement()
      {
          this.Artists = new HashSet<ArtistMovement>();
      }

      public int MovementId { get; set; }
      public string MovementName { get; set; }
      public string MovementDescription { get; set; }
      [DataType(DataType.Date)]
      public DateTime MovementStart { get; set; }
      [DataType(DataType.Date)]
      public DateTime MovementEnd { get; set; }
      public virtual ICollection<ArtistMovement> Artists { get; set; }
    }
}