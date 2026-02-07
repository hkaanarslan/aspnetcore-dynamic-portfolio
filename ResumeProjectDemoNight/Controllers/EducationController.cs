using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class EducationController : Controller
    {
        private readonly ResumeContext _context;

        public EducationController(ResumeContext context)
        {
            _context = context;
        }

        // =============================
        // LIST
        // =============================
        public IActionResult Index()
        {
            var values = _context.Educations.ToList();
            return View(values);
        }

        // =============================
        // CREATE
        // =============================
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Education education)
        {
   
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Lütfen zorunlu alanları doldurun.";
                return View(education);
            }

            _context.Educations.Add(education);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _context.Educations.Find(id);
            if (value == null)
                return NotFound();

            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Education education)
        {
          
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Lütfen zorunlu alanları doldurun.";
                return View(education);
            }

            _context.Educations.Update(education);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

 
        public IActionResult Delete(int id)
        {
            var value = _context.Educations.Find(id);
            if (value == null)
                return NotFound();

            _context.Educations.Remove(value);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
