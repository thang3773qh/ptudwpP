using LinguaCenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCenter.Controllers
{
    public class TrainersController : Controller
    {
        private readonly LinguaCenterContext _context;

        public TrainersController(LinguaCenterContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var items = _context.TbTrainers.Where(m => (bool)m.IsActive).ToList();
            return View(items);
        }
    }
}
