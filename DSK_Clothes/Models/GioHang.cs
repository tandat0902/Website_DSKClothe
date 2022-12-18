using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSK_Clothes.Models
{
    public class GioHang
    {
        dbQuanLyBanHangDataContext db = new dbQuanLyBanHangDataContext();
        public int iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public string sKichThuoc { get; set; }
        public int iSoLuong { get; set; }

        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }

        public GioHang(int MaSach) 
        {
            iMaSP = MaSach;
            SANPHAM sp = db.SANPHAMs.Single(s => s.MASP == iMaSP);
            sTenSP = sp.TENSP;
            sAnhBia = sp.HINH;
            dDonGia = double.Parse(sp.GIA.ToString());
            sKichThuoc = "S";
            iSoLuong = 1;
        }
    }
}