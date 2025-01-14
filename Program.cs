using Proiect_Medii.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// === Configurare Servicii ===

// Configurare baza de date (SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adăugare servicii Razor Pages
builder.Services.AddRazorPages();

// Adăugare servicii de autentificare și autorizare
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.LoginPath = "/Account/Login"; // Redirecționare pentru utilizatori neautentificați
        options.AccessDeniedPath = "/Account/AccessDenied"; // Redirecționare pentru acces interzis
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Expirarea sesiunii după 30 de minute
    });

builder.Services.AddAuthorization(options =>
{
    // Politică pentru rolul Admin
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireRole("Admin"));
});

var app = builder.Build();

// === Configurare Pipeline ===
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Middleware pentru autentificare
app.UseAuthorization();  // Middleware pentru autorizare

// Configurare ruta implicită pentru Dashboard
app.MapGet("/", async context =>
{
    context.Response.Redirect("/Index");
    await Task.CompletedTask;
});

// Mapare pagini Razor
app.MapRazorPages();

app.Run();
