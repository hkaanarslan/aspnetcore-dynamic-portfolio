using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ResumeContext _context;

        public PortfolioController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Portfolios.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Portfolio portfolio)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Lütfen zorunlu alanları doldurun.";
                return View(portfolio);
            }

            portfolio.Status = true;
            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

       
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _context.Portfolios.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Update(Portfolio portfolio)
        {
          
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Lütfen zorunlu alanları doldurun.";
                return View(portfolio);
            }

            _context.Portfolios.Update(portfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

   
        public IActionResult Delete(int id)
        {
            var value = _context.Portfolios.Find(id);
            value.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
