using LinguaCenter.Models;
using LinguaCenter.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace LinguaCenter.Controllers
{
    public class PaymentController : Controller
    {
        private readonly LinguaCenterContext _context;
        private readonly IVnPayService _vnPayservice;

        public PaymentController(LinguaCenterContext context, IVnPayService vnPayservice)
        {
            _context = context;
            _vnPayservice = vnPayservice;
        }

        public IActionResult Index(int courseId)
        {
            var course = _context.TbCourses.FirstOrDefault(x => x.CourseId == courseId);
            return View(course);
        }

        public IActionResult PaymentFail() { return View(); }
        public IActionResult PaymentSuccess() { return View(); }

        public async Task<IActionResult> PaymentCallBack()
        {
            var response = _vnPayservice.PaymentExecute(Request.Query);
            if (response == null || response.VnPayResponseCode != "00")
            {
                TempData["Message"] = $"{response?.VnPayResponseCode}";
                return RedirectToAction("PaymentFail");
            }

            // tách dữ liệu từ description
            var input = response.OrderDescription;
            var data = input
                .Split('|')
                .Select(x => x.Split('='))
                .ToDictionary(x => x[0], x => x[1]);

            TbOrder order = new TbOrder
            {
                CustomerName = data["name"],
                Phone = data["phone"],
                Email = data["email"],
                CourseId = int.Parse(data["course"]),
                CreateDate = DateTime.Now,
                Price = decimal.Parse(data["price"])
            };

            _context.Add(order);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Thanh toán thành công";
            return RedirectToAction("PaymentSuccess");
        }


        [HttpPost]
        public IActionResult Checkout(Checkout model)
        {
            var vnPayModel = new VnPaymentRequestModel
            {
                Amount = model.Amount,
                CreatedDate = DateTime.Now,
                Description = $"course={model.Course}|name={model.Name}|email={model.Email}|phone={model.Phone}|price={model.Amount}",
                FullName = model.Name,
                OrderId = new Random().Next(1000, 100000)
            };
            return Redirect(_vnPayservice.CreatePaymentUrl(HttpContext, vnPayModel));
        }
    }
}
