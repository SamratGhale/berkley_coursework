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
    public class StudentsAssignment: Controller
    {
        private readonly ModelContext _context;

        public StudentsAssignment(ModelContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if(id == "Nope"){
                id = (await _context.Payment.FromSqlRaw($"select * from payment").ToListAsync())[0].StudentId;
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId");
            ViewBag.student = (await _context.Student.FromSqlRaw($"select * from student where student_id = '{id}'").ToListAsync())[0];
            ViewBag.student.Person = (await _context.Person.FromSqlRaw($"select * from person where person_id= '{ViewBag.student.PersonId}'").ToListAsync())[0];
            ViewBag.payments = await _context.Payment.FromSqlRaw($"select * from payment where student_id='{id}'").ToListAsync();
            return View();
        }
    }
}