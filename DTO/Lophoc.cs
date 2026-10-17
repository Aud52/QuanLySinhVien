using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVien.DTO
{
    public class LopHoc
    {
        [Required(ErrorMessage = "Mã lớp không được để trống")]
        [StringLength(20, ErrorMessage = "Mã lớp tối đa 20 ký tự")]
        public string MaLop { get; set; } = "";

        [Required(ErrorMessage = "Tên lớp không được để trống")]
        [StringLength(100, ErrorMessage = "Tên lớp tối đa 100 ký tự")]
        public string TenLop { get; set; } = "";

        // Một lớp có nhiều sinh viên
        public List<SinhVien> SinhViens { get; set; }
            = new List<SinhVien>();

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