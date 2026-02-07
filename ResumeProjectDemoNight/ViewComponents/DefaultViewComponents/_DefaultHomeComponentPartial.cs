using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Models;

public class _DefaultHomeComponentPartial : ViewComponent
{
    private readonly ResumeContext _context;

    public _DefaultHomeComponentPartial(ResumeContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        HomeViewModel model = new HomeViewModel
        {
            About = _context.Abouts.FirstOrDefault(),
            SocialMedias = _context.SocialMedias.ToList()
        };

        return View(model);
    }
}