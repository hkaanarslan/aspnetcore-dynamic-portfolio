using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ResumeContext _context;

        public TestimonialController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Testimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Testimonial testimonial)
        {
          
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Lütfen zorunlu alanları doldurun.";
                return View(testimonial);
            }

            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

     
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _context.Testimonials.Find(id);
            return View(value);
        }

        
        [HttpPost]
        public IActionResult Update(Testimonial testimonial)
        {
           
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Lütfen zorunlu alanları doldurun.";
                return View(testimonial);
            }

            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

       
        public IActionResult Delete(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
