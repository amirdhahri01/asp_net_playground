using DotNetWebDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebDemo.Controllers
{
    public class Menu : Controller
    {
        private readonly MenuContext _context;
        public Menu(MenuContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(){
            return View(await _context.Dishes.ToListAsync());
        }
    }
}