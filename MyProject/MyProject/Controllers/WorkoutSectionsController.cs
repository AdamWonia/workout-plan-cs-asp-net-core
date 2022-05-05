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
    public class WorkoutSectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkoutSectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkoutSections
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkoutSection.ToListAsync());
        }

        // I click details and it send me into list of exercises in specific section
        // GET: WorkoutSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutSection = await _context.WorkoutSection
                .FirstOrDefaultAsync(m => m.WorkoutSectionId == id);
            if (workoutSection == null)
            {
                return NotFound();
            }

            return View(workoutSection);
            //return RedirectToAction("Index", "Exercises", new { @id = id });
        }


        // GET: WorkoutSections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkoutSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkoutSectionId,WorkoutSectionName")] WorkoutSection workoutSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workoutSection);
        }

        // GET: WorkoutSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutSection = await _context.WorkoutSection.FindAsync(id);
            if (workoutSection == null)
            {
                return NotFound();
            }
            return View(workoutSection);
        }

        // POST: WorkoutSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkoutSectionId,WorkoutSectionName")] WorkoutSection workoutSection)
        {
            if (id != workoutSection.WorkoutSectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutSectionExists(workoutSection.WorkoutSectionId))
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
            return View(workoutSection);
        }

        // GET: WorkoutSections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutSection = await _context.WorkoutSection
                .FirstOrDefaultAsync(m => m.WorkoutSectionId == id);
            if (workoutSection == null)
            {
                return NotFound();
            }

            return View(workoutSection);
        }

        // POST: WorkoutSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutSection = await _context.WorkoutSection.FindAsync(id);
            _context.WorkoutSection.Remove(workoutSection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutSectionExists(int id)
        {
            return _context.WorkoutSection.Any(e => e.WorkoutSectionId == id);
        }
    }
}
