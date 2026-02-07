using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ResumeContext _context;

        public SocialMediaController(ResumeContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(SocialMedia socialMedia)
        {
            var value = _context.SocialMedias
                .Find(socialMedia.SocialMediaId);

            if (value == null)
            {
                return RedirectToAction("Update", "About", new { id = 1 });
            }

            value.Url = socialMedia.Url;
            value.Icon = socialMedia.Icon;

            _context.SaveChanges();

       
            return RedirectToAction("Update", "About", new { id = 1 });
        }
    }
}
