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

        /// <summary>
        /// Called when user wants to change page.
        /// </summary>
        /// <param name="selectedBook">Title of a book user wants to change.</param>
        /// <param name="selectedPageNumber">Number of page user wants to change to.</param>
        /// <returns>Action.</returns>
        public IActionResult Change_page(string selectedBook, int selectedPageNumber)
        {
            using (var db = new Bookshelfcontext())
            {
                var user = db.UserBooks.Where(u => u.User_Login == Global.loggedUser.Login && u.Book_title == selectedBook).FirstOrDefault();
                user.PagesRead = selectedPageNumber;
                db.SaveChanges();
            }
            return RedirectToAction("Bookshelf");
        }
        /// <summary>
        /// Called when opening page Bookshelf. Searches for books added by user.
        /// </summary>
        /// <returns>Action.</returns>
        public IActionResult Bookshelf()
        {
            using (var db = new Bookshelfcontext())
            {
                Global.books = db.UserBooks.Where(u => u.User_Login.Contains(Global.loggedUser.Login)).ToList();
            }
            return View();
        }
        /// <summary>
        /// Called when user chooses book he wants to add to his Bookshelf.
        /// </summary>
        /// <param name="index">Index of a book user wants to add.</param>
        /// <returns>Action.</returns>
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
        /// <summary>
        /// Called when user wants to search for books.
        /// </summary>
        /// <param name="title">Title of a book user wants to add.</param>
        /// <returns>Action.</returns>
        public IActionResult SearchBook(string title)
        {
            System.Collections.Generic.IList<Volume>? items = GoogleBooksAPI.SearchBooks(title);
            if (items != null)
            {
                Global.foundBooks = items;
            }
            return View("Books");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
