using CrudApplication.Models.Auth;
using CrudApplication.Repository.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers.Auth
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationRepository _authRepo;

        public AuthenticationController(IAuthenticationRepository authRepo)
        {
            _authRepo = authRepo;
        }
        public IActionResult Index(bool isLogin = false, bool sessionExpired = false)
        {
            ViewBag.sessionExpired = sessionExpired;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _authRepo.UserExist(model.Username!, model.Password!))
                    {
                        return RedirectToAction("Index", "Home", new { isLogin = true, Username = model.Username, logedInTime = DateTime.Now.AddMinutes(20) });
                    }

                }
                else
                {
                    ViewBag.sessionExpired = true;
                    ModelState.AddModelError("Error", "Invalid Credentials");
                    return View(model);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserSignupModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _authRepo.AddUser(model);
                    if (response > 0)
                    {
                        return RedirectToAction("Index", "Authentication", new { UserCreated = true });
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Something went wrong!!");
                        return View();
                    }
                }
                ModelState.AddModelError("Error", "Invalid Input!!");
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> UserList()
        {
            return View(await _authRepo.UserList());
        }

        public async Task<IActionResult> EditUser(int id)
        {
            return View(await _authRepo.GetUserDetailById(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(UserSignupModel model, int id)
        {
            await _authRepo.UpdateUser(model, id);
            return RedirectToAction("UserList", "Authentication");
        }
    }
}

