using DemoMVC.Models;
using DemoMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Controllers
{
    public class BeerController : Controller
    {
        private readonly DemodbContext _context;

        public BeerController(DemodbContext context) {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var beerList = await  _context.Beers.Include(b=>b.Brand).ToListAsync();
            return View(beerList);
        }
        public IActionResult Create() {
            ViewData["Brands"] = new SelectList(_context.Brands, "Brandid", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeerViewModel model)
        {
            if (ModelState.IsValid) {
                var beer = new Beer() { 
                    Name = model.Name,
                    Brandid = model.BrandId
                };
                _context.Add(beer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Brands"] = new SelectList(_context.Brands, "Brandid", "Name", model.BrandId);
            return View();
        }

        public IActionResult Update(int id)
        {
            var beer = _context.Beers.Find(id);

            ViewData["Brands"] = new SelectList(_context.Brands, "Brandid", "Name",beer.Brandid);
            ViewData["Beer"] = beer;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BeerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var beer = new Beer()
                {
                    Beerid = (int)model.BeerId,
                    Name = model.Name,
                    Brandid = model.BrandId
                };
                _context.Beers.Entry(beer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Brands"] = new SelectList(_context.Brands, "Brandid", "Name", model.BrandId);
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            var beer = _context.Beers.Find(id);
            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
