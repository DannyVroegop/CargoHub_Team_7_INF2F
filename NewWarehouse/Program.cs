using Microsoft.EntityFrameworkCore;
using Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
bool LoadData = false;

// Add services to the container.
builder.Services.AddControllersWithViews();

//filter
// builder.Services.AddOptions();
//builder.Services.Configure<ApiOption>(builder.Configuration.GetSection("ApiOptions"));

// Register DbContext with the correct configuration access
builder.Services.AddDbContext<CargoContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WarehousingContext")));

//builder.Services.AddTransient<DataLoader.DataLoader>();
// Configure URL for the application (this is where we set the port and host)
builder.WebHost.UseUrls("http://127.0.0.1:3000");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Use(async (context, next) =>{
            var ApiTokens = builder.Configuration["API_KEY"];
            Console.WriteLine(builder.Configuration);
            if (!context.Request.Headers.ContainsKey("API_KEY"))
            {
                context.Response.StatusCode = 401;
                return;
        }
            if (ApiTokens != context.Request.Headers["API_KEY"])
            {
                context.Response.StatusCode = 401;
                return;
            }
            await next();
        });

app.Run();
