using LinguaCenter.Models;
using LinguaCenter.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Register")]
    public class RegisterController : Controller
    {

        private readonly LinguaCenterContext _context;
        public RegisterController(LinguaCenterContext context)
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
            try
            {
                if (account == null) { return NotFound(); }

                var check = _context.TbAccounts.Where(m => m.Username == account.Username).FirstOrDefault();
                if (check != null)
                {
                    Function._Message = "Trùng tài khoản";
                    return RedirectToAction("Index", "Register", new { area = "Admin" });
                }

                Function._Message = string.Empty;
                account.Password = HashMD5.GetMD5(account.Password != null ? account.Password : "");
                _context.Add(account);
                _context.SaveChanges();

                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return RedirectToAction("Index", "Login"); }

        }
    }
}
