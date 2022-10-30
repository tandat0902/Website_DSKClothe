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
        string conStr = "Data Source=DESKTOP-U7DTMNK;Initial Catalog=QL_BANHANG;Integrated Security=True";

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
                    listProduct.Add(new Product
                    {
                        MaSP = (int)row["MaSP"],
                        TenSP = row["TENSP"].ToString(),
                        NuocSX = row["NUOCSX"].ToString(),
                        ChatLieu = row["CHATLIEU"].ToString(),
                        Hinh = row["HINH"].ToString(),
                        Gia = (decimal)row["GIA"]
                    });
                }
                return listProduct;
            }
        }
    }
}