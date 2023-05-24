using Microsoft.EntityFrameworkCore;
using TestOlimpiadas.Contexto;
using TestOlimpiadas.Repositories;
using TestOlimpiadas.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OlimpiadasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<SedeRepository>();
builder.Services.AddScoped<SedeService>();
builder.Services.AddScoped<ComplejoOlimpiadaRepository>();
builder.Services.AddScoped<ComplejoOlimpiadaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "sede",
    pattern: "{controller=Sede}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "complejoOlimpiada",
    pattern: "{controller=ComplejoOlimpiada}/{action=Index}/{id?}"
    );
app.Run();
