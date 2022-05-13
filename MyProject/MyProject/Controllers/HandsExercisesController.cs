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
    public class HandsExercisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HandsExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HandsExercises
        public async Task<IActionResult> Index()
        {
            return View(await _context.HandsExercises.ToListAsync());
        }

        // GET: HandsExercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var handsExercises = await _context.HandsExercises
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (handsExercises == null)
            {
                return NotFound();
            }

            return View(handsExercises);
        }

        // GET: HandsExercises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HandsExercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseId,HandParty,ExerciseName,Reps,BreakTime")] HandsExercises handsExercises)
        {
            if (ModelState.IsValid)
            {
                _context.Add(handsExercises);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(handsExercises);
        }

        // GET: HandsExercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var handsExercises = await _context.HandsExercises.FindAsync(id);
            if (handsExercises == null)
            {
                return NotFound();
            }
            return View(handsExercises);
        }

        // POST: HandsExercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseId,HandParty,ExerciseName,Reps,BreakTime")] HandsExercises handsExercises)
        {
            if (id != handsExercises.ExerciseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(handsExercises);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HandsExercisesExists(handsExercises.ExerciseId))
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
            return View(handsExercises);
        }

        // GET: HandsExercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var handsExercises = await _context.HandsExercises
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (handsExercises == null)
            {
                return NotFound();
            }

            return View(handsExercises);
        }

        // POST: HandsExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var handsExercises = await _context.HandsExercises.FindAsync(id);
            _context.HandsExercises.Remove(handsExercises);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HandsExercisesExists(int id)
        {
            return _context.HandsExercises.Any(e => e.ExerciseId == id);
        }
    }
}
