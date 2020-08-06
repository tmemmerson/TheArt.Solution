using Microsoft.AspNetCore.Mvc;
using TheArt.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TheArt.Controllers
{
  public class MovementsController : Controller
  {
    private readonly TheArtContext _db;

    public MovementsController(TheArtContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Movement> model = _db.Movements.ToList();
      return View(model);
    }

    public ActionResult Create() //good
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Movement movement) //good
    {
      _db.Movements.Add(movement);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id) //good
    {
      var thisMovement = _db.Movements
          .Include(movement => movement.Artists)
          .ThenInclude(join => join.Artist)
          .FirstOrDefault(movement => movement.MovementId == id);
      return View(thisMovement);
    }

    public ActionResult Edit(int id) //good
    {
      var thisMovement = _db.Movements.FirstOrDefault(movement => movement.MovementId == id);
      return View(thisMovement);
    }

    [HttpPost]
    public ActionResult Edit(Movement movement) //good
    {
      _db.Entry(movement).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id) //good
    {
      var thisMovement = _db.Movements.FirstOrDefault(movement => movement.MovementId == id);
      return View(thisMovement);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id) //good
    {
      var thisMovement = _db.Movements.FirstOrDefault(movement => movement.MovementId == id);
      _db.Movements.Remove(thisMovement);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}