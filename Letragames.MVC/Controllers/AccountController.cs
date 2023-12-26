using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Letragames.MVC.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Letragames.MVC.Models;
using Microsoft.Owin.Security;

namespace Letragames.MVC.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;


        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());

            UserManager = new UserManager<ApplicationUser>(userStore);


            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());

            RoleManager = new RoleManager<ApplicationRole>(roleStore);

        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //Register

                var user = new ApplicationUser();

                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Email;

                var result = UserManager.Create(user,model.Password);

             

                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("User"))
                    {
                        UserManager.AddToRole(user.Id, "User");
                    }

                    return RedirectToAction("Login", "Account");

                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası.");
                }

            }
            return View(model);


        }


        // GET: Account
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
                //Login
               var user = UserManager?.Find(model.Email, model.Password);
                
                 if(user == null)
                  {
                    ModelState.AddModelError("LoginUserError", "Kullanıcı bulunamadı.");
                    return View(model);
                  }


            var identityClaims = UserManager?.CreateIdentity(user, "ApplicationCookie");

            if(HttpContext?.GetOwinContext()?.Authentication != null && identityClaims != null)
            {
                HttpContext.GetOwinContext().Authentication.SignIn(

                    new AuthenticationProperties
                    {
                        IsPersistent = true
                    },
                        identityClaims
                    );
            }

            return Redirect(ReturnUrl ?? Url.Action("Index", "Home"));
    

        }


        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");


        }


    }
}