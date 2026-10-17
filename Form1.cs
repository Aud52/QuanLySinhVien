
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLySinhVien.BUS;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {
        private readonly LopHocBUS lopBUS = new LopHocBUS();
        private readonly SinhVienBUS svBUS = new SinhVienBUS();

        private bool dangNap = false;

        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
            cboLop.SelectedIndexChanged += cboLop_SelectedIndexChanged;
            txtMa.TextChanged += txtMa_TextChanged;
            dgvSinhVien.SelectionChanged += dgvSinhVien_SelectionChanged;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
        }

        // 1. Khi mở Form: tải danh sách lớp
        private void Form1_Load(object? sender, EventArgs e)
        {
            try
            {
                dangNap = true;

                cboLop.DataSource = lopBUS.GetAll();
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";

                TaoCotBang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách lớp.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dangNap = false;
            }

            if (cboLop.SelectedIndex >= 0)
                TaiSinhVienTheoLop();
        }

        // 2. Tạo các cột hiển thị
        private void TaoCotBang()
        {
            dgvSinhVien.AutoGenerateColumns = false;
            dgvSinhVien.Columns.Clear();

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaSV",
                HeaderText = "Mã sinh viên",
                DataPropertyName = "MaSV"
            });

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHoTen",
                HeaderText = "Họ tên",
                DataPropertyName = "HoTen"
            });

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaLop",
                HeaderText = "Mã lớp",
                DataPropertyName = "MaLop"
            });
        }

        // 3. Chọn lớp nào thì hiện sinh viên lớp đó
        private void cboLop_SelectedIndexChanged(
            object? sender, EventArgs e)
        {
            if (!dangNap)
                TaiSinhVienTheoLop();
        }

        private void TaiSinhVienTheoLop()
        {
            try
            {
                if (cboLop.SelectedValue == null)
                {
                    dgvSinhVien.DataSource = null;
                    return;
                }

                string maLop = cboLop.SelectedValue.ToString()!;

                dgvSinhVien.DataSource = null;
                dgvSinhVien.DataSource = svBUS.GetByMaLop(maLop);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được sinh viên.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. Nhập mã sinh viên: tìm và hiện thông tin
        private void txtMa_TextChanged(object? sender, EventArgs e)
        {
            errorProvider1.SetError(txtMa, "");

            if (dangNap)
                return;

            string maSV = txtMa.Text.Trim();

            if (maSV.Length == 0)
            {
                txtHoTen.Clear();
                return;
            }

            try
            {
                SinhVien? sv = svBUS.GetByMaSV(maSV);

                if (sv != null)
                {
                    dangNap = true;

                    txtHoTen.Text = sv.HoTen;

                    for (int i = 0; i < cboLop.Items.Count; i++)
                    {
                        if (cboLop.Items[i] is LopHoc lop &&
                            lop.MaLop == sv.MaLop)
                        {
                            cboLop.SelectedIndex = i;
                            break;
                        }
                    }

                    dangNap = false;
                    TaiSinhVienTheoLop();
                }
                else
                {
                    txtHoTen.Clear();
                }
            }
            catch (Exception ex)
            {
                dangNap = false;
                MessageBox.Show(
                    "Lỗi tìm sinh viên: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. Chọn một dòng trên bảng để hiện lên ô nhập
        private void dgvSinhVien_SelectionChanged(
            object? sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null ||
                dgvSinhVien.CurrentRow.IsNewRow)
                return;

            object ma = dgvSinhVien.CurrentRow.Cells["colMaSV"].Value;

            if (ma == null)
                return;

            dangNap = true;

            txtMa.Text = ma.ToString();
            txtHoTen.Text =
                dgvSinhVien.CurrentRow.Cells["colHoTen"].Value?.ToString() ?? "";

            dangNap = false;
        }

        // 6. Kiểm tra dữ liệu và báo lỗi đúng ô
        private bool KiemTraDuLieu()
        {
            errorProvider1.Clear();
            bool hopLe = true;

            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                errorProvider1.SetError(txtMa, "Mã sinh viên không được để trống.");
                hopLe = false;
            }
            else if (txtMa.Text.Trim().Length > 20)
            {
                errorProvider1.SetError(txtMa, "Mã sinh viên tối đa 20 ký tự.");
                hopLe = false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                errorProvider1.SetError(txtHoTen, "Họ tên không được để trống.");
                hopLe = false;
            }
            else if (txtHoTen.Text.Trim().Length > 100)
            {
                errorProvider1.SetError(txtHoTen, "Họ tên tối đa 100 ký tự.");
                hopLe = false;
            }

            if (cboLop.SelectedValue == null)
            {
                errorProvider1.SetError(cboLop, "Vui lòng chọn lớp.");
                hopLe = false;
            }

            return hopLe;
        }

        private SinhVien TaoSinhVien()
        {
            LopHoc lop = (LopHoc)cboLop.SelectedItem!;

            return new SinhVien
            {
                MaSV = txtMa.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                MaLop = lop.MaLop,
                LopHoc = lop
            };
        }

        // 7. Thêm sinh viên
        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            try
            {
                svBUS.Insert(TaoSinhVien());

                MessageBox.Show("Thêm sinh viên thành công.");

                TaiSinhVienTheoLop();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Không thể thêm sinh viên",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 8. Sửa sinh viên
        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            try
            {
                svBUS.Update(TaoSinhVien());

                MessageBox.Show("Cập nhật sinh viên thành công.");

                TaiSinhVienTheoLop();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Không thể sửa sinh viên",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 9. Xóa sinh viên
        private void btnXoa_Click(object? sender, EventArgs e)
        {
            string maSV = txtMa.Text.Trim();

            if (string.IsNullOrWhiteSpace(maSV))
            {
                errorProvider1.SetError(txtMa, "Nhập mã sinh viên cần xóa.");
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa sinh viên " + maSV + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            try
            {
                svBUS.Delete(maSV);

                MessageBox.Show("Xóa sinh viên thành công.");

                TaiSinhVienTheoLop();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Không thể xóa sinh viên",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 10. Làm mới các ô nhập
        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            dangNap = true;

            txtMa.Clear();
            txtHoTen.Clear();
            errorProvider1.Clear();
            dgvSinhVien.ClearSelection();

            dangNap = false;
            txtMa.Focus();
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
