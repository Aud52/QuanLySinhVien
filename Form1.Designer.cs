
namespace QuanLySinhVien
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DateTimePicker dtpNgaySinh;
            lblTieuDe = new Label();
            lblLop = new Label();
            lblMa = new Label();
            lblHoTen = new Label();
            cboLop = new ComboBox();
            txtMa = new TextBox();
            txtHoTen = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvSinhVien = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            lblNgaySInh = new Label();
            lblGioiTinh = new Label();
            radNam = new RadioButton();
            radNu = new RadioButton();
            lblDiem = new Label();
            numDiem = new NumericUpDown();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDienThoai = new Label();
            txtDienThoai = new TextBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            dtpNgaySinh = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDiem).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(300, 18);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(450, 40);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "QUẢN LÝ SINH VIÊN";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLop
            // 
            lblLop.Location = new Point(680, 86);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(60, 25);
            lblLop.TabIndex = 1;
            lblLop.Text = "Chọn lớp:";
            // 
            // lblMa
            // 
            lblMa.Location = new Point(35, 86);
            lblMa.Name = "lblMa";
            lblMa.Size = new Size(85, 25);
            lblMa.TabIndex = 3;
            lblMa.Text = "Mã sinh viên:";
            // 
            // lblHoTen
            // 
            lblHoTen.Location = new Point(360, 86);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(75, 25);
            lblHoTen.TabIndex = 5;
            lblHoTen.Text = "Họ tên:";
            // 
            // cboLop
            // 
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Location = new Point(740, 82);
            cboLop.Margin = new Padding(3, 4, 3, 4);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(235, 28);
            cboLop.TabIndex = 2;
            // 
            // txtMa
            // 
            txtMa.Location = new Point(125, 82);
            txtMa.Margin = new Padding(3, 4, 3, 4);
            txtMa.MaxLength = 20;
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(210, 27);
            txtMa.TabIndex = 4;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(435, 82);
            txtHoTen.Margin = new Padding(3, 4, 3, 4);
            txtHoTen.MaxLength = 100;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(210, 27);
            txtHoTen.TabIndex = 6;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(540, 220);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 36);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            // 
            // btnSua
            // 
            btnSua.Location = new Point(650, 220);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 36);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(760, 220);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 36);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(870, 220);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(105, 36);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "Làm mới";
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.ColumnHeadersHeight = 29;
            dgvSinhVien.Location = new Point(30, 275);
            dgvSinhVien.Margin = new Padding(3, 4, 3, 4);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(920, 438);
            dgvSinhVien.TabIndex = 11;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // lblNgaySInh
            // 
            lblNgaySInh.AutoSize = true;
            lblNgaySInh.Location = new Point(35, 131);
            lblNgaySInh.Name = "lblNgaySInh";
            lblNgaySInh.Size = new Size(77, 20);
            lblNgaySInh.TabIndex = 12;
            lblNgaySInh.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(125, 127);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(210, 27);
            dtpNgaySinh.TabIndex = 13;
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(360, 131);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(72, 20);
            lblGioiTinh.TabIndex = 14;
            lblGioiTinh.Text = "Giới tính: ";
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Location = new Point(435, 129);
            radNam.Name = "radNam";
            radNam.Size = new Size(62, 24);
            radNam.TabIndex = 15;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new Point(505, 129);
            radNu.Name = "radNu";
            radNu.Size = new Size(50, 24);
            radNu.TabIndex = 16;
            radNu.TabStop = true;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            // 
            // lblDiem
            // 
            lblDiem.AutoSize = true;
            lblDiem.Location = new Point(680, 131);
            lblDiem.Name = "lblDiem";
            lblDiem.Size = new Size(52, 20);
            lblDiem.TabIndex = 17;
            lblDiem.Text = "Điểm: ";
            // 
            // numDiem
            // 
            numDiem.Location = new Point(740, 127);
            numDiem.Name = "numDiem";
            numDiem.Size = new Size(235, 27);
            numDiem.TabIndex = 18;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(35, 176);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(53, 20);
            lblEmail.TabIndex = 19;
            lblEmail.Text = "Email: ";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(125, 172);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(210, 27);
            txtEmail.TabIndex = 20;
            // 
            // lblDienThoai
            // 
            lblDienThoai.AutoSize = true;
            lblDienThoai.Location = new Point(360, 176);
            lblDienThoai.Name = "lblDienThoai";
            lblDienThoai.Size = new Size(85, 20);
            lblDienThoai.TabIndex = 21;
            lblDienThoai.Text = "Điện thoại: ";
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(435, 172);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(210, 27);
            txtDienThoai.TabIndex = 22;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(680, 176);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(82, 20);
            lblTrangThai.TabIndex = 23;
            lblTrangThai.Text = "Trạng thái: ";
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(760, 172);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(215, 28);
            cboTrangThai.TabIndex = 24;
            cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 252);
            ClientSize = new Size(1042, 633);
            Controls.Add(cboTrangThai);
            Controls.Add(lblTrangThai);
            Controls.Add(txtDienThoai);
            Controls.Add(lblDienThoai);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(numDiem);
            Controls.Add(lblDiem);
            Controls.Add(radNu);
            Controls.Add(radNam);
            Controls.Add(lblGioiTinh);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblNgaySInh);
            Controls.Add(lblTieuDe);
            Controls.Add(lblLop);
            Controls.Add(cboLop);
            Controls.Add(lblMa);
            Controls.Add(txtMa);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(dgvSinhVien);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(800, 613);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUẢN LÝ SINH VIÊN";
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDiem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblHoTen;

        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtHoTen;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;

        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Label lblNgaySInh;
        private DateTimePicker dtpNgaySinh;
        private Label lblGioiTinh;
        private Label lblDiem;
        private RadioButton radNu;
        private RadioButton radNam;
        private TextBox txtEmail;
        private Label lblEmail;
        private NumericUpDown numDiem;
        private ComboBox cboTrangThai;
        private Label lblTrangThai;
        private TextBox txtDienThoai;
        private Label lblDienThoai;
    }
}
