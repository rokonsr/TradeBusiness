using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using TradeBusiness.Areas.Admin.Models;
using TradeBusiness.BLL;
using TradeBusiness.Models;
using TradeBusiness.DAL;

namespace TradeBusiness.Controllers
{
    public class UserLoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            UserLoginBLL objUserLoginBll = new UserLoginBLL();

            if (ModelState.IsValid)
            {
                var loginInfo = objUserLoginBll.IsValid(userLogin);

                if (loginInfo != null)
                {
                    SessionUtility.TBSessionContainer.UserID = loginInfo.AdminUserId;
                    SessionUtility.TBSessionContainer.UserName = loginInfo.AdminUsername;

                    FormsAuthentication.SetAuthCookie("Cookie", true);

                    return RedirectToAction("Index", "AdminUser", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View();
        }
    }
}