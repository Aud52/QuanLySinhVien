
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.BUS
{
    public class LopHocBUS
    {
        private readonly LopHocDAO _dao = new LopHocDAO();

        // Lấy danh sách lớp
        public List<LopHoc> GetAll()
        {
            return _dao.GetAll();
        }

        // Tìm lớp theo mã
        public LopHoc? GetById(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
                throw new ArgumentException("Mã lớp không được để trống.");

            return _dao.GetById(maLop.Trim());
        }

        // Kiểm tra dữ liệu lớp
        private void Validate(LopHoc lop)
        {
            if (lop == null)
                throw new ArgumentNullException(nameof(lop));

            lop.MaLop = lop.MaLop?.Trim() ?? "";
            lop.TenLop = lop.TenLop?.Trim() ?? "";

            if (!lop.IsValid(out List<ValidationResult> errors))
            {
                string message = string.Join(
                    "\n", errors.Select(e => e.ErrorMessage));

                throw new ArgumentException(message);
            }
        }

        // Thêm lớp
        public void Insert(LopHoc lop)
        {
            Validate(lop);

            if (_dao.GetById(lop.MaLop) != null)
                throw new InvalidOperationException(
                    "Mã lớp đã tồn tại.");

            _dao.Insert(lop);
        }

        // Sửa lớp
        public void Update(LopHoc lop)
        {
            Validate(lop);

            if (_dao.GetById(lop.MaLop) == null)
                throw new InvalidOperationException(
                    "Không tìm thấy lớp cần sửa.");

            _dao.Update(lop);
        }

        // Xóa lớp
        public void Delete(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
                throw new ArgumentException(
                    "Mã lớp không được để trống.");

            if (_dao.GetById(maLop.Trim()) == null)
                throw new InvalidOperationException(
                    "Không tìm thấy lớp cần xóa.");

            _dao.Delete(maLop.Trim());
        }
    }
}
