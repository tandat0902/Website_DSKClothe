using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DSK_Clothes.Models;

namespace DSK_Clothes.ConnectionDatabase
{
    public class ConnectProduct
    {
        string conStr = "Data Source=DESKTOP-U7DTMNK;Initial Catalog=QL_BANHANG;Persist Security Info=True;User ID=sa;Password=123";
        //string conStr = "Data Source=DESKTOP-U7DTMNK;Initial Catalog=QL_BANHANG;Integrated Security=True";

        //------------------------------------------------- LẤY TẤT CẢ SẢN PHẨM
        public List<Product> getAllProduct()
        {
            List<Product> listProduct = new List<Product>();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM SANPHAM";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                con.Close();

                foreach (DataRow row in dt.Rows)
                {
                    string gia = String.Format("{0:0,0}", (decimal)row["GIA"]);
                    listProduct.Add(new Product
                    {
                        MaSP = (int)row["MaSP"],
                        TenSP = row["TENSP"].ToString(),
                        NuocSX = row["NUOCSX"].ToString(),
                        ChatLieu = row["CHATLIEU"].ToString(),
                        Hinh = row["HINH"].ToString(),
                        Gia = gia,
                        MaLoaiSP = (int)row["MaLoaiSP"]
                    });
                }
                return listProduct;
            }
        }

        //------------------------------------------------- LẤY 8 SẢN PHẨM
        public List<Product> get8Product()
        {
            List<Product> listProduct = new List<Product>();
            int count = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM SANPHAM";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                con.Close();

                foreach (DataRow row in dt.Rows)
                {
                    if (count == 8)
                    {
                        break;
                    }
                    string gia = String.Format("{0:0,0}", (decimal)row["GIA"]);
                    listProduct.Add(new Product
                    {
                        MaSP = (int)row["MaSP"],
                        TenSP = row["TENSP"].ToString(),
                        NuocSX = row["NUOCSX"].ToString(),
                        ChatLieu = row["CHATLIEU"].ToString(),
                        Hinh = row["HINH"].ToString(),
                        Gia = gia,
                        MaLoaiSP = (int)row["MaLoaiSP"]
                    });
                    count++;
                }
                return listProduct;
            }
        }

        //------------------------------------------------- LẤY SẢN PHẨM BẰNG MÃ SẢN PHẨM
        public List<Product> getProductByID(int MASP)
        {
            List<Product> listProduct = new List<Product>();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM SANPHAM WHERE MASP = '" + MASP + "'";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                con.Close();

                foreach (DataRow row in dt.Rows)
                {
                    string gia = String.Format("{0:0,0}", (decimal)row["GIA"]);
                    listProduct.Add(new Product
                    {
                        MaSP = (int)row["MaSP"],
                        TenSP = row["TENSP"].ToString(),
                        NuocSX = row["NUOCSX"].ToString(),
                        ChatLieu = row["CHATLIEU"].ToString(),
                        Hinh = row["HINH"].ToString(),
                        Gia = gia,
                        MaLoaiSP = (int)row["MaLoaiSP"]
                    });
                }
                return listProduct;
            }
        }

        //------------------------------------------------- THÊM MỚI SẢN PHẨM
        public bool createProduct(Product p)
        {
            int id = 0;
            int kt = 0;
            decimal g = decimal.Parse(p.Gia);
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT COUNT(*) FROM SANPHAM WHERE TENSP = '" + p.TenSP + "'";
                con.Open();
                kt = (int)cmd1.ExecuteScalar();
                if (kt == 0)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO SANPHAM(TENSP, NUOCSX, CHATLIEU, HINH, GIA, MALOAISP) VALUES (N'" + p.TenSP + "', N'" + p.NuocSX + "', N'" + p.ChatLieu + "', '" + p.Hinh + "', " + g + ", '" + p.MaLoaiSP + "')";

                    id = cmd.ExecuteNonQuery();

                    if (id > 0)
                        return true;
                }
                con.Close();
                return false;
            }
        }

        //------------------------------------------------- SỬA MỘT SẢN PHẨM
        public bool updateProductByID(int MASP, string TenSP, string NuocSX, string ChatLieu, string Hinh, string Gia, int MaLoaiSP)
        {
            int id = 0;
            decimal g = decimal.Parse(Gia);
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE SANPHAM SET TENSP = N'" + TenSP + "', NUOCSX = N'" + NuocSX + "', CHATLIEU = N'" + ChatLieu + "', HINH = '" + Hinh + "', GIA = " + g + " , MALOAISP = " + MaLoaiSP + " WHERE  MASP = " + MASP + "";

                con.Open();
                id = cmd.ExecuteNonQuery();
                con.Close();

                if (id > 0)
                    return true;
                return false;
            }
        }

        //------------------------------------------------- XÓA MỘT SẢN PHẨM
        public bool deleteProductByID(int MASP)
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM SANPHAM WHERE MASP = '" + MASP + "'";
                con.Open();
                id = cmd.ExecuteNonQuery();
                con.Close();
                if(id > 0)
                    return true;
                return false;
            }
        }

        //------------------------------------------------- TÌM KIẾM SẢN PHẨM
        public List<Product> search(string txtSearch)
        {
            List<Product> listProducts = new List<Product>();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM SANPHAM WHERE TENSP LIKE N'%" + txtSearch + "%' ORDER BY GIA ASC";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                con.Close();

                foreach (DataRow row in dt.Rows)
                {
                    listProducts.Add(new Product
                    {
                        MaSP = (int)row["MASP"],
                        TenSP = row["TENSP"].ToString(),
                        NuocSX = row["NUOCSX"].ToString(),
                        ChatLieu = row["CHATLIEU"].ToString(),
                        Gia = row["GIA"].ToString(),
                        Hinh = row["HINH"].ToString(),
                        MaLoaiSP = (int)row["MALOAISP"]
                    });
                }
                return listProducts;
            }
        }
    }
}