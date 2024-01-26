using BPMeasurement.Models;
using Microsoft.AspNetCore.Mvc;

namespace BPMeasurement.Controllers
{   
    public class BPController : Controller
    {
        private BPContext context { get; set; }

        public BPController(BPContext ctx)
        {
            context = ctx;
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Positions
               = context.Positions.OrderBy(g => g.Name).ToList();
            return View("Edit", new BloodMeasurement());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Positions
               = context.Positions.OrderBy(g => g.Name).ToList();
            var measurement = context.BPMeasurements.Find(id);
            return View(measurement);
        }

        [HttpPost]
        public IActionResult Edit(BloodMeasurement measurement)
        {
            if (ModelState.IsValid)
            {
                if (measurement.BPId == 0)
                    context.BPMeasurements.Add(measurement);
                else
                    context.BPMeasurements.Update(measurement);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action =
                    (measurement.BPId == 0) ? "Add" : "Edit";
                ViewBag.Positions
               = context.Positions.OrderBy(g => g.Name).ToList();
                return View(measurement);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var measurement = context.BPMeasurements.Find(id);
            return View(measurement);
        }

        [HttpPost]
        public IActionResult Delete(BloodMeasurement measurement)
        {
            context.BPMeasurements.Remove(measurement);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
