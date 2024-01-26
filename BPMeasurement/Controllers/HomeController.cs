using BPMeasurement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BPMeasurement.Controllers
{
    public class HomeController : Controller
    {
      
        private BPContext context { get; set; }

        public HomeController(BPContext ctx) =>
            context = ctx;

        public IActionResult Index()
        {
           
            var measurements = context.BPMeasurements.Include(m => m.Position)
                .OrderBy(m => m.BPId).ToList();
            return View(measurements);
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