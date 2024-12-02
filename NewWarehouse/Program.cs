// Testing Github Actions
using Microsoft.EntityFrameworkCore;
using Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

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
// Configure URL for the application (this is where we set the port and host).
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
            var HTTPMethod = context.Request.Method;
            var URL = context.Request.Path;

            string location = URL.ToString().Split('/')[3];

            string json = File.ReadAllText("ApiKeyInfo.json");
            
            
            if (!context.Request.Headers.ContainsKey("API_KEY"))
            {
                context.Response.StatusCode = 401;
                return;
            }

            if (!IsAccessAllowed(json, context.Request.Headers["API_KEY"], location, HTTPMethod))
            {
                context.Response.StatusCode = 401;
                return;
            }

            Console.WriteLine("API key accepted");
            await next();
        });

static bool IsAccessAllowed(string json, string apiKey, string path, string HTTPMethod)
{
    var root = JsonNode.Parse(json);
    var ApiAccess = root?[apiKey]?["endpoint_accessUser"];

    if (ApiAccess == null)
    {
        Console.WriteLine("Invalid API Key or configuration");
        return false;
    }

    if(ApiAccess["full"]?.GetValue<bool>() == true)
    {
        //full access
        return true;
    }

    var permissionTable = ApiAccess as JsonObject;
    if (permissionTable != null && permissionTable.ContainsKey(path))
    {
        var pathPermissions = permissionTable[path] as JsonObject;
        if (pathPermissions != null)
        {
            if (pathPermissions["full"]?.GetValue<bool>() == true)
            {
                return true;
            }
            return pathPermissions[HTTPMethod.ToString().ToLower()]?.GetValue<bool>() == true;
        }
        return false;
    }
    return false;
}

app.Run();
