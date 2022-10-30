using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DSK_Clothes.Models;

namespace DSK_Clothes.ConnectionDatabase
{
    public class ConnectUser
    {
        string conStr = "Data Source=DESKTOP-U7DTMNK;Initial Catalog=QL_BANHANG;Integrated Security=True";

        //------------------------------------------------- LẤY TẤT CẢ THÔNG TIN CỦA KHÁCH HÀNG
        public List<User> getAllUser()
        {
            List<User> listUser = new List<User>();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM KHACHHANG";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                con.Close();

                foreach (DataRow row in dt.Rows)
                {
                    listUser.Add(new User
                    {
                        MaKH = (int)row["MAKH"],
                        FullName = row["HOTEN"].ToString(),
                        Email = row["EMAIL"].ToString(),
                        Tel = row["SODT"].ToString(),
                        BirthDay = row["NGAYSINH"].ToString(),
                        Password = row["MATKHAU"].ToString()
                    });
                }
                return listUser;
            }
        }

        //------------------------------------------------- ĐĂNG KÝ MỚI
        public bool createAccount(User u)
        {
            int id = 0;
            int kt = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT COUNT(*) FROM KHACHHANG WHERE SODT = '" + u.Tel + "'";
                con.Open();
                kt = (int)cmd1.ExecuteScalar();
                if (kt == 0)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    string sql = "INSERT INTO KHACHHANG(HOTEN, EMAIL, SODT, NGAYSINH, MATKHAU) ";
                    sql += "VALUES ('" + u.FullName + "', '" + u.Email + "', '" + u.Tel + "', '" + u.BirthDay + "', '" + u.Password + "')";
                    cmd.CommandText = sql;

                    id = cmd.ExecuteNonQuery();
                    if (id > 0)
                    {
                        return true;
                    }
                }
                con.Close();
                return false;
            }
        }

        //------------------------------------------------- ĐĂNG NHẬP
        public bool loginAccount(string SODT)
        {
            int kt = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string sql = "SELECT * FROM KHACHHANG WHERE SODT = '" + SODT + "'";
                cmd.CommandText = sql;
                con.Open();
                kt = (int)cmd.ExecuteScalar();
                con.Close();
                if (kt > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}