using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using berkeley_college.Models;

namespace berkeley_college.Controllers
{
    public class TeacherModulesController : Controller
    {
        private readonly ModelContext _context;

        public TeacherModulesController(ModelContext context)
        {
            _context = context;
        }

        // GET: TeacherModules
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.TeacherModule.Include(t => t.Module).Include(t => t.Teacher);
            return View(await modelContext.ToListAsync());
        }

        // GET: TeacherModules/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == "Nope")
            {
                id = (await _context.Teacher.ToListAsync())[0].TeacherId;
            }
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId");
            ViewBag.Teacher = (await _context.Teacher.FromSqlRaw($"select * from teacher where teacher_id = '{id}'").ToListAsync())[0];
            ViewBag.Modules = await _context.Module.FromSqlRaw($"select * from module where module_id in (select module_id from teacher_module where teacher_id ='{id}')").ToListAsync();
            return View();

        }

        // GET: TeacherModules/Create
        public IActionResult Create()
        {
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId");
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId");
            return View();
        }

        // POST: TeacherModules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeacherId,ModuleId")] TeacherModule teacherModule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherModule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", teacherModule.ModuleId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId", teacherModule.TeacherId);
            return View(teacherModule);
        }

        // GET: TeacherModules/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherModule = await _context.TeacherModule.FindAsync(id);
            if (teacherModule == null)
            {
                return NotFound();
            }
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", teacherModule.ModuleId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId", teacherModule.TeacherId);
            return View(teacherModule);
        }

        // POST: TeacherModules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,TeacherId,ModuleId")] TeacherModule teacherModule)
        {
            if (id != teacherModule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherModule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherModuleExists(teacherModule.Id))
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
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", teacherModule.ModuleId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId", teacherModule.TeacherId);
            return View(teacherModule);
        }

        // GET: TeacherModules/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherModule = await _context.TeacherModule
                .Include(t => t.Module)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherModule == null)
            {
                return NotFound();
            }

            return View(teacherModule);
        }

        // POST: TeacherModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var teacherModule = await _context.TeacherModule.FindAsync(id);
            _context.TeacherModule.Remove(teacherModule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherModuleExists(string id)
        {
            return _context.TeacherModule.Any(e => e.Id == id);
        }
    }
}
