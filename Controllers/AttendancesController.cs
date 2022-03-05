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
    public class AttendancesController : Controller
    {
        private readonly ModelContext _context;

        public AttendancesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Attendances
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Attendance.Include(a => a.Module).Include(a => a.Student);
            return View(await modelContext.ToListAsync());
        }

        // GET: Attendances/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance
                .Include(a => a.Module)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.AttendanceID == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendances/Create
        public IActionResult Create()
        {
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId");
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttendanceID,StudentId,ModuleId,AttendanceCount")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", attendance.ModuleId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", attendance.StudentId);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", attendance.ModuleId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", attendance.StudentId);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AttendanceID,StudentId,ModuleId,AttendanceCount")] Attendance attendance)
        {
            if (id != attendance.AttendanceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.AttendanceID))
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
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", attendance.ModuleId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", attendance.StudentId);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance
                .Include(a => a.Module)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.AttendanceID == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var attendance = await _context.Attendance.FindAsync(id);
            _context.Attendance.Remove(attendance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(string id)
        {
            return _context.Attendance.Any(e => e.AttendanceID == id);
        }
    }
}
