using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ResumeContext _context;

        public DashboardController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("Index", "Login");
            }

     
            ViewBag.ProjectCount = _context.Portfolios.Count();
            ViewBag.ExperienceCount = _context.Experiences.Count();
            ViewBag.EducationCount = _context.Educations.Count();
            ViewBag.MessageCount = _context.Messages.Count();
            ViewBag.LastMessages = _context.Messages
    .OrderByDescending(x => x.SendDate)
    .Take(3)
    .ToList();


            return View();
        }
    }
}
