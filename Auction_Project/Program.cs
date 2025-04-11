using Auction_Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Database connection
builder.Services.AddDbContext<AuctionClass>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Myconnection")));

// ✅ MVC & Session
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache(); // 🔥 Required for session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60); // Session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// 🔹 Ensure database exists (optional but handy)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AuctionClass>();
    dbContext.Database.EnsureCreated(); // Auto-create DB if it doesn't exist
}

// ✅ Middleware (ORDER MATTERS)
app.UseStaticFiles();     // For wwwroot
app.UseRouting();

app.UseSession();         // 🔥 Enable session BEFORE endpoints

app.UseAuthorization();   // If using [Authorize] anywhere

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}"); // Default route

app.Run();
