using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TaskProject.Bussiness;
using TaskProject.Bussiness.Models;
using TaskProject.Web.Models;
using TaskProject.Web.ViewModel;

namespace TaskProject.Web.Controllers
{
    public class LoginController : Controller
    {
        MerbershipService ms = new MerbershipService();
        RoleService rs = new RoleService();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            //RegisterModel registerModel = new RegisterModel();

            var data = ms.GetRoles();
            List<SelectListItem> ddls = new List<SelectListItem>();
            foreach (var item in data)
            {
                ddls.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            RegisterModel registerModel = new RegisterModel()
            {
                RolesDb = ddls,
            };
            //ViewData["ListItems"] = ddls;
            return View(registerModel);
        }
        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            TaskProoject.DataAccess.Models.Membership membership = new TaskProoject.DataAccess.Models.Membership();
            membership.FirstName = registerModel.FirstName;
            membership.LastName = registerModel.LastName;
            membership.UserName = registerModel.UserName;
            membership.Password = registerModel.Password;
            membership.Phone = registerModel.Phone;
            membership.Email= registerModel.Email;
            membership.IsActive = true;
            membership.CreatedDate = DateTime.Now;
            string data = rs.RegisterUser(membership);
            if(data == "Data Created")
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag["Register"] = data;
                return View();
            }
        }
        [HttpPost]
        public ActionResult Index(MembershipModel tbllogin, string returnUrl)
        {

            var data = ms.Login(tbllogin.UserName, tbllogin.Password);
            if (data.LoginMessage == "No User Found")
            {
                ModelState.AddModelError("", "Invalid user/pass");
                return View();
            }
            else if (data.LoginMessage == "User Inactive")
            {
                ModelState.AddModelError("", "Inactive user");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(data.UserName, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Dashboard", "Home");
                }
            }
        }

    }
}