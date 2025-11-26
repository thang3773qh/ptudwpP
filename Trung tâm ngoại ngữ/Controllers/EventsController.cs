using Microsoft.AspNetCore.Mvc;

namespace LinguaCenter.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
