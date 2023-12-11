using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PestKitPrime.DAL;
using PestKitPrime.Migrations;
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
            List<Blog> blog = _context.Blogs.Include(p => p.Author).ToList();
            List<Employee> employees = _context.Employees.ToList();
            List<Product> products = _context.Products.ToList();
            HomeVM homeVM = new HomeVM { Blogs = blog, Employees = employees ,Products=products};
            return View(homeVM);
        }
    }
}
