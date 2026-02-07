using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ResumeContext _context;

        public StatisticController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Statistics.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _context.Statistics.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Update(Statistic statistic)
        {
            var value = _context.Statistics.Find(statistic.StatisticId);

            value.Title = statistic.Title;
            value.Value = statistic.Value;
            value.Icon = statistic.Icon;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
