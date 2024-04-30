using Google.Apis.Services;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using static System.Net.WebRequestMethods;
using Bookshelf.Models;
using Google.Apis.Books.v1.Data;
using Google.Apis.Books.v1;
using NuGet.ContentModel;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Bookshelf
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
*/