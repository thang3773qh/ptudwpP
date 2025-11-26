using Microsoft.AspNetCore.Mvc;

namespace LinguaCenter.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
