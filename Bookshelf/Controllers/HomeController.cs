using Bookshelf.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        public IActionResult TryLogin(/*LoginViewModel model*/)
        {
            // Authenticate user
            if (true/* authentication successful */)
            {
                // Redirect to specific page
                return RedirectToAction("Index", "Account"); // Redirect to Account/Index
            }
            else
            {
                return RedirectToAction("Login", "Home"); // Refresh login page
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult TryRegister()
        {
            // Try register user
            if (true/* registeration successful */)
            {
                // Redirect to specific page
                return RedirectToAction("SuccessfullRegister", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Register"); // Refresh login page
            }
        }

        public IActionResult SuccessfullRegister(User user)
        {
            using (var db = new Bookshelfcontext())
            {
                user.CreateDate = DateTime.Now;

                db.Add(user);
                db.SaveChanges();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
