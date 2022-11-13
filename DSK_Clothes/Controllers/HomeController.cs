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
            var listProduct = cnp.getAllProduct();
            if (listProduct.Count == 0)
            {
                TempData["MessageError"] = "Kho hàng không có sản phẩm nào cả!";
            }
            return View(listProduct);
        }

        public ActionResult Details(int id)
        {
            var listProduct = cnp.getProductByID(id);
            if (listProduct.Count == 0)
            {
                TempData["MessageError"] = "Kho hàng không có sản phẩm nào cả!";
            }
            return View(listProduct);
        }


        public ActionResult Error()
        {
            return View();
        }
    }
}
