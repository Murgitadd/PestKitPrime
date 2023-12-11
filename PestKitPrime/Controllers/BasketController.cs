using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PestKitPrime.DAL;
using PestKitPrime.Models;
using PestKitPrime.Services;
using PestKitPrime.ViewModels.Basket;

namespace PestKitPrime.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;

        public BasketController(AppDbContext context, LayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }

        public async Task<IActionResult> Index()
        {
            List<BasketItemVM> basketVM = new List<BasketItemVM>();

            if (Request.Cookies["Basket"] is not null)
            {
                List<BasketCookieItemVM> basket = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(Request.Cookies["Basket"]);

                foreach (var basketCookieItem in basket)
                {
                    List<Product> products = await _context.Products.Include(p => p.Id == basketCookieItem.Id).ToListAsync();
                    if (products is not null)
                    {
                        foreach (var product in products)
                        {
                            BasketItemVM basketItemVM = new BasketItemVM
                            {
                                Id = product.Id,
                                Name = product.Name,
                                Price = product.Price,
                                Count = basketCookieItem.Count,
                                SubTotal = product.Price * basketCookieItem.Count
                            };
                        basketVM.Add(basketItemVM);
                        }
                    }
                }
            }


            return View(basketVM);
        }

        public async Task<IActionResult> AddItemAsync(int id)
        {
            if (id <= 0) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) return NotFound();

            List<BasketCookieItemVM> bciList;

            BasketCookieItemVM bci;

            if (Request.Cookies["basket"] is not null)
            {
                bciList = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(Request.Cookies["basket"]);


                bci = bciList.FirstOrDefault(bci => bci.Id == id);

                if (bci is null)
                {
                    bci = new() { Id = id, Count = 1 };

                    bciList.Add(bci);
                }
                else
                {
                    bci.Count++;
                }
            }
            else
            {
                bciList = new()
                {
                    new(){ Id=id, Count=1}
                };
            }

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(bciList));

            List<BasketItemVM> basketItems = await _layoutService.GetBasketItemsAsync(bciList);

            return PartialView("_BasketItemPartial", basketItems);
        }

        public IActionResult RemoveItem(int id)
        {
            List<BasketCookieItemVM> bciList = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(Request.Cookies["basket"]);


            BasketCookieItemVM basketCookieItem = bciList.FirstOrDefault(bci => bci.Id == id);

            if (basketCookieItem is not null)
            {
                bciList = bciList.FindAll(bci => bci.Id != id);
            }

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(bciList));

            return RedirectToAction("Index", "Home");
        }
    }
}
