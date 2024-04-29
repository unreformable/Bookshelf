using Bookshelf.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing.Printing;

namespace Bookshelf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        //Sprawdza, czy istnieje u¿ytkownik o podanym loginie i haœle, jeœli tak: zwraca stronê g³ówn¹, jeœli nie: zwraca ekran logowania.
        //Do dodania: Potrzebna jakaœ zmienna, która bêdzie trzymaæ dane o zalogowanym u¿ytkowniku przez resztê sesji.
        public IActionResult TryLogin(string Login, string Password)
        {
            List<User> users = new List<User>();

            using(var db = new Bookshelfcontext())
            {
                users = db.Users.Where(u => u.Login.Contains(Login) && u.Password.Contains(Password)).ToList();
            }
            if (users.Any())
            {
                return View("Index");
            }
            else
            {
                return View("Login");
            }
        }
        //Dodaje u¿ytkownika do bazy danych i zwraca ekran udanej rejestracji.
        //Do dodania: Sprawdzanie, czy wszystkie pola s¹ wype³nione
        public IActionResult TryRegister(User user)
        {
            using (var db = new Bookshelfcontext())
            {
                user.CreateDate = DateTime.Now;

                db.Add(user);
                db.SaveChanges();
            }
            return View("SuccessfullRegister");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
