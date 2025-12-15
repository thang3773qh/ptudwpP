using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LinguaCenter.Models;

namespace LinguaCenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoursesController : Controller
    {
        private readonly LinguaCenterContext _context;

        public CoursesController(LinguaCenterContext context)
        {
            _context = context;
        }

        // GET: Admin/Courses
        public async Task<IActionResult> Index()
        {
            var linguaCenterContext = _context.TbCourses.Include(t => t.Category).Include(t => t.Trainer);
            return View(await linguaCenterContext.ToListAsync());
        }

        // GET: Admin/Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCourse = await _context.TbCourses
                .Include(t => t.Category)
                .Include(t => t.Trainer)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (tbCourse == null)
            {
                return NotFound();
            }

            return View(tbCourse);
        }

        // GET: Admin/Courses/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.TbCategories, "CategoryId", "Name");
            ViewData["TrainerId"] = new SelectList(_context.TbTrainers, "TrainerId", "FullName");
            return View();
        }

        // POST: Admin/Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,Title,Alias,Description,ShortDescription,Price,PriceSale,ContentHours,TotalWeeks,Level,Language,Prerequisites,LastUpdate,Image,IsActive,TrainerId,CategoryId")] TbCourse tbCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.TbCategories, "CategoryId", "CategoryId", tbCourse.CategoryId);
            ViewData["TrainerId"] = new SelectList(_context.TbTrainers, "TrainerId", "TrainerId", tbCourse.TrainerId);
            return View(tbCourse);
        }

        // GET: Admin/Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCourse = await _context.TbCourses.FindAsync(id);
            if (tbCourse == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.TbCategories, "CategoryId", "Name", tbCourse.CategoryId);
            ViewData["TrainerId"] = new SelectList(_context.TbTrainers, "TrainerId", "FullName", tbCourse.TrainerId);
            return View(tbCourse);
        }

        // POST: Admin/Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,Title,Alias,Description,ShortDescription,Price,PriceSale,ContentHours,TotalWeeks,Level,Language,Prerequisites,LastUpdate,Image,IsActive,TrainerId,CategoryId")] TbCourse tbCourse)
        {
            if (id != tbCourse.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCourseExists(tbCourse.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.TbCategories, "CategoryId", "CategoryId", tbCourse.CategoryId);
            ViewData["TrainerId"] = new SelectList(_context.TbTrainers, "TrainerId", "TrainerId", tbCourse.TrainerId);
            return View(tbCourse);
        }

        // GET: Admin/Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCourse = await _context.TbCourses
                .Include(t => t.Category)
                .Include(t => t.Trainer)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (tbCourse == null)
            {
                return NotFound();
            }

            return View(tbCourse);
        }

        // POST: Admin/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCourse = await _context.TbCourses.FindAsync(id);
            if (tbCourse != null)
            {
                _context.TbCourses.Remove(tbCourse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCourseExists(int id)
        {
            return _context.TbCourses.Any(e => e.CourseId == id);
        }
    }
}
