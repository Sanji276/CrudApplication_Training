using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string isLogin,string Username,DateTime logedIntime)
        {
            if(logedIntime < DateTime.Now)
            {
                return RedirectToAction("Index","Authentication",new { sessionExpired = true});
            }
            else
            {
                string newValue = isLogin;
                ViewBag.userName = Username;
                return View();
            }            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
