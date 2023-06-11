using DepremProje.Models;
using DepremProje.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionsql")));
builder.Services.AddScoped<KategoriRepository, KategoriRepository>();
builder.Services.AddScoped<MalzemeRepository, MalzemeRepository>();
builder.Services.AddScoped<TalepRepository, TalepRepository>();
builder.Services.AddScoped<AracRepository, AracRepository>();
builder.Services.AddAuthentication(
	CookieAuthenticationDefaults.AuthenticationScheme).
	AddCookie(x =>
	{
		x.LoginPath = "/Login/Index";
	});

var app = builder.Build();
app.UseAuthentication();
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
    pattern: "{controller=Kategori}/{action=Index}/{id?}");

app.Run();
