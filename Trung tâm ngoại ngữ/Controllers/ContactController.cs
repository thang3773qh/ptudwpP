using LinguaCenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCenter.Controllers
{
    public class ContactController : Controller
    {
        private readonly LinguaCenterContext _context;
        public ContactController(LinguaCenterContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, string phone, string email, string message)
        {
            try
            {
                TbContact contact = new TbContact();
                contact.Name = name;
                contact.Phone = phone;
                contact.Email = email;
                contact.Message = message;
                contact.CreatedDate = DateTime.Now;
                _context.Add(contact);
                _context.SaveChangesAsync();
                return Content("OK");
            }
            catch
            {
                return Json(new { status = false });
            }
        }
    }
}
