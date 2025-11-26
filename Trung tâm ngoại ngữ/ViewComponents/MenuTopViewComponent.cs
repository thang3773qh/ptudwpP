using Microsoft.AspNetCore.Mvc;
using LinguaCenter.Models;

namespace LinguaCenter.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly LinguaCenterContext _context;

        public MenuTopViewComponent(LinguaCenterContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbMenus.Where(m => (bool)m.IsActive).
                OrderBy(m => m.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
