using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class BackExercisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BackExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BackExercises
        public async Task<IActionResult> Index()
        {
            return View(await _context.BackExercises.ToListAsync());
        }

        // GET: BackExercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var backExercises = await _context.BackExercises
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (backExercises == null)
            {
                return NotFound();
            }

            return View(backExercises);
        }

        // GET: BackExercises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BackExercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseId,BackPart,ExerciseName,Reps,BreakTime")] BackExercises backExercises)
        {
            if (ModelState.IsValid)
            {
                _context.Add(backExercises);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(backExercises);
        }

        // GET: BackExercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var backExercises = await _context.BackExercises.FindAsync(id);
            if (backExercises == null)
            {
                return NotFound();
            }
            return View(backExercises);
        }

        // POST: BackExercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseId,BackPart,ExerciseName,Reps,BreakTime")] BackExercises backExercises)
        {
            if (id != backExercises.ExerciseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(backExercises);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BackExercisesExists(backExercises.ExerciseId))
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
            return View(backExercises);
        }

        // GET: BackExercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var backExercises = await _context.BackExercises
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (backExercises == null)
            {
                return NotFound();
            }

            return View(backExercises);
        }

        // POST: BackExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var backExercises = await _context.BackExercises.FindAsync(id);
            _context.BackExercises.Remove(backExercises);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BackExercisesExists(int id)
        {
            return _context.BackExercises.Any(e => e.ExerciseId == id);
        }
    }
}
