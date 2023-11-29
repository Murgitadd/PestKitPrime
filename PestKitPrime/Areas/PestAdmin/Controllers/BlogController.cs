using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PestKitPrime.Areas.PestAdmin.ViewModels;
using PestKitPrime.DAL;
using PestKitPrime.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PestKitPrime.Areas.PestAdmin.Controllers
{
    [Area("PestAdmin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _context.Blogs.ToListAsync();
            return View(blogs);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = await _context.Authors.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            try
            {
                _context.Blogs.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(blog);
            }
        }
    }
}
