using Microsoft.AspNetCore.Mvc;

namespace LinguaCenter.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
