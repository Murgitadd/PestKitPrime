using Microsoft.AspNetCore.Mvc;
using PestKitPrime.DAL;

namespace PestKitPrime.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
    }
}
