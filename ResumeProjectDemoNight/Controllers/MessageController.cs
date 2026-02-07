using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;
using System.Linq;

namespace ResumeProjectDemoNight.Controllers
{
    public class MessageController : Controller
    {
        private readonly ResumeContext _context;

        public MessageController(ResumeContext context)
        {
            _context = context;
        }

      
        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            message.SendDate = DateTime.Now;
            message.IsRead = false;

            _context.Messages.Add(message);
            _context.SaveChanges();

            return RedirectToAction("Index", "Default");
        }

        public IActionResult Index()
        {
            var values = _context.Messages
                .OrderByDescending(x => x.SendDate)
                .ToList();

            return View(values); // Views/Message/Index.cshtml
        }

     
        public IActionResult Details(int id)
        {
            var message = _context.Messages.Find(id);

            if (message == null)
            {
                return NotFound();
            }

            // Okundu olarak işaretle
            if (!message.IsRead)
            {
                message.IsRead = true;
                _context.SaveChanges();
            }

            return View(message); // Views/Message/Details.cshtml
        }


        public IActionResult Delete(int id)
        {
            var message = _context.Messages.Find(id);

            if (message != null)
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
