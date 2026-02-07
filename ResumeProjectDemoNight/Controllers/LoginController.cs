using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace ResumeProjectDemoNight.Controllers
{
    public class LoginController : Controller
    {
        ResumeContext context = new ResumeContext();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ResumeProjectDemoNight.Entities.Admin admin)

        {
            var value = context.Admins
                .FirstOrDefault(x =>
                    x.Username == admin.Username &&
                    x.Password == admin.Password);

            if (value != null)
            {
                HttpContext.Session.SetString("admin", value.Username);
                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
