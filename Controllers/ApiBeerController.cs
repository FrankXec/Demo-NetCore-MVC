using DemoMVC.Models;
using DemoMVC.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBeerController : ControllerBase
    {
        private readonly DemodbContext _context;
        public ApiBeerController(DemodbContext context) {
            _context = context;
        }
        public async Task<List<BrandBeerViewModel>> Get()
            => await _context.Beers.Include(b=>b.Brand)
            .Select(b=>new BrandBeerViewModel { 
                Name = b.Name,
                Brand = b.Brand.Name
            })
            .ToListAsync();
        
    }
}