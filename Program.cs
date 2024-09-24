using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Json; 
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using TLCAREERSCORE.Services;
using TLgopetz.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Xtate.Service;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddTransient<IPosition, PositionRepository>();
builder.Services.AddTransient<IClassified, ClassifiedRepository>();
builder.Services.AddTransient<IApplication, ApplicationRepository>();
builder.Services.AddTransient<IUnsubscribe, Unsubscriberrepo>();
builder.Services.AddHttpClient();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/Denied";
                });

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseDefaultFiles();

app.UseStaticFiles(); 


app.UseRouting(); 

app.UseAuthentication();

app.UseAuthorization(); 

app.MapControllers(); 

app.MapRazorPages(); 

app.Run();
