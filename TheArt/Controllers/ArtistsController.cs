using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TheArt.Controllers
{
  public class ArtistsController : Controllers
  {
    private readonly TheArtCotext _db;

    public ArtistsController(TheArtCotext db)
    {
      _db = db;
    }


  }
}