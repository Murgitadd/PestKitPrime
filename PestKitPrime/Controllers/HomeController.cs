using Microsoft.AspNetCore.Mvc;
using PestKitPrime.DAL;
using PestKitPrime.Models;
using PestKitPrime.ViewModels;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace PestKitPrime.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Blog> blog = _context.Blogs.ToList();
            List<Employee> employees = _context.Employees.ToList();
            HomeVM homeVM = new HomeVM { Blogs = blog, Employees = employees };
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
