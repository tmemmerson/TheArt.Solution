using Microsoft.AspNetCore.Mvc;
using TheArt.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TheArt.Controllers
{
  public class ArtistsController : Controller
  {
    private readonly TheArtContext _db;

    public ArtistsController(TheArtContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Artist> model = _db.Artists.ToList();
      return View(model);
    }
  }
}