using Microsoft.AspNetCore.Mvc;
using PestKitPrime.DAL;

namespace PestKitPrime.Areas.PestAdmin.Controllers
{
    [Area("PestAdmin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
