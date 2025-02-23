using System.Diagnostics;
using GarbageManager.Models;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace GarbageManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GarbageDbContext _context;

        public HomeController(ILogger<HomeController> logger, GarbageDbContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult CreateEditGarbage(int? id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("TotalGarbage");
            }
            if (id != null)
            {
                var garbageInDb = _context.Garbages.SingleOrDefault(x => x.Id == id);
                return View(garbageInDb);
            }
            return View();
        }
        public IActionResult DeleteGarbage(int id)
        {
            var garbageInDb=_context.Garbages.SingleOrDefault(x=> x.Id == id);
            _context.Garbages.Remove(garbageInDb);
            _context.SaveChanges();
            return RedirectToAction("TotalGarbage");
        }
        public IActionResult TotalGarbage()
        {
            var allWaste = _context.Garbages.ToList();
            var totalPrice = allWaste.Sum(x => x.TotalPrice);

            ViewBag.garbagePrice = totalPrice;
            return View(allWaste);
        }

        public IActionResult GarbageInfoSubmit(Garbage model)
        {
            if (model.Type =="Paper")
            {
                model.TotalPrice = 8 * model.Quantity;
            }
            if (model.Type == "E-waste")
            {
                model.TotalPrice = 6 * model.Quantity;
            }
            if (model.Type == "Plastic")
            {
                model.TotalPrice = 2 * model.Quantity;
            }
            if (model.Type == "Metal")
            {
                model.TotalPrice = 10 * model.Quantity;
            }

            if (model.Id == 0)
            {
                _context.Garbages.Add(model);
            }
            else
            {
                _context.Garbages.Update(model);
            }

            if (model.Quantity == 0)
            {
                return RedirectToAction("CreateEditGarbage");
            }
           
            _context.SaveChanges();
            return RedirectToAction("TotalGarbage");
        }

        public IActionResult DownloadPdf()
        {
            var garbageList = _context.Garbages.ToList();

            //ViewBag.garbagePrice = garbageList.Sum(g => g.TotalPrice); 
            return new ViewAsPdf("TotalGarbage", garbageList)
            {
                FileName = "GarbageReport.pdf"
            };
        }
        public IActionResult ClearAll()
        {
            _context.Garbages.RemoveRange(_context.Garbages);
            _context.SaveChanges();
           
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
