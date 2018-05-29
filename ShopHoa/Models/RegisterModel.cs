using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopHoa.Models
{
    public class RegisterModel
    {
        [Key]
        public int UserID { get; set; }
        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage ="Vui lòng điền tên đăng nhập")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20,MinimumLength =8, ErrorMessage ="Độ dài mật khẩu ít nhất 8 ký tự.")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage ="Xác nhận mật khẩu không trùng khớp.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string Name { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Địa chỉ mail")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ mail")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Phone { get; set; }
    }
}