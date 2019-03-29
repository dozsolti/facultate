using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Views.Shared
{
    public class UserController : Controller
    {
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = WebApplication1.Shared.DB.Login(model.Username, model.Password);
                if (user != null)
                {
                    WebApplication1.Shared.DB.LogIn(user);
                    return RedirectToAction("Dashboard");
                }
            }
            ViewData["message"] = "Username or password is incorrect. Please try again.";
            return View();
        }
        public ActionResult Logout()
        {
            WebApplication1.Shared.DB.Logout();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Dashboard()
        {
            if(WebApplication1.Shared.DB.isLogined==false)
                return RedirectToAction("Index","Home");

            return View();
        }
    }
}
