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
    public class ModuleAttendanceChartController:Controller
    {
        private readonly ModelContext _context;

        public ModuleAttendanceChartController(ModelContext context)
        {
            _context = context;
        }
		public async Task<ActionResult> IndexAsync()
		{
			List<DataPoint> dataPoints = new List<DataPoint>();

            var modules = await _context.Module.FromSqlRaw($"select * from module").ToListAsync();

            foreach(var module in modules){
                int x = (await _context.Attendance.FromSqlRaw($"select * from attendance where module_id = '{module.ModuleId}'").ToListAsync()).Count;
                dataPoints.Add(new DataPoint { X = x, Y = module.Code});
            }

            ViewBag.ChartTitle = "Number of attendance in on each module";
            ViewBag.ChartSubTitle = "";
            ViewBag.ChartType = "pie";
            String j = JsonConvert.SerializeObject(dataPoints);
			ViewBag.DataPoints = j;
 
			return View("~/Views/CommonChartView/Index.cshtml");
		}
    }
}