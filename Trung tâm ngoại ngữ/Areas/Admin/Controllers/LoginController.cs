using LinguaCenter.Models;
using LinguaCenter.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Login")]
    public class LoginController : Controller
    {
        private readonly LinguaCenterContext _context;
        public LoginController(LinguaCenterContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TbAccount account)
        {
            if (account == null)
            {
                return NotFound();
            }

            string password = HashMD5.GetMD5(account.Password);
            var check = _context.TbAccounts.Where(m => m.Username == account.Username && m.Password == password)
                .FirstOrDefault();

            if (check == null)
            {
                Function._Message = "Invalid Username or Password";
                return RedirectToAction("Index", "Login");
            }

            Function._Message = string.Empty;
            Function._AccountId = check.AccountId;
            Function._Username = check.Username;
            return RedirectToAction("Index", "Home");
        }
    }
}
