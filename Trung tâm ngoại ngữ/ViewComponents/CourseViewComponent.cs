using LinguaCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinguaCenter.ViewComponents
{
    public class CourseViewComponent : ViewComponent
    {
        private readonly LinguaCenterContext _context;
        public CourseViewComponent(LinguaCenterContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var orderCounts = await _context.TbOrders
                .GroupBy(o => o.CourseId)
                .Select(g => new { CourseId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.CourseId, x => x.Count);

            ViewBag.OrderCounts = orderCounts;

            var items = _context.TbCourses.Include(m => m.Category).Include(m => m.Trainer)
                .Where(m => (bool)m.IsActive);
            return await Task.FromResult<IViewComponentResult>
                (View(items.OrderByDescending(m => m.CourseId).ToList()));
        }
    }
}
