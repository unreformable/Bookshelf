using Bookshelf.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;

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
        public IActionResult TryLogin(string Login, string Password)
        {
            using (var db = new Bookshelfcontext())
            {
                List<User> users = db.Users.Where(u => u.Login.Contains(Login) && u.Password.Contains(Password)).ToList();

                if(!users.Any()) // user exists so we can login
                {
                    return View("Login");
                }

                Global.loggedIn = true;
                Global.loggedUser = db.Users.Where(u => u.Login.Contains(Login) && u.Password.Contains(Password)).First();
                return View("Index");
            }
        }
        //Dodaje u¿ytkownika do bazy danych i zwraca ekran udanej rejestracji.
        public IActionResult TryRegister(User user)
        {
            using (var db = new Bookshelfcontext())
            {
                if(String.IsNullOrEmpty(user.Name)
                || String.IsNullOrEmpty(user.Surname)
                || String.IsNullOrEmpty(user.Login)
                || String.IsNullOrEmpty(user.Password)
                || String.IsNullOrEmpty(user.Email))
                {
                    return View("UnsuccessfullRegister");
                }

                List<User> users = db.Users.Where(u => u.Login.Contains(user.Login) && u.Password.Contains(user.Password)).ToList();
                if(users.Any()) // user already exists so we cannot register
                {
                    return View("UnsuccessfullRegister");
                }

                db.Add(user);
                db.SaveChanges();
                return View("SuccessfullRegister");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
