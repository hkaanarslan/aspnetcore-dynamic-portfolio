using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

public class ExperienceController : Controller
{
    private readonly ResumeContext _context;

    public ExperienceController(ResumeContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Experiences.ToList();
        return View(values);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Experience experience)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Error = "Lütfen zorunlu alanları doldurun.";
            return View(experience);
        }

        _context.Experiences.Add(experience);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var value = _context.Experiences.Find(id);
        return View(value);
    }

    [HttpPost]
    public IActionResult Update(Experience experience)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Error = "Lütfen zorunlu alanları doldurun.";
            return View(experience);
        }

        _context.Experiences.Update(experience);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var value = _context.Experiences.Find(id);
        _context.Experiences.Remove(value);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
