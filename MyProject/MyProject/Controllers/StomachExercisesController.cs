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
    public class StomachExercisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StomachExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StomachExercises
        public async Task<IActionResult> Index()
        {
            return View(await _context.StomachExercises.ToListAsync());
        }

        // GET: StomachExercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stomachExercises = await _context.StomachExercises
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (stomachExercises == null)
            {
                return NotFound();
            }

            return View(stomachExercises);
        }

        // GET: StomachExercises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StomachExercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseId,StomachParty,ExerciseName,Reps,BreakTime")] StomachExercises stomachExercises)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stomachExercises);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stomachExercises);
        }

        // GET: StomachExercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stomachExercises = await _context.StomachExercises.FindAsync(id);
            if (stomachExercises == null)
            {
                return NotFound();
            }
            return View(stomachExercises);
        }

        // POST: StomachExercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseId,StomachParty,ExerciseName,Reps,BreakTime")] StomachExercises stomachExercises)
        {
            if (id != stomachExercises.ExerciseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stomachExercises);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StomachExercisesExists(stomachExercises.ExerciseId))
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
            return View(stomachExercises);
        }

        // GET: StomachExercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stomachExercises = await _context.StomachExercises
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (stomachExercises == null)
            {
                return NotFound();
            }

            return View(stomachExercises);
        }

        // POST: StomachExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stomachExercises = await _context.StomachExercises.FindAsync(id);
            _context.StomachExercises.Remove(stomachExercises);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StomachExercisesExists(int id)
        {
            return _context.StomachExercises.Any(e => e.ExerciseId == id);
        }
    }
}
