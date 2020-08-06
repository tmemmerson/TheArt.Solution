using Microsoft.AspNetCore.Mvc;

namespace TheArt.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}