using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSK_Clothes.Models
{
    public class Product
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string NuocSX { get; set; }
        public string ChatLieu { get; set; }
        public string Hinh { get; set; }
        public string Gia { get; set; }
        public int MaLoaiSP { get; set; }
    }
}