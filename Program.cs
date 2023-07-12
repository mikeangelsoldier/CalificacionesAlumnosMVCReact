using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CalificacionesAlumnosMVCReact.Data;
using CalificacionesAlumnosMVCReact.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CalificacionesAlumnosContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CalificacionesAlumnosContext") ?? throw new InvalidOperationException("Connection string 'CalificacionesAlumnosContext' not found.")));

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddControllers().AddNewtonsoftJson(x => 
 x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);    
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
