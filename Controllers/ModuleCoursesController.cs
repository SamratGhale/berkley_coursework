using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using berkley_coursework.Models;

namespace berkley_coursework.Controllers
{
    public class ModuleCoursesController : Controller
    {
        private readonly ModelContext _context;

        public ModuleCoursesController(ModelContext context)
        {
            _context = context;
        }

        // GET: ModuleCourses
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.ModuleCourse.Include(m => m.Course).Include(m => m.Module);
            return View(await modelContext.ToListAsync());
        }

        // GET: ModuleCourses/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moduleCourse = await _context.ModuleCourse
                .Include(m => m.Course)
                .Include(m => m.Module)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (moduleCourse == null)
            {
                return NotFound();
            }

            return View(moduleCourse);
        }

        // GET: ModuleCourses/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId");
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId");
            return View();
        }

        // POST: ModuleCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CourseId,ModuleId")] ModuleCourse moduleCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moduleCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", moduleCourse.CourseId);
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", moduleCourse.ModuleId);
            return View(moduleCourse);
        }

        // GET: ModuleCourses/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moduleCourse = await _context.ModuleCourse.FindAsync(id);
            if (moduleCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", moduleCourse.CourseId);
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", moduleCourse.ModuleId);
            return View(moduleCourse);
        }

        // POST: ModuleCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,CourseId,ModuleId")] ModuleCourse moduleCourse)
        {
            if (id != moduleCourse.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moduleCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleCourseExists(moduleCourse.ID))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", moduleCourse.CourseId);
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", moduleCourse.ModuleId);
            return View(moduleCourse);
        }

        // GET: ModuleCourses/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moduleCourse = await _context.ModuleCourse
                .Include(m => m.Course)
                .Include(m => m.Module)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (moduleCourse == null)
            {
                return NotFound();
            }

            return View(moduleCourse);
        }

        // POST: ModuleCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var moduleCourse = await _context.ModuleCourse.FindAsync(id);
            _context.ModuleCourse.Remove(moduleCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModuleCourseExists(string id)
        {
            return _context.ModuleCourse.Any(e => e.ID == id);
        }
    }
}
