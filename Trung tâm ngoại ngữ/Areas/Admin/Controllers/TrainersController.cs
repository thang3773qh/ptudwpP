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
    public class TrainersController : Controller
    {
        private readonly LinguaCenterContext _context;

        public TrainersController(LinguaCenterContext context)
        {
            _context = context;
        }

        // GET: Admin/Trainers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbTrainers.ToListAsync());
        }

        // GET: Admin/Trainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTrainer = await _context.TbTrainers
                .FirstOrDefaultAsync(m => m.TrainerId == id);
            if (tbTrainer == null)
            {
                return NotFound();
            }

            return View(tbTrainer);
        }

        // GET: Admin/Trainers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Trainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainerId,FullName,Speciality,Description,Image,Facebook,Twitter,Instagram,LinkedIn,IsActive,CreatedDate")] TbTrainer tbTrainer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbTrainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbTrainer);
        }

        // GET: Admin/Trainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTrainer = await _context.TbTrainers.FindAsync(id);
            if (tbTrainer == null)
            {
                return NotFound();
            }
            return View(tbTrainer);
        }

        // POST: Admin/Trainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainerId,FullName,Speciality,Description,Image,Facebook,Twitter,Instagram,LinkedIn,IsActive,CreatedDate")] TbTrainer tbTrainer)
        {
            if (id != tbTrainer.TrainerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbTrainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbTrainerExists(tbTrainer.TrainerId))
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
            return View(tbTrainer);
        }

        // GET: Admin/Trainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTrainer = await _context.TbTrainers
                .FirstOrDefaultAsync(m => m.TrainerId == id);
            if (tbTrainer == null)
            {
                return NotFound();
            }

            return View(tbTrainer);
        }

        // POST: Admin/Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbTrainer = await _context.TbTrainers.FindAsync(id);
            if (tbTrainer != null)
            {
                _context.TbTrainers.Remove(tbTrainer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbTrainerExists(int id)
        {
            return _context.TbTrainers.Any(e => e.TrainerId == id);
        }
    }
}
