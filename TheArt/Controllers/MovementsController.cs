using Microsoft.AspNetCore.Mvc;
using TheArt.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TheArt.Controllers
{
  public class MovementsController : Controller
  {
    private readonly TheArtContext _db;

    public MovementsController(TheArtContext db) //checked
    {
      _db = db;
    }

    public ActionResult Index() //checked
    {
      List<Movement> model = _db.Movements.ToList();
      return View(model);
    }

    public ActionResult Create() //checked
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Movement movement) //checked
    {
      _db.Movements.Add(movement);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id) //checked
    {
      var thisMovement = _db.Movements
          .Include(movement => movement.Artists)
          .ThenInclude(join => join.Artist)
          .FirstOrDefault(movement => movement.MovementId == id);
      return View(thisMovement);
    }

    public ActionResult Edit(int id) //checked
    {
      var thisMovement = _db.Movements.FirstOrDefault(movements => movements.MovementId == id);
      ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "ArtistName");
      return View(thisMovement);
    }

    [HttpPost]
    public ActionResult Edit(Movement movement, int ArtistId) //checked
    {
      if(ArtistId != 0)
      {
        _db.ArtistMovement.Add(new ArtistMovement() {ArtistId = ArtistId, MovementId = movement.MovementId});
      }
      _db.Entry(movement).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id) //checked
    {
      var thisMovement = _db.Movements.FirstOrDefault(movement => movement.MovementId == id);
      return View(thisMovement);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id) //checkedd
    {
      var thisMovement = _db.Movements.FirstOrDefault(movement => movement.MovementId == id);
      _db.Movements.Remove(thisMovement);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}