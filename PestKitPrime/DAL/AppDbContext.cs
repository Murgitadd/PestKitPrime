using Microsoft.EntityFrameworkCore;

namespace PestKitPrime.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
