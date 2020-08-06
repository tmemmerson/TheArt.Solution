using Microsoft.AspNetCore.Mvc;
using TheArt.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TheArt.Controllers
{
  public class ArtistsController : Controller
  {
    private readonly TheArtContext _db;

    public ArtistsController(TheArtContext db) //checked
    {
      _db = db;
    }

    public ActionResult Index() //unsure
    {
      List<Artist> model = _db.Artists.ToList(); //create list out of database table called artists
      return View(model);
    }

    public ActionResult Create() //good
    {
      ViewBag.MovementId = new SelectList(_db.Movements, "MovementId", "MovementName");
      ViewBag.Piece = new SelectList(_db.Pieces, "PieceId", "PieceName");
      return View();
    }

    [HttpPost]

    public ActionResult Create(Artist artist, int MovementId) //good
    {
      _db.Artists.Add(artist); // if conditional statement below is not true then just add artist object to list of artists
      if(MovementId != 0)
      {
        _db.ArtistMovement.Add(new ArtistMovement() {MovementId = MovementId, ArtistId = artist.ArtistId}); // we did artist.ArtistId because we passed the artist object as an argument to create so we have to go inside and grab the ArtistId
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id) //good
    {
      var thisArtist = _db.Artists
        .Include(artist => artist.Pieces)
        .Include(artist => artist.Movements)
        .ThenInclude(join => join.Movement)
        .FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }


    public ActionResult Edit(int id) //good
    {
      var thisArtist = _db.Artists.FirstOrDefault(artists => artists.ArtistId == id);
      ViewBag.MovementId = new SelectList(_db.Movements, "MovementId", "MovementName");
      ViewBag.PieceId = new SelectList(_db.Pieces, "PieceId", "PieceName");
      return View(thisArtist);
    }
  
    [HttpPost]
    public ActionResult Edit(Artist artist, int MovementId) //good
    {
      if (MovementId != 0)
      {
        _db.ArtistMovement.Add(new ArtistMovement() { MovementId = MovementId, ArtistId = artist.ArtistId });
      }
      _db.Entry(artist).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id) //good
    {
      var thisArtist = _db.Artists.FirstOrDefault(artists => artists.ArtistId == id);
      return View(thisArtist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id) //good
    {
      var thisArtist = _db.Artists.FirstOrDefault(artists => artists.ArtistId == id);
      _db.Artists.Remove(thisArtist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteMovement(int joinId) // good
    {
      var joinEntry = _db.ArtistMovement.FirstOrDefault(entry => entry.ArtistMovementId == joinId); // seperates the join table so you can remove a movement
      _db.ArtistMovement.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    
    public ActionResult AddMovement(int id) //good
    {
      var thisArtist = _db.Artists.FirstOrDefault(artists => artists.ArtistId == id);
      ViewBag.MovementId = new SelectList(_db.Movements, "MovementId", "MovementName");
      return View(thisArtist);
    }

    [HttpPost]
    public ActionResult AddMovement(Artist artist, int MovementId) //good
    {
      if (MovementId != 0)
      {
        _db.ArtistMovement.Add(new ArtistMovement() { MovementId = MovementId, ArtistId = artist.ArtistId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}