using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider authProvider;

        public AccountController(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(loginViewModel.UserName,loginViewModel.PassWord))
                {
                    return Redirect(returnUrl?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("","incorrect username or password");
                   return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}