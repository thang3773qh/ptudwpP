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
    public class FeedbacksController : Controller
    {
        private readonly LinguaCenterContext _context;

        public FeedbacksController(LinguaCenterContext context)
        {
            _context = context;
        }

        // GET: Admin/Feedbacks
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbFeedbacks.ToListAsync());
        }

        // GET: Admin/Feedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbFeedback = await _context.TbFeedbacks
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (tbFeedback == null)
            {
                return NotFound();
            }

            return View(tbFeedback);
        }

        // GET: Admin/Feedbacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedbackId,FullName,JobTitle,AvatarPath,Rating,Content,CreateDate,IsActive")] TbFeedback tbFeedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbFeedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbFeedback);
        }

        // GET: Admin/Feedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbFeedback = await _context.TbFeedbacks.FindAsync(id);
            if (tbFeedback == null)
            {
                return NotFound();
            }
            return View(tbFeedback);
        }

        // POST: Admin/Feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedbackId,FullName,JobTitle,AvatarPath,Rating,Content,CreateDate,IsActive")] TbFeedback tbFeedback)
        {
            if (id != tbFeedback.FeedbackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbFeedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbFeedbackExists(tbFeedback.FeedbackId))
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
            return View(tbFeedback);
        }

        // GET: Admin/Feedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbFeedback = await _context.TbFeedbacks
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (tbFeedback == null)
            {
                return NotFound();
            }

            return View(tbFeedback);
        }

        // POST: Admin/Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbFeedback = await _context.TbFeedbacks.FindAsync(id);
            if (tbFeedback != null)
            {
                _context.TbFeedbacks.Remove(tbFeedback);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbFeedbackExists(int id)
        {
            return _context.TbFeedbacks.Any(e => e.FeedbackId == id);
        }
    }
}
