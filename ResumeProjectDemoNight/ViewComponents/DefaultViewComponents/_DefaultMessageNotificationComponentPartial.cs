using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using System.Linq;

namespace ResumeProjectDemoNight.ViewComponents.DefaultViewComponents
{
    // Sınıf isminin sonuna "ViewComponent" ekledik. Bu sihirli kelimedir.
    public class _DefaultMessageNotificationComponentPartialViewComponent : ViewComponent
    {
        ResumeContext context = new ResumeContext();

        public IViewComponentResult Invoke()
        {
            var unreadCount = context.Messages
                .Where(x => x.IsRead == false)
                .Count();

            ViewBag.unreadMessageCount = unreadCount;

            // Klasör yolunu tam veriyoruz ki şaşmasın
            return View("~/Views/Shared/Components/_DefaultMessageNotificationComponentPartial/Default.cshtml");
        }
    }
}