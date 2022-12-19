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
    public class HomeController : Controller
    {
        ConnectProduct cnp = new ConnectProduct();
        //
        // GET: /Home/

        public ActionResult Home()
        {
            var listProduct = cnp.get8Product();
            if (listProduct.Count == 0)
            {
                TempData["MessageError"] = "Kho hàng không có sản phẩm nào cả!";
            }
            return View(listProduct);
        }

        public ActionResult Details(int id)
        {
            var listProduct = cnp.getProductByID(id).FirstOrDefault();
            if (listProduct == null)
            {
                TempData["MessageError"] = "Không tồn tại sản phẩm này!";
                return RedirectToAction("HomeOfEmp", "HomeOfEmp");
            }
            return View(listProduct);
        }

        [HttpPost]
        public ActionResult Details(int id, Product p, FormCollection f)
        {
            Session["ms"] = id;
            Session["strURL"] = Request.Url.ToString();
            Session["size"] = p.KichThuoc;
            var ms = Session["ms"];
            var strURL = Session["strURL"];
            var size = Session["size"];
            var sl = int.Parse(f["txtSoLuong"].ToString());
            return RedirectToAction("ThemGioHang", "Cart", new { ms = ms, strURL = strURL, size = size, sl = sl });
        }

        public ActionResult Search(string txtSearch)
        {
            var listProducts = cnp.search(txtSearch);
            return View(listProducts);
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Shop()
        {
            var listProduct = cnp.getAllProduct();
            if (listProduct.Count == 0)
            {
                TempData["MessageError"] = "Kho hàng không có sản phẩm nào cả!";
            }
            return View(listProduct);
        }

        public ActionResult SaleOff()
        {
            return View();
        }

        public ActionResult Collection()
        {
            return View();
        }

        public ActionResult Outfits()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult CustomerCare()
        {
            return View();
        }
        public ActionResult Recruit()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
