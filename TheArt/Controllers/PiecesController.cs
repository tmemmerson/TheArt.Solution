using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TheArt.Models;


namespace TheArt.Controllers
{
  public class PiecesController : Controller
  {
    private readonly TheArtContext _db;

    public PiecesController(TheArtContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Piece> model = _db.Pieces.Include(piece => piece.Artist).ToList();  //did you change something here?
      return View(model);
    }
  
    public ActionResult Create()
    {
      ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "ArtistName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Piece Piece)
    {
      _db.Pieces.Add(Piece);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Piece thisPiece = _db.Pieces.FirstOrDefault(pieces => pieces.PieceId == id);
      var artistId = thisPiece.ArtistId;
      Artist thisArtist = _db.Artists.FirstOrDefault(artists => artists.ArtistId == artistId);
      ViewBag.Artist = thisArtist.ArtistName;
      return View(thisPiece);
    }
  }
}