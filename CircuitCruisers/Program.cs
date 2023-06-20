using CircuitCruisers.Contexts;
using CircuitCruisers.Helpers.Repositories;
using CircuitCruisers.Helpers.Services;
using CircuitCruisers.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


//Context

builder.Services.AddDbContext<CircuitCruisersDB>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("sql")));


// Identity

builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<CircuitCruisersDB>()
.AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>()
.AddRoles<IdentityRole>();

// Repositories

builder.Services.AddScoped<ProductEntityRepository>();
builder.Services.AddScoped<ContactFormRepository>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserAddressRepository>();


// Services

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<AuthenticationService>();


// Cookies

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";
});


var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
