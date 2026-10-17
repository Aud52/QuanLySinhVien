
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.DAL
{
    public class SinhVienDAO
    {
        // Lấy tất cả sinh viên
        public List<SinhVien> GetAll()
        {
            List<SinhVien> danhSach = new List<SinhVien>();

            using (SqlConnection conn =
                   DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql =
                    "SELECT MaSV, HoTen, MaLop FROM SinhVien";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        danhSach.Add(new SinhVien
                        {
                            MaSV = reader["MaSV"].ToString() ?? "",
                            HoTen = reader["HoTen"].ToString() ?? "",
                            MaLop = reader["MaLop"].ToString() ?? ""
                        });
                    }
                }
            }

            return danhSach;
        }

        // Lấy sinh viên theo lớp
        public List<SinhVien> GetByMaLop(string maLop)
        {
            List<SinhVien> danhSach = new List<SinhVien>();

            using (SqlConnection conn =
                   DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql =
                    "SELECT MaSV, HoTen, MaLop FROM SinhVien WHERE MaLop = @MaLop";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLop", maLop);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSach.Add(new SinhVien
                            {
                                MaSV = reader["MaSV"].ToString() ?? "",
                                HoTen = reader["HoTen"].ToString() ?? "",
                                MaLop = reader["MaLop"].ToString() ?? ""
                            });
                        }
                    }
                }
            }

            return danhSach;
        }

        // Tìm sinh viên theo mã
        public SinhVien? GetByMaSV(string maSV)
        {
            using (SqlConnection conn =
                   DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql =
                    "SELECT MaSV, HoTen, MaLop FROM SinhVien WHERE MaSV = @MaSV";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", maSV);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new SinhVien
                            {
                                MaSV = reader["MaSV"].ToString() ?? "",
                                HoTen = reader["HoTen"].ToString() ?? "",
                                MaLop = reader["MaLop"].ToString() ?? ""
                            };
                        }
                    }
                }
            }

            return null;
        }

        // Thêm sinh viên
        public void Insert(SinhVien sv)
        {
            using (SqlConnection conn =
                   DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql =
                    "INSERT INTO SinhVien (MaSV, HoTen, MaLop) VALUES (@MaSV, @HoTen, @MaLop)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", sv.MaSV);
                    cmd.Parameters.AddWithValue("@HoTen", sv.HoTen);
                    cmd.Parameters.AddWithValue("@MaLop", sv.MaLop);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Sửa sinh viên
        public void Update(SinhVien sv)
        {
            using (SqlConnection conn =
                   DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql =
                    "UPDATE SinhVien SET HoTen = @HoTen, MaLop = @MaLop WHERE MaSV = @MaSV";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", sv.MaSV);
                    cmd.Parameters.AddWithValue("@HoTen", sv.HoTen);
                    cmd.Parameters.AddWithValue("@MaLop", sv.MaLop);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 0)
                        throw new Exception("Không tìm thấy sinh viên cần sửa.");
                }
            }
        }

        // Xóa sinh viên
        public void Delete(string maSV)
        {
            using (SqlConnection conn =
                   DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql = "DELETE FROM SinhVien WHERE MaSV = @MaSV";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", maSV);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 0)
                        throw new Exception("Không tìm thấy sinh viên cần xóa.");
                }
            }
        }
    }
}
