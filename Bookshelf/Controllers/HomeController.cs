using Bookshelf.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;

namespace Bookshelf.Controllers
{
    /// <summary>
    /// Controlls user interactions before loggin in.
    /// </summary>
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

        /// <summary>
        /// Called when user wants to log in.
        /// </summary>
        /// <param name="Login">User's login.</param>
        /// <param name="Password">User's password.</param>
        /// <returns>Action.</returns>
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

        /// <summary>
        /// Called when user wants to register.
        /// </summary>
        /// <param name="user">User object.</param>
        /// <returns>Action.</returns>
        public IActionResult TryRegister(User user) // TODO: Input name, surname, login, password, email instead of user object.
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
