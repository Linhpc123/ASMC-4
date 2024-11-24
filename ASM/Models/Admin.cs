using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.Models
{
    [Table("Admin", Schema = "Admin")]   
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập họ tên.")]
        [StringLength(150, ErrorMessage = "Họ tên không được vượt quá 150 ký tự.")]
        [Display(Name = "Họ & Tên")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập email.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập số điện thoại.")]
        [StringLength(15, ErrorMessage = "Số điện thoại không được vượt quá 15 ký tự.")]
        [RegularExpression(@"^(\+?\d{1,3}[- ]?)?\d{10}$", ErrorMessage = "Số điện thoại không hợp lệ.")]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string AdminImageUrl { get; set; }

        [StringLength(250, ErrorMessage = "Địa chỉ không được vượt quá 250 ký tự.")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập mật khẩu.")]
        [StringLength(50, ErrorMessage = "Mật khẩu không được vượt quá 50 ký tự.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập lại mật khẩu.")]
        [Compare("Password", ErrorMessage = "Mật khẩu gõ lại không khớp.")]
        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập vai trò.")]
        [StringLength(50, ErrorMessage = "Vai trò không được vượt quá 50 ký tự.")]
        [Display(Name = "Vai trò")]
        public string Role { get; set; } = "Admin"; // Mặc định là Admin

        [Required(ErrorMessage = "Bạn cần nhập ngày tạo tài khoản.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày tạo tài khoản")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Trạng thái hoạt động")]
        public bool IsActive { get; set; } = true; // Trạng thái hoạt động mặc định là true
    }
}
