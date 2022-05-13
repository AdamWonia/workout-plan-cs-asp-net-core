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
    public class LegsExercisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LegsExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LegsExercises
        public async Task<IActionResult> Index()
        {
            return View(await _context.LegsExercises.ToListAsync());
        }

        // GET: LegsExercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legsExercises = await _context.LegsExercises
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (legsExercises == null)
            {
                return NotFound();
            }

            return View(legsExercises);
        }

        // GET: LegsExercises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LegsExercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseId,LegParty,ExerciseName,Reps,BreakTime")] LegsExercises legsExercises)
        {
            if (ModelState.IsValid)
            {
                _context.Add(legsExercises);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(legsExercises);
        }

        // GET: LegsExercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legsExercises = await _context.LegsExercises.FindAsync(id);
            if (legsExercises == null)
            {
                return NotFound();
            }
            return View(legsExercises);
        }

        // POST: LegsExercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseId,LegParty,ExerciseName,Reps,BreakTime")] LegsExercises legsExercises)
        {
            if (id != legsExercises.ExerciseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(legsExercises);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LegsExercisesExists(legsExercises.ExerciseId))
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
            return View(legsExercises);
        }

        // GET: LegsExercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legsExercises = await _context.LegsExercises
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (legsExercises == null)
            {
                return NotFound();
            }

            return View(legsExercises);
        }

        // POST: LegsExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var legsExercises = await _context.LegsExercises.FindAsync(id);
            _context.LegsExercises.Remove(legsExercises);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LegsExercisesExists(int id)
        {
            return _context.LegsExercises.Any(e => e.ExerciseId == id);
        }
    }
}
