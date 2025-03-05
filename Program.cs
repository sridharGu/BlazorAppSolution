using BlazorAppProj.Data;
using BlazorAppProj.Model;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using BlazorAppProj;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();


builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages();
builder.Services.AddDbContextFactory<TestingCrudContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestingCrudContext") ?? throw new InvalidOperationException("Connection string 'BlazorAppProjContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//var conString = builder.Configuration.GetConnectionString("TestingCrudContext") ??
//     throw new InvalidOperationException("Connection string 'TestingCrudContext'" +
//    " not found.");
//builder.Services.AddDbContext<TestingCrudContext>(options =>
//    options.UseSqlServer(conString));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAntiforgery();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

//app.MapRazorComponents<App>();

app.Run();
