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
    public class ModuleAssignmentsController : Controller
    {
        private readonly ModelContext _context;

        public ModuleAssignmentsController(ModelContext context)
        {
            _context = context;
        }

        // GET: ModuleAssignments
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.ModuleAssignment.Include(m => m.Assignment).Include(m => m.Module);
            return View(await modelContext.ToListAsync());
        }

        // GET: ModuleAssignments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moduleAssignment = await _context.ModuleAssignment
                .Include(m => m.Assignment)
                .Include(m => m.Module)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (moduleAssignment == null)
            {
                return NotFound();
            }

            return View(moduleAssignment);
        }

        // GET: ModuleAssignments/Create
        public IActionResult Create()
        {
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId");
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId");
            return View();
        }

        // POST: ModuleAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AssignmentId,ModuleId,Type")] ModuleAssignment moduleAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moduleAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId", moduleAssignment.AssignmentId);
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", moduleAssignment.ModuleId);
            return View(moduleAssignment);
        }

        // GET: ModuleAssignments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moduleAssignment = await _context.ModuleAssignment.FindAsync(id);
            if (moduleAssignment == null)
            {
                return NotFound();
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId", moduleAssignment.AssignmentId);
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", moduleAssignment.ModuleId);
            return View(moduleAssignment);
        }

        // POST: ModuleAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,AssignmentId,ModuleId,Type")] ModuleAssignment moduleAssignment)
        {
            if (id != moduleAssignment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moduleAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleAssignmentExists(moduleAssignment.ID))
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
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId", moduleAssignment.AssignmentId);
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", moduleAssignment.ModuleId);
            return View(moduleAssignment);
        }

        // GET: ModuleAssignments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moduleAssignment = await _context.ModuleAssignment
                .Include(m => m.Assignment)
                .Include(m => m.Module)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (moduleAssignment == null)
            {
                return NotFound();
            }

            return View(moduleAssignment);
        }

        // POST: ModuleAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var moduleAssignment = await _context.ModuleAssignment.FindAsync(id);
            _context.ModuleAssignment.Remove(moduleAssignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModuleAssignmentExists(string id)
        {
            return _context.ModuleAssignment.Any(e => e.ID == id);
        }
    }
}
