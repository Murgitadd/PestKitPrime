using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PestKitPrime.DAL;
using PestKitPrime.Models;

namespace PestKitPrime.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Product> products=await _context.Products.Include(p=>p.Name).ToListAsync();
            return View(products);
        }
    }
}
