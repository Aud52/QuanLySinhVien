
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.BUS
{
    public class SinhVienBUS
    {
        private readonly SinhVienDAO _svDAO = new SinhVienDAO();
        private readonly LopHocDAO _lopDAO = new LopHocDAO();

        // Lấy tất cả sinh viên
        public List<SinhVien> GetAll()
        {
            return _svDAO.GetAll();
        }

        // Lấy sinh viên theo lớp
        public List<SinhVien> GetByMaLop(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
                throw new ArgumentException(
                    "Vui lòng chọn lớp.");

            // Kiểm tra lớp có tồn tại
            if (_lopDAO.GetById(maLop.Trim()) == null)
                throw new InvalidOperationException(
                    "Lớp được chọn không tồn tại.");

            return _svDAO.GetByMaLop(maLop.Trim());
        }

        // Tìm sinh viên theo mã
        public SinhVien? GetByMaSV(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new ArgumentException(
                    "Mã sinh viên không được để trống.");

            return _svDAO.GetByMaSV(maSV.Trim());
        }

        // Kiểm tra dữ liệu trước khi thêm hoặc sửa
        private void Validate(SinhVien sv)
        {
            if (sv == null)
                throw new ArgumentNullException(nameof(sv));

            sv.MaSV = sv.MaSV?.Trim() ?? "";
            sv.HoTen = sv.HoTen?.Trim() ?? "";
            sv.MaLop = sv.MaLop?.Trim() ?? "";

            if (!sv.IsValid(out List<ValidationResult> errors))
            {
                string message = string.Join(
                    "\n", errors.Select(e => e.ErrorMessage));

                throw new ArgumentException(message);
            }

            if (_lopDAO.GetById(sv.MaLop) == null)
                throw new ArgumentException(
                    "Mã lớp không tồn tại. Vui lòng chọn lớp hợp lệ.");
        }

        // Thêm sinh viên
        public void Insert(SinhVien sv)
        {
            Validate(sv);

            if (_svDAO.GetByMaSV(sv.MaSV) != null)
                throw new InvalidOperationException(
                    "Mã sinh viên đã tồn tại.");

            _svDAO.Insert(sv);
        }

        // Sửa sinh viên
        public void Update(SinhVien sv)
        {
            Validate(sv);

            if (_svDAO.GetByMaSV(sv.MaSV) == null)
                throw new InvalidOperationException(
                    "Không tìm thấy sinh viên cần sửa.");

            _svDAO.Update(sv);
        }

        // Xóa sinh viên
        public void Delete(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new ArgumentException(
                    "Mã sinh viên không được để trống.");

            if (_svDAO.GetByMaSV(maSV.Trim()) == null)
                throw new InvalidOperationException(
                    "Không tìm thấy sinh viên cần xóa.");

            _svDAO.Delete(maSV.Trim());
        }
    }
}
