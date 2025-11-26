using LinguaCenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCenter.Controllers
{
    public class EventsController : Controller
    {
        private readonly LinguaCenterContext _context;
        public EventsController(LinguaCenterContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var events = _context.TbEvents
                .Where(e => (bool)e.IsActive)
                .OrderByDescending(e => e.EventDate)
                .ToList();
            return View(events);
        }
    }
}
