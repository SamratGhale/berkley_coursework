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
    public class StudentsResults: Controller
    {
        private readonly ModelContext _context;

        public StudentsResults(ModelContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if(id == "Nope"){
                id = (await _context.Result.FromSqlRaw($"select * from result").ToListAsync())[0].StudentId;
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId");
            ViewBag.student = (await _context.Student.FromSqlRaw($"select * from student where student_id = '{id}'").ToListAsync())[0];
            ViewBag.student.Person = (await _context.Person.FromSqlRaw($"select * from person where person_id= '{ViewBag.student.PersonId}'").ToListAsync())[0];
            ViewBag.results = await _context.Result.FromSqlRaw($"select * from result where student_id='{id}'").ToListAsync();

            foreach (var result in ViewBag.results)
            {
                result.Module = (await _context.Module.FromSqlRaw($"select * from module where  module_id ='{result.ModuleId}'").ToListAsync())[0];
                result.Assignment = (await _context.Assignment.FromSqlRaw($"select * from assignment where  assignment_id ='{result.AssignmentId}'").ToListAsync())[0];
            }

            return View();
        }
    }
}