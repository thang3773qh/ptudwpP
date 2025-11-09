using Microsoft.AspNetCore.Mvc;

namespace Trung_tâm_ngoại_ngữ.Controllers
{
    public class TrainersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
