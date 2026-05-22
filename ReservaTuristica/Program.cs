using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReservaTuristica.Application.Interfaces;
using ReservaTuristica.Infrastructure.Data;
using ReservaTuristica.Infrastructure.Servicies;
using ReservaTuristica.Web.Data;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

// DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration
            .GetConnectionString(
                "DefaultConnection")));

// IDENTITY
builder.Services
    .AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<AppDbContext>();

// SERVICES
builder.Services.AddScoped<
    IDisponibilidadService,
    DisponibilidadService>();

builder.Services.AddTransient<
    IEmailSender, EmailSender>();

builder.Services.AddScoped<
    ITarifaService,
    TarifaService>();

builder.Services.AddScoped<
    IReservaService,
    ReservaService>();

var app = builder.Build();

// PIPELINE
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

// IMPORTANTE
app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern:
        "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// SEED
using (var scope = app.Services.CreateScope())
{
    var context =
        scope.ServiceProvider
            .GetRequiredService<AppDbContext>();

    await SeedData.Initialize(context);
}

app.Run();