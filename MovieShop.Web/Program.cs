using Microsoft.EntityFrameworkCore;
using MovieShop.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// 1) Register the DbContext with your connection string
builder.Services.AddDbContext<MovieShopDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MovieShopDbConnection")));

// 2) Add MVC services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// In development, show detailed error pages
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

// 3) Map default route: /Home/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();