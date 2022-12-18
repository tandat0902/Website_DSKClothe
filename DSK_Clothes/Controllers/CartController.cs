using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSK_Clothes.Models;
using DSK_Clothes.ConnectionDatabase;

namespace DSK_Clothes.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public List<GioHang> LayGioHang() {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        public ActionResult ThemGioHang(int ms, string strURL, string size, int sl)
        {

            List<GioHang> lstGioHang = LayGioHang();
            GioHang SanPham = lstGioHang.Find(sp => sp.iMaSP == ms);
            if (SanPham == null)
            {
                SanPham = new GioHang(ms);
                SanPham.sKichThuoc = size;
                SanPham.iSoLuong = sl;
                lstGioHang.Add(SanPham);
                return Redirect(strURL);
            }
            else
            {
                SanPham.iSoLuong++;
                return Redirect(strURL);
            }
        }

        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Sum(sp => sp.iSoLuong);
            }
            return tsl;

        }

        private double TongThanhTien() {
            double ttt = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                ttt += lstGioHang.Sum(sp => sp.dThanhTien);
            }
            return ttt;
        }

        public ActionResult GioHang()
        {
            List<GioHang> lstGioHang = LayGioHang();
            if (lstGioHang.Count == 0)
            {
                ViewBag.EmptyCart = "Giỏ hàng rỗng";
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View(lstGioHang);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View();
        }

        public ActionResult XoaGioHang(int maSP) 
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Single(s => s.iMaSP == maSP);
            if (sp != null)
            {
                lstGioHang.RemoveAll(s => s.iMaSP == maSP);
            }

            if (lstGioHang.Count == 0)
            {
                ViewBag.EmptyCart = "Giỏ hàng rỗng";
            }
            return RedirectToAction("GioHang", "Cart");
        }

        public ActionResult XoaGioHang_All()
        {
            List<GioHang> lstGioHang = LayGioHang();
            lstGioHang.Clear();
            return RedirectToAction("GioHang", "Cart");
        }

    [HttpPost]
        public ActionResult CapNhatGioHang(int maSP, FormCollection f){
            var lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Single(s => s.iMaSP == maSP);
            if (sp != null)
	        {
		        sp.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
	        }
            return RedirectToAction("GioHang", "Cart");
        }

	}
}