using berkeley_college.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace berkeley_college.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ModelContext _context;


        public HomeController(ModelContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
			List<DataPoint> dataPoints = new List<DataPoint>();

            int[,] ts = new int[4, 2] { { 0, 39 }, { 40, 59 }, { 60, 79 }, {80, 100 } };

            for (int i = 0; i < 4; i++)
            {
                string y = "("+ts[i,0].ToString()+"," + ts[i, 1].ToString() + ")";
                int x = (await _context.Result.FromSqlRaw($"select * from result where grade between {ts[i, 0]} and {ts[i, 1]}").ToListAsync()).Count;
                dataPoints.Add(new DataPoint { X = x, Y = y });
            }

            ViewBag.ChartTitle = "Number of students in each range of grades";
            ViewBag.ChartSubTitle = "X = range of grades, Y = number of students with that grade";
            ViewBag.ChartType = "area";
            String j = JsonConvert.SerializeObject(dataPoints);
			ViewBag.DataPoints = j;

            List<DataPoint> dataPoints2 = new List<DataPoint>();

            var modules = await _context.Module.FromSqlRaw($"select * from module").ToListAsync();

            foreach(var module in modules){
                int x = (await _context.Attendance.FromSqlRaw($"select * from attendance where module_id = '{module.ModuleId}'").ToListAsync()).Count;
                dataPoints2.Add(new DataPoint { X = x, Y = module.Code});
            }

            ViewBag.ChartTitle2 = "Number of attendance in on each module";
            ViewBag.ChartSubTitle2 = "";
            ViewBag.ChartType2 = "pie";
            String j2 = JsonConvert.SerializeObject(dataPoints2);
			ViewBag.DataPoints2 = j2;

            List<DataPoint> dataPoints3 = new List<DataPoint>();

            var courses = await _context.Course.FromSqlRaw($"select * from course").ToListAsync();

            foreach(var course in courses){
                int x = (await _context.Student.FromSqlRaw($"select * from student where course_id  = '{course.CourseId}'").ToListAsync()).Count;
                dataPoints3.Add(new DataPoint { X = x, Y = course.Name });
            }

            ViewBag.ChartTitle3 = "Number of students in each Course";
            ViewBag.ChartSubTitle3 = "X = name of course , Y = number of students in the course";
            ViewBag.ChartType3 = "area";
            String j3 = JsonConvert.SerializeObject(dataPoints3);
			ViewBag.DataPoints3 = j3;



			return View("~/Views/CommonChartView/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
