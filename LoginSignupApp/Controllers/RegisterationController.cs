using LoginSignupApp.DbContextFactory;
using LoginSignupApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LoginSignupApp.Controllers
{
    public class RegisterationController : Controller
    {
        // GET: Registeration
        public ActionResult Index()
        {
            return View();
        }

        // GET: Registeration/Create
        public ActionResult Create()
        {           
            return View();
        }

        // POST: Registeration/Create
        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UserDbContext objUserDbContext = new UserDbContext())
                    {
                        var existinguser = objUserDbContext.Users.ToList().Where(s => s.Email == model.Email).FirstOrDefault();
                        if (existinguser != null)
                        {
                            ViewBag.ErrorMessage = "User already exists!";
                            return View("Create", model);
                        }
                        User _user = new User();
                        _user.Email = model.Email;
                        _user.Password = model.Password;
                        _user.Phone = model.Phone;
                        objUserDbContext.Users.Add(_user);
                        objUserDbContext.SaveChanges();
                        ViewBag.SuccessMessage = "User created successfully!";
                    }
                }
                else
                {
                    return View("Create", model);
                }
                return View("Index", model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.InnerException.ToString();
                return View("Create", model);
            }
        }        
    }
}
