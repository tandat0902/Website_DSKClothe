using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using DSK_Clothes.ConnectionDatabase;
using DSK_Clothes.Models;

namespace DSK_Clothes.Controllers
{
    public class SignUpController : Controller
    {
        ConnectUser cnu = new ConnectUser();
        //
        // GET: /SignUp/

        //-------
        //------------------------------------------------ ACTION SIGN UP
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User u)
        {
            bool kt = false;
            try
            {
                if (ModelState.IsValid)
                {
                    kt = cnu.createAccount(u);
                    if (kt)
                    {
                        TempData["MessageSuccess"] = "Đăng ký tài khoản thành công!";
                    }
                    else
                    {
                        TempData["MessageError"] = "Đăng ký tài khoản thất bại! Do số điện thoại " + u.Tel + " đã được đăng ký rồi!";
                    }
                }
                return View();
            }
            catch (Exception e)
            {
                TempData["MessageError"] = e.Message;
                return View();
            }
        }

        //-------
        //------------------------------------------------ ACTION LOG IN
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string Tel, string Password)
        {
            bool kt = false;
            var listUser = cnu.getAllUser();
            try
            {
                if (Tel != string.Empty && Password != string.Empty)
                {
                    kt = cnu.loginAccount(Tel);
                    if (kt)
                    {
                        foreach (var item in listUser)
                        {
                            if (Tel == item.Tel && Password == item.Password)
                            {
                                if (item.MaQuyen == 1)
                                {
                                    return RedirectToAction("Home", "Home");
                                }
                                else
                                {
                                    return RedirectToAction("HomeOfEmp", "HomeOfEmp");
                                }
                            }
                            if (Tel == item.Tel && Password != item.Password)
                            {
                                TempData["MessageError"] = "Mật khẩu sai, vui lòng thử lại!";
                                return View();
                            }
                        }
                    }
                }
                else
                {
                    TempData["MessageError"] = "Vui lòng điền đầy đủ thông tin!";
                }
                return View();
            }
            catch
            {
                TempData["MessageError"] = "Số điện thoại " + Tel + " của bạn chưa được đăng ký trên trang web này!";
                return View();
            }
        }
    }
}
