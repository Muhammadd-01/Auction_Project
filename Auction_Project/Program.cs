﻿using Auction_Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Configure database connection
builder.Services.AddDbContext<AuctionClass>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Myconnection")));

// ✅ Add MVC support
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🔹 Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AuctionClass>();
    dbContext.Database.EnsureCreated(); // ✅ This ensures the database is created
}

// ✅ Enable Static Files (Must be before UseRouting)
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=User}/{action=Index}/{id?}");
});

app.Run();
