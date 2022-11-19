using JPFigure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using JPFigure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration(builder =>
{
	builder.AddJsonFile("appsettings.local.json", true, true);
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var config = builder.Configuration;
var connectionString = config.GetConnectionString("JPFigure");

builder.Services.AddDbContext<JPFigureContext>(
	optionsBuilder => optionsBuilder.UseNpgsql(connectionString)
);

builder.Services.AddDbContext<IdentityContext>(
	optionsBuilder => optionsBuilder.UseNpgsql(connectionString)
);

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddScoped<FigureRepository>();
builder.Services.AddScoped<CharacterRepository>();
builder.Services.AddScoped<SeriesRepository>();
builder.Services.AddScoped<ManufactureRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseAuthentication();
app.UseAuthorization();

app.Run();
