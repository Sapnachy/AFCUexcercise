using LoginSignupApp.DbContextFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LoginSignupApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        // POST: Login/Login
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            string errorMessage = string.Empty;
            try
            {
                using (UserDbContext objUserDbContext = new UserDbContext())
                {
                    var existinguser = objUserDbContext.Users.ToList().Where(s => s.Email == email && s.Password == password).FirstOrDefault();
                    if (existinguser != null)
                    {
                        FormsAuthentication.SetAuthCookie(email, true);
                        FormsAuthentication.RedirectFromLoginPage(email, true);
                        return Json("Success", "202", JsonRequestBehavior.AllowGet);
                    }    
                    else
                        errorMessage = "Login failed. Please check your user name and password and try again.";
                }
                                
                return Json(errorMessage, "505", JsonRequestBehavior.AllowGet);
                //eturn PartialView("_Login");
            }
            catch
            {
                return View();
            }
        }
        
    }
}
