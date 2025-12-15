using LinguaCenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCenter.Controllers
{
    public class AboutController : Controller
    {
        private readonly LinguaCenterContext _context;
        public AboutController(LinguaCenterContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var feedbacks = _context.TbFeedbacks
                .Where(e => (bool)e.IsActive)
                .ToList();
            return View(feedbacks);
        }
    }
}
