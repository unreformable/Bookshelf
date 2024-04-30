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
        public static void TestGoogleBooksApi()
        {
            string apiKey = "AIzaSyCrOKlzeWwLvVhCuxr7ldmaHUxNaypsoyI";

            try
            {
                // Create the service
                var service = new BooksService(new BaseClientService.Initializer
                {
                    ApiKey = apiKey,
                    ApplicationName = "Bookshelf"
                });

                // Call the API to search for books
                var listRequest = service.Volumes.List("flowers");
                listRequest.MaxResults = 5; // Limit to 5 results
                var response = listRequest.Execute();

                // Process the response
                if (response != null && response.Items != null)
                {
                    foreach (var item in response.Items)
                    {
                        Console.WriteLine("Title: " + item.VolumeInfo.Title);
                        Console.Write("Authors: ");
                        if (item.VolumeInfo.Authors != null)
                        {
                            Console.Write(string.Join(", ", item.VolumeInfo.Authors));
                        }
                        Console.WriteLine();
                        Console.WriteLine("Publisher: " + item.VolumeInfo.Publisher);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No results found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Console.ReadLine();
        }

        public static void Main(string[] args)
        {
            TestGoogleBooksApi();

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