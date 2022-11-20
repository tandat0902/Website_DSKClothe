using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace DSK_Clothes.Models
{
    public class User
    {
        public int MaKH { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Họ và tên!")]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Email!")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email của bạn không phù hợp!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Số điện thoại!")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Ngày sinh!")]
        public string BirthDay { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Mật khẩu!")]
        //[Range(6, 20, ErrorMessage = "Mật khẩu ít nhất 6 kí tự và tối đa là 20 ký tự!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Lại mật khẩu!")]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp!")]
        public string ConfirmPassword { get; set; }
        public int MaQuyen { get; set; }
    }
}