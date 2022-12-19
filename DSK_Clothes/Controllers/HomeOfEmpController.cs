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
    public class HomeOfEmpController : Controller
    {
        //
        // GET: /HomeOfEmp/
        ConnectProduct cnp = new ConnectProduct();
        public ActionResult HomeOfEmp()
        {
            var listProduct = cnp.getAllProduct();
            if (listProduct.Count == 0)
            {
                TempData["MessageError"] = "Kho hàng không có sản phẩm nào cả!";
            }
            return View(listProduct);
        }


        //--------------------------------- THÊM SẢN PHẨM MỚI
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            bool kt = false;
            try
            {
                if (ModelState.IsValid)
                {
                    kt = cnp.createProduct(p);
                    if (kt)
                    {
                        TempData["MessageSuccess"] = "Thêm sản phẩm thành công!";
                    }
                    else
                    {
                        TempData["MessageError"] = "Thêm sản phẩm thất bại!";
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


        //--------------------------------- CHỈNH SỬA SẢN PHẨM
        public ActionResult Edit(int id)
        {
            var listProduct = cnp.getProductByID(id).FirstOrDefault();
            if (listProduct == null)
            {
                TempData["MessageError"] = "Không tồn tại sản phẩm này!";
                return RedirectToAction("HomeOfEmp", "HomeOfEmp");
            }
            return View(listProduct);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult UpdateProduct(int id, string TenSP, string NuocSX, string ChatLieu, string Hinh, string Gia, int MaLoaiSP)
        {
            bool kt = false;
            try
            {
                if (ModelState.IsValid)
                {
                    kt = cnp.updateProductByID(id, TenSP, NuocSX, ChatLieu, Hinh, Gia, MaLoaiSP);
                    if (kt)
                    {
                        TempData["MessageSuccess"] = "Chỉnh sửa sản phẩm thành công!";
                    }
                    else
                    {
                        TempData["MessageError"] = "Chỉnh sửa sản phẩm thất bại!";
                    }
                }
                return RedirectToAction("Edit", "HomeOfEmp");
            }
            catch (Exception e)
            {
                TempData["MessageError"] = e.Message;
                return View();
            }
        }

        //--------------------------------- XÓA SẢN PHẨM
        public ActionResult Delete(int id)
        {
            bool kt = false;
            try
            {
                kt = cnp.deleteProductByID(id);
                if(kt)
                {
                    TempData["MessageSuccess"] = "Xóa sản phẩm thành công!";
                }
                else
                {
                    TempData["MessageError"] = "Xóa sản phẩm thất bại!";
                }
                return RedirectToAction("HomeOfEmp", "HomeOfEmp");
            }
            catch
            {
                return View();
            }
        }

        //--------------------------------- XEM THÔNG TIN CHI TIẾT SẢN PHẨM 
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

        public ActionResult Search(string txtSearch)
        {
            var listProducts = cnp.search(txtSearch);
            return View(listProducts);
        }
    }
}
