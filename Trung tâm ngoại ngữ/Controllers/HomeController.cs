using LinguaCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LinguaCenter.Controllers
{
    public class HomeController : Controller
    {
        private readonly LinguaCenterContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(LinguaCenterContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _context.TbCategories.ToList();
            ViewBag.popularCourses = _context.TbCourses.Include(m => m.Category).Include(m => m.Trainer)
                .Where(m => (bool)m.IsActive).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
