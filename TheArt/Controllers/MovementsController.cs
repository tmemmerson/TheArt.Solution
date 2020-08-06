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

    public ActionResult Index(string searchQuery = null)
    {
      if (searchQuery == null)
      {
        ViewBag.SearchFlag = 0;
        return View(_db.Movements.ToList());
      }
      else
      {
        ViewBag.SearchFlag = 1;
        List<Movement> model = _db.Movements.Where(movement => movement.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
        return View(model);
      }
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Movement movement)
    {
      _db.Movements.Add(movement);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMovement = _db.Movements
          .Include(movement => movement.Artists)
          .ThenInclude(join => join.Artist)
          .FirstOrDefault(movement => movement.MovementId == id);
      return View(thisMovement);
    }

    public ActionResult Edit(int id)
    {
      var thisMovement = _db.Movements.FirstOrDefault(movement => movement.MovementId == id);
      return View(thisMovement);
    }

    [HttpPost]
    public ActionResult Edit(Movement movement)
    {
      _db.Entry(movement).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisMovement = _db.Movements.FirstOrDefault(movement => Movement.MovementId == id);
      return View(thisMovement);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMovement = _db.Movements.FirstOrDefault(movement => movement.MovementId == id);
      _db.Movements.Remove(thisMovement);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}