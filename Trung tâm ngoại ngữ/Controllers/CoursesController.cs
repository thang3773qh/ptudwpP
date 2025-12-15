using LinguaCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinguaCenter.Controllers
{
    public class CoursesController : Controller
    {
        private readonly LinguaCenterContext _context;
        public CoursesController(LinguaCenterContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/course/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbCourses == null)
            {
                return NotFound();
            }

            var course = await _context.TbCourses.Include(i => i.Trainer)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            ViewBag.OrderCount = await _context.TbOrders.CountAsync(o => o.CourseId == id);

            return View(course);
        }
    }
}
