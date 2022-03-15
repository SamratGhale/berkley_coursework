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
    public class StudentsPayment: Controller
    {
        private readonly ModelContext _context;

        public StudentsPayment(ModelContext context){
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
            ViewBag.payments = await _context.Payment.FromSqlRaw($"select * from payment where student_id='{id}'").ToListAsync();
            return View();
        }
    }
}