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
    public class ExamsController : Controller
    {
        private readonly ModelContext _context;

        public ExamsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Exams
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Exam.Include(e => e.Assignment).Include(e => e.Module).Include(e => e.Student);
            return View(await modelContext.ToListAsync());
        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exam
                .Include(e => e.Assignment)
                .Include(e => e.Module)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: Exams/Create
        public IActionResult Create()
        {
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId");
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId");
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExamId,ModuleId,AssignmentId,StudentId,Grade,Status")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId", exam.AssignmentId);
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", exam.ModuleId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", exam.StudentId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exam.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId", exam.AssignmentId);
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", exam.ModuleId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", exam.StudentId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ExamId,ModuleId,AssignmentId,StudentId,Grade,Status")] Exam exam)
        {
            if (id != exam.ExamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamExists(exam.ExamId))
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
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId", exam.AssignmentId);
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", exam.ModuleId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", exam.StudentId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exam
                .Include(e => e.Assignment)
                .Include(e => e.Module)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var exam = await _context.Exam.FindAsync(id);
            _context.Exam.Remove(exam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamExists(string id)
        {
            return _context.Exam.Any(e => e.ExamId == id);
        }
    }
}
