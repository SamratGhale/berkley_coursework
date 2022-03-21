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
    public class StudentResultChartController:Controller
    {
        private readonly ModelContext _context;

        public StudentResultChartController(ModelContext context)
        {
            _context = context;
        }
		public async Task<ActionResult> IndexAsync()
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
 
			return View("~/Views/CommonChartView/Index.cshtml");
		}
    }
}
