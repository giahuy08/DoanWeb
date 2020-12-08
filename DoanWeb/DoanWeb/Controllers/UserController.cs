using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DoanWeb.Models;

namespace DoanWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
       
        DoanWebEntities db = new DoanWebEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User_info account)
        {
            db.User_info.Add(account);
            db.SaveChanges();
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Đăng nhập";

            return View();
        }
        [HttpPost]
        //xử lý đăng nhập
        public ActionResult Login(FormCollection f)
        {

            string taikhoan = f["Username"].ToString();
            string matkhau = f["Pass"].ToString();
            //string matkhaumd5 = GetMD5(matkhau);
            Account us = db.Accounts.SingleOrDefault(n => n.Username == taikhoan && n.Pass == matkhau);
            //nếu user nhập đúng mật khẩu
            if (us != null)
            {
                //if (us.block == false && us.usertype != "1")
                //{
                //    return Content("er_block");
                //}
                //else
                //{
                Session["user"] = us;
                //try
                //{ //lấy thời gian đăng nhập lưu vào hệ thống
                //    us.lastvisitdate = DateTime.Now;
                //    db.SaveChanges();
                //}
                //catch { };

                if (us.User_info.roleAccount == 1)
                {
                    return Content("/Manager/Staff_info/Index");
                }
                if (us.User_info.roleAccount == 2)
                {
                    return Content("/Staff/Products/Index");
                }
                return Content("/Home/Index");
            }
            return Content("false");
        }




                //    }
                //    return Content("false");
                //}
                //[AllowAnonymous]
                //[HttpPost]
                //public ActionResult Login(Account account,string returnUrl)
                //{
                //    var user = db.Accounts.Where(x => x.Username == account.Username && x.Pass == account.Pass).FirstOrDefault();
                //    if (user == null)
                //    {
                //        ModelState.AddModelError("LogOnError", "The user name or password provided is incorrect.");
                //    }
                //    else
                //    {
                //        FormsAuthentication.SetAuthCookie(account.Username,false);

                //        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                //           && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                //        {
                //            return Redirect(returnUrl);
                //        }
                //        else
                //        {

                //            return RedirectToAction("RedirectToDefault");
                //        }
                //    }
                //    return View(account);
                //}
        //        public ActionResult SignOut()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Index", "Home");
        //}
       
    }
}