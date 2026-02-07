using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

public class _DefaultAboutComponentPartial : ViewComponent
{
    private readonly ResumeContext _context;

    public _DefaultAboutComponentPartial(ResumeContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var about = _context.Abouts.FirstOrDefault();
        var skills = _context.Skills.ToList();
        var statistics = _context.Statistics.ToList();

        ViewBag.Skills = skills;
        ViewBag.Statistics = statistics;

        return View(about);
    }

}
