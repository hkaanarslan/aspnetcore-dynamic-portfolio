using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class SkillController : Controller
    {
        private readonly ResumeContext _context;

        public SkillController(ResumeContext context)
        {
            _context = context;
        }

   
        public IActionResult Index()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }

  
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _context.Skills.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Update(Skill skill)
        {
            var value = _context.Skills.Find(skill.SkillId);

            value.SkillName = skill.SkillName;
            value.Value = skill.Value;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

      
        public IActionResult Delete(int id)
        {
            var value = _context.Skills.Find(id);
            _context.Skills.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
