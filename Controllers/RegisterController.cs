using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstApp.Models;
using MyFirstApp.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;



namespace MyFirstApp.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View("Register");
        }

        public ActionResult Register(UserModel userModel)
        {


            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Register(userModel);

            if (success)
            {
                return View("RegisterSuccess");

            }
            else
            {
                return View("Register",userModel);

            }
        }
    }


}