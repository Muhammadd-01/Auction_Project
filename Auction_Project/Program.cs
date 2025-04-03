using Auction_Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AuctionClass>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Myconnection")));
// ✅ Add MVC support
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ✅ Enable Static Files (Must be before UseRouting)
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // ✅ Default Route for Admin Panel
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Admin}/{action=Index}/{id?}");
});

app.Run();
