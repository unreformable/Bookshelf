using Bookshelf.Models;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bookshelf.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Books()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult SearchBook(string title)
        {
            System.Collections.Generic.IList<Volume>? items = GoogleBooksAPI.SearchBooks(title);
            Global.foundBooks = items; 
            return View("Books");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
