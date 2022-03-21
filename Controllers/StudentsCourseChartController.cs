using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using berkeley_college.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace berkeley_college.Controllers
{
    public class StudentCourseChartController:Controller
    {
        private readonly ModelContext _context;

        public StudentCourseChartController(ModelContext context)
        {
            _context = context;
        }
		public async Task<ActionResult> IndexAsync()
		{
			List<DataPoint> dataPoints = new List<DataPoint>();

            var courses = await _context.Course.FromSqlRaw($"select * from course").ToListAsync();

            foreach(var course in courses){
                int x = (await _context.Student.FromSqlRaw($"select * from student where course_id  = '{course.CourseId}'").ToListAsync()).Count;
                dataPoints.Add(new DataPoint { X = x, Y = course.Name });
            }

            ViewBag.ChartTitle = "Number of students in each Course";
            ViewBag.ChartSubTitle = "X = name of course , Y = number of students in the course";
            ViewBag.ChartType = "area";
            String j = JsonConvert.SerializeObject(dataPoints);
			ViewBag.DataPoints = j;
 
			return View("~/Views/CommonChartView/Index.cshtml");
		}
    }
}