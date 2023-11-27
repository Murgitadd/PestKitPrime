using Microsoft.EntityFrameworkCore;
using PestKitPrime.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>((options) => { options.UseSqlServer(builder.Configuration.GetConnectionString("Default")); });
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    "Default",
    "{controller=home}/{action=index}/{id?}");

app.Run();

