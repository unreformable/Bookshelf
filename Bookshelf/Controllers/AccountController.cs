using Bookshelf.Models;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Diagnostics;

namespace Bookshelf.Controllers
{
    /// <summary>
    /// Controlls user interactions after loggin in.
    /// </summary>
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

        public IActionResult Bookshelf()
        {
            using (var db = new Bookshelfcontext())
            {
                Global.books = db.UserBooks.Where(u => u.User_Login.Contains(Global.loggedUser.Login)).ToList();
            }
            return View();
        }

        public IActionResult choose(int index)
        {
            using (var db = new Bookshelfcontext())
            {
                var item = Global.foundBooks.ElementAtOrDefault(index);
                Book book = new Book();
                UserBook usersbook = new UserBook();
                book.Title = item.VolumeInfo.Title;
                book.Pages = (int)item.VolumeInfo.PageCount;
                book.Author = item.VolumeInfo.Authors.First();
                usersbook.User_Login = Global.loggedUser.Login;
                usersbook.Book_title = item.VolumeInfo.Title;
                db.Add(book);
                db.Add(usersbook);
                db.SaveChanges();
            }
                return View("Books");
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
