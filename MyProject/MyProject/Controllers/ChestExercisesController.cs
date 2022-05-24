using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class ChestExercisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChestExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChestExercises
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChestExercises.ToListAsync());
        }

        // GET: ChestExercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chestExercises = await _context.ChestExercises
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (chestExercises == null)
            {
                return NotFound();
            }

            return View(chestExercises);
        }

        // GET: ChestExercises/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChestExercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseId,ChestPart,ExerciseName,Reps,BreakTime")] ChestExercises chestExercises)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chestExercises);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chestExercises);
        }

        // GET: ChestExercises/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chestExercises = await _context.ChestExercises.FindAsync(id);
            if (chestExercises == null)
            {
                return NotFound();
            }
            return View(chestExercises);
        }

        // POST: ChestExercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseId,ChestPart,ExerciseName,Reps,BreakTime")] ChestExercises chestExercises)
        {
            if (id != chestExercises.ExerciseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chestExercises);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChestExercisesExists(chestExercises.ExerciseId))
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
            return View(chestExercises);
        }

        // GET: ChestExercises/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chestExercises = await _context.ChestExercises
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (chestExercises == null)
            {
                return NotFound();
            }

            return View(chestExercises);
        }

        // POST: ChestExercises/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chestExercises = await _context.ChestExercises.FindAsync(id);
            _context.ChestExercises.Remove(chestExercises);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChestExercisesExists(int id)
        {
            return _context.ChestExercises.Any(e => e.ExerciseId == id);
        }
    }
}
