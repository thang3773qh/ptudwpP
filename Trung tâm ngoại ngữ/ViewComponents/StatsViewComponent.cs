using LinguaCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinguaCenter.ViewComponents
{
    public class StatsViewComponent : ViewComponent
    {
        private readonly LinguaCenterContext _context;

        public StatsViewComponent(LinguaCenterContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new StatsViewModel
            {
                Students = await _context.TbOrders.CountAsync(),
                Courses = await _context.TbCourses.CountAsync(),
                Events = await _context.TbEvents.CountAsync(),
                Trainers = await _context.TbTrainers.CountAsync()
            };

            return View(model);
        }
    }
}
