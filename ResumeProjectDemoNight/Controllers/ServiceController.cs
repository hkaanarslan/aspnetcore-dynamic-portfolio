using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ResumeContext _context;

        public ServiceController(ResumeContext context)
        {
            _context = context;
        }

        // LIST
        public IActionResult Index()
        {
            var values = _context.Services.ToList();
            return View(values);
        }

       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Lütfen zorunlu alanları doldurun.";
                return View(service);
            }

            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _context.Services.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Update(Service service)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Lütfen zorunlu alanları doldurun.";
                return View(service);
            }

            _context.Services.Update(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
