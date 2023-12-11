using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PestKitPrime.DAL;
using PestKitPrime.Models;
using PestKitPrime.ViewModels.Basket;

namespace PestKitPrime.Services
{
    public class LayoutService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _context;
        private HttpRequest _request;

        public LayoutService(IHttpContextAccessor contextAccessor, AppDbContext context)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _request = _contextAccessor.HttpContext.Request;
        }

        public async Task<List<BasketItemVM>> GetBasketItemsAsync()
        {
            List<BasketItemVM> biList;

            if (_request.Cookies["basket"] is not null)
            {
                List<BasketCookieItemVM> bciList = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(_request.Cookies["basket"]);

                biList = new();

                foreach (BasketCookieItemVM basketCookieItem in bciList)
                {
                    Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketCookieItem.Id);

                    if (product is not null)
                    {
                        BasketItemVM basketItem = new()
                        {
                            Id = basketCookieItem.Id,
                            Count = basketCookieItem.Count,
                            Name = product.Name,
                            Price = product.Price,
                            SubTotal = product.Price * basketCookieItem.Count
                        };

                        biList.Add(basketItem);
                    }

                }
            }
            else
            {
                biList = new();
            }

            return biList;
        }

        public async Task<List<BasketItemVM>> GetBasketItemsAsync(List<BasketCookieItemVM> bciList)
        {
            List<BasketItemVM> biList;

            biList = new();

            foreach (BasketCookieItemVM basketCookieItem in bciList)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketCookieItem.Id);

                if (product is not null)
                {
                    BasketItemVM basketItem = new()
                    {
                        Id = basketCookieItem.Id,
                        Count = basketCookieItem.Count,
                        Name = product.Name,
                        Price = product.Price,
                        SubTotal = product.Price * basketCookieItem.Count
                    };

                    biList.Add(basketItem);
                }

            }


            return biList;
        }
    }
}
