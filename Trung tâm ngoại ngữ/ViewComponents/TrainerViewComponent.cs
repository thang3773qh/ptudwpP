using LinguaCenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCenter.ViewComponents
{
    public class TrainerViewComponent : ViewComponent
    {
        private readonly LinguaCenterContext _context;

        public TrainerViewComponent(LinguaCenterContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbTrainers.Where(m => (bool)m.IsActive).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
