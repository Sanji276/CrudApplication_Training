using CrudApplication.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers.Auth
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserLoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(model.Username == "Admin" && model.Password == "12345")
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("Error","Invalid Credentials");
                    return View(model);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
    }
}
