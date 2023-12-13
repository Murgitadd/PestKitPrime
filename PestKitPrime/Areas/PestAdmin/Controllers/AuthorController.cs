using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PestKitPrime.Areas.PestAdmin.ViewModels;
using PestKitPrime.DAL;
using PestKitPrime.Models;

namespace PestKitPrime.Areas.PestAdmin.Controllers
{
    [Area("PestAdmin")]
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;

        public AuthorController(DAL.AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Author> authors = await _context.Authors.Include(p => p.Blogs).ToListAsync();
            return View(authors);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateAuthorVM authorVM)
        {
            try
            {
                Author author = new Author { Name = authorVM.Name };
                await _context.Authors.AddAsync(author);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) { return BadRequest(); }

            Author author = await _context.Authors.FirstOrDefaultAsync(c => c.Id == id);
            if (author == null) { return NotFound(); }
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) { return BadRequest(); }
            Author author = _context.Authors.Include(c => c.Blogs).FirstOrDefault(c => c.Id == id);
            if (author == null) { return NotFound(); }
            return View(author);
        }


        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0) { return BadRequest(); }
            Author author = await _context.Authors.FirstOrDefaultAsync(c => c.Id == id);
            if (author == null) { return NotFound(); }
            CreateUpdateAuthorVM authorVM = new CreateUpdateAuthorVM
            {
                Name = author.Name
            };
            return View(authorVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, CreateUpdateAuthorVM authorVM)
        {
            if (!ModelState.IsValid) { return View(authorVM); };
            Author exist = await _context.Authors.FirstOrDefaultAsync(c => c.Id == id);
            if (exist == null) { return NotFound(); };
            bool result = await _context.Authors.AnyAsync(c => c.Name.Trim().ToLower() == exist.Name.Trim().ToLower()&& c.Id != id);
            if (result)
            {
                ModelState.AddModelError("Name", "This Category exists.");
                return View(exist);
            }
            exist.Name = authorVM.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
