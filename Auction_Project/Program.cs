var builder = WebApplication.CreateBuilder(args);

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
        pattern: "{controller=Admin}/{action=Dashboard}/{id?}");
});

app.Run();
