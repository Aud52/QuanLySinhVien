using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVien.DTO
{
    public class SinhVien
    {
        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        [StringLength(20, ErrorMessage = "Mã sinh viên tối đa 20 ký tự")]
        public string MaSV { get; set; } = "";

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100, ErrorMessage = "Họ tên tối đa 100 ký tự")]
        public string HoTen { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng chọn lớp")]
        public string MaLop { get; set; } = "";

        // Nhiều sinh viên thuộc một lớp
        public LopHoc? LopHoc { get; set; }

        public bool IsValid(
            out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();

            return Validator.TryValidateObject(
                this,
                new ValidationContext(this),
                errors,
                true);
        }
    }
}
