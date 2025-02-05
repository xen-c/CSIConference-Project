using CSIConference.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// **** Configure services ****
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IConferenceRepository, ConferenceRepository>();

//Database: SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

var app = builder.Build();

// **** Configure middleware ****
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapGet("/", () => "Hello World!");
SeedData.EnsurePopulated(app);

app.Run();
