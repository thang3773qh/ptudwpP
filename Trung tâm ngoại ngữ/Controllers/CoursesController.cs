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
            //ViewBag.trainer = _context.TbTrainers
            //    .Where(i => i.TrainerId == id && i.IsActive).ToList();
            //ViewBag.productRelated = _context.TbProducts
            //    .Where(i => i.ProductId != id && i.CategoryProductId == product.CategoryProductId).Take(5)
            //    .OrderByDescending(i => i.ProductId).ToList();
            return View(course);
        }
    }
}
