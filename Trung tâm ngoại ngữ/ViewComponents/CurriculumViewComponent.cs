using LinguaCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harmic.ViewComponents
{
    public class CurriculumViewComponent : ViewComponent
    {
        private readonly LinguaCenterContext _context;

        public CurriculumViewComponent(LinguaCenterContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int courseId)
        {
            var modules = await _context.TbModules
                .Where(m => m.CourseId == courseId)
                .OrderBy(m => m.OrderIndex)
                .ToListAsync();

            var lessons = await _context.TbLessons
                .OrderBy(l => l.OrderIndex)
                .ToListAsync();

            var groupedLessons = lessons
                .GroupBy(l => l.ModuleId)
                .ToDictionary(g => g.Key, g => g.ToList());

            var model = modules.Select(m => new CurriculumViewModel
            {
                ModuleTitle = m.Title,
                LessonsCount = $"{m.TotalLessons} lessons • {m.TotalDuration} hours",
                Lessons = groupedLessons.ContainsKey(m.ModuleId)
                    ? groupedLessons[m.ModuleId].Select(l => new LessonItemViewModel
                    {
                        Title = l.Title,
                        Duration = (int)l.Duration,
                        Type = l.Type
                    }).ToList()
                    : new List<LessonItemViewModel>()
            }).ToList();

            return View(model);
        }
    }

}
