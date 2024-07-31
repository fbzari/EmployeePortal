using EmployeePortal.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// For Docker: Read connection string from environment variables
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbSaPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbSaPassword};TrustServerCertificate=True;";

// Data Source=ALPHA;Initial Catalog=employeeDB;User ID=adminEmployee;Password=***********;Trust Server Certificate=True
builder.Services.AddDbContext<MVCDemoDbContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment() && Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") != "true")
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Only enable HTTPS redirection if not running in Docker
if (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") != "true")
{
    app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employees}/{action=Index}/{id?}");
app.Run();


