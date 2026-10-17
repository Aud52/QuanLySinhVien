
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.DAL
{
    public class LopHocDAO
    {
        // Lấy toàn bộ danh sách lớp
        public List<LopHoc> GetAll()
        {
            List<LopHoc> danhSach = new List<LopHoc>();

            using (SqlConnection conn =
                   DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql = "SELECT MaLop, TenLop FROM LopHoc";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        danhSach.Add(new LopHoc
                        {
                            MaLop = reader["MaLop"].ToString() ?? "",
                            TenLop = reader["TenLop"].ToString() ?? ""
                        });
                    }
                }
            }

            return danhSach;
        }

        // Lấy một lớp theo mã
        public LopHoc? GetById(string maLop)
        {
            using (SqlConnection conn =
                   DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql =
                    "SELECT MaLop, TenLop FROM LopHoc WHERE MaLop = @MaLop";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLop", maLop);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new LopHoc
                            {
                                MaLop = reader["MaLop"].ToString() ?? "",
                                TenLop = reader["TenLop"].ToString() ?? ""
                            };
                        }
                    }
                }
            }

            return null;
        }

        // Thêm lớp
        public void Insert(LopHoc lop)
        {
            using (SqlConnection conn =
                   DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql =
                    "INSERT INTO LopHoc (MaLop, TenLop) VALUES (@MaLop, @TenLop)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLop", lop.MaLop);
                    cmd.Parameters.AddWithValue("@TenLop", lop.TenLop);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Sửa lớp
        public void Update(LopHoc lop)
        {
            using (SqlConnection conn =
                   DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql =
                    "UPDATE LopHoc SET TenLop = @TenLop WHERE MaLop = @MaLop";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLop", lop.MaLop);
                    cmd.Parameters.AddWithValue("@TenLop", lop.TenLop);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 0)
                        throw new Exception("Không tìm thấy lớp cần sửa.");
                }
            }
        }

        // Xóa lớp
        public void Delete(string maLop)
        {
            using (SqlConnection conn =
                   DbConnectionFactory.CreateConnection())
            {
                conn.Open();

                string sql = "DELETE FROM LopHoc WHERE MaLop = @MaLop";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLop", maLop);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 0)
                        throw new Exception("Không tìm thấy lớp cần xóa.");
                }
            }
        }
    }
}
