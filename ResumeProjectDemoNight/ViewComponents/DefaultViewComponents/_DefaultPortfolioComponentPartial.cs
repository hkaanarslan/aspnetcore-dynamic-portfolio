using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using System.Linq;

namespace ResumeProjectDemoNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultPortfolioComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultPortfolioComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Portfolios.ToList();
            return View(values);
        }
    }
}
