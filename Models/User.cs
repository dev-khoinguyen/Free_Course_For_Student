using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EXE_PROJECT.Models
{
    public partial class User
    {
        public User()
        {
            Certificates = new HashSet<Certificate>();
            UserCourses = new HashSet<UserCourse>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
        public string PasswordHash { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu.")]
        [Compare("PasswordHash", ErrorMessage = "Mật khẩu nhập lại không khớp.")]
        public string ConfirmPassword { get; set; } // Thêm thuộc tính này để so sánh

        public string Role { get; set; } = "User"; // Mặc định là User

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
