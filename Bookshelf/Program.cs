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
    /// <summary>
    /// Entry point of whole program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Executes when running program.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Makes host builder.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>Host builder interface.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}