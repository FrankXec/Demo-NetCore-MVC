using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Controllers
{
    public class BrandController : Controller
    {
        private readonly DemodbContext _context;

        public BrandController(DemodbContext context) {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var lista = await _context.Brands.ToListAsync();
            return View(lista);
        }
    }
}
