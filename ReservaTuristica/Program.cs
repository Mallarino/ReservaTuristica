using Microsoft.EntityFrameworkCore;
using ReservaTuristica.Application.Interfaces;
using ReservaTuristica.Infrastructure.Data;
using ReservaTuristica.Infrastructure.Servicies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<
    IDisponibilidadService,
    DisponibilidadService>();

builder.Services.AddScoped<
    ITarifaService,
    TarifaService>();

builder.Services.AddScoped<
    IReservaService,
    ReservaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    await SeedData.Initialize(context);
}

app.Run();