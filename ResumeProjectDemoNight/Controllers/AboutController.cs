using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class AboutController : Controller
    {
        private readonly ResumeContext _context;

        public AboutController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var value = _context.Abouts.FirstOrDefault();
            return View(value);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _context.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(About about)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Lütfen zorunlu alanları doldurun.";
                return View(about);
            }

            var value = _context.Abouts.Find(about.AboutId);
            if (value == null)
                return RedirectToAction("Index");

            value.NameSurname = about.NameSurname;
            value.Title = about.Title;
            value.Description = about.Description;
            value.AboutText = about.AboutText;
            value.ImageUrl = about.ImageUrl;
            value.AboutImageUrl = about.AboutImageUrl;
            value.CvUrl = about.CvUrl;

            _context.SaveChanges();

            return RedirectToAction("Update", new { id = value.AboutId });
        }
    }
}
