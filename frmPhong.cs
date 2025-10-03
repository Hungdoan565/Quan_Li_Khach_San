using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _223277_DoanVinhHung
{
    public partial class frmPhong : Form
    {
        string connectionString = "Data Source=LAPTOP-OD073M13\\MAY1;Initial Catalog=QuanLyKhachSan;Integrated Security=True";

        public frmPhong()
        {
            InitializeComponent();
            LoadDanhSachPhong();
            LoadComboBoxLoaiPhong();
            LoadComboBoxTrangThai();
            btnThemPhong.Click += new EventHandler(btnThemPhong_Click);
            btnSuaPhong.Click += new EventHandler(btnSuaPhong_Click);
            btnXoaPhong.Click += new EventHandler(btnXoaPhong_Click);
            btnTaiLaiPhong.Click += new EventHandler(btnTaiLaiPhong_Click);
            btnThoat.Click += new EventHandler(btnThoat_Click);
        }

        // Khi form load, hiển thị danh sách phòng và load dữ liệu cho ComboBox
        private void frmPhong_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhong();
            LoadComboBoxLoaiPhong();
            LoadComboBoxTrangThai();
        }

        // Load danh sách phòng lên DataGridView
        private void LoadDanhSachPhong()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT p.MaPhong, p.MaLoaiPhong, lp.TenLoaiPhong, p.TrangThai 
                    FROM Phong p
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPhong.DataSource = dt;
            }
        }

        // Load dữ liệu cho ComboBox Loại Phòng
        private void LoadComboBoxLoaiPhong()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaLoaiPhong, TenLoaiPhong FROM LoaiPhong";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboMaLoaiPhong.DataSource = dt;
                cboMaLoaiPhong.DisplayMember = "TenLoaiPhong";
                cboMaLoaiPhong.ValueMember = "MaLoaiPhong";
            }
        }

        // Load dữ liệu cho ComboBox Trạng Thái
        private void LoadComboBoxTrangThai()
        {
            cboTrangThai.Items.AddRange(new string[] { "Trống", "Đang ở", "Đặt trước", "Bảo trì" });
        }

        // Thêm phòng
        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(txtMaPhong.Text))
            {
                MessageBox.Show("Mã phòng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboMaLoaiPhong.SelectedIndex == -1 || cboTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại phòng và trạng thái!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Kiểm tra trùng MaPhong
                string checkQuery = "SELECT COUNT(*) FROM Phong WHERE MaPhong = @MaPhong";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@MaPhong", txtMaPhong.Text);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Mã phòng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm vào CSDL
                string insertQuery = "INSERT INTO Phong (MaPhong, MaLoaiPhong, TrangThai) VALUES (@MaPhong, @MaLoaiPhong, @TrangThai)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@MaPhong", txtMaPhong.Text);
                insertCmd.Parameters.AddWithValue("@MaLoaiPhong", cboMaLoaiPhong.SelectedValue);
                insertCmd.Parameters.AddWithValue("@TrangThai", cboTrangThai.SelectedItem.ToString());
                insertCmd.ExecuteNonQuery();

                MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachPhong(); // Cập nhật danh sách
                ClearInputs(); // Xóa dữ liệu nhập
            }
        }

        // Sửa phòng
        private void btnSuaPhong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboMaLoaiPhong.SelectedIndex == -1 || cboTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại phòng và trạng thái!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string updateQuery = "UPDATE Phong SET MaLoaiPhong = @MaLoaiPhong, TrangThai = @TrangThai WHERE MaPhong = @MaPhong";
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@MaPhong", txtMaPhong.Text);
                updateCmd.Parameters.AddWithValue("@MaLoaiPhong", cboMaLoaiPhong.SelectedValue);
                updateCmd.Parameters.AddWithValue("@TrangThai", cboTrangThai.SelectedItem.ToString());
                updateCmd.ExecuteNonQuery();

                MessageBox.Show("Sửa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachPhong();
                ClearInputs();
                txtMaPhong.ReadOnly = false; // Reset readonly
            }
        }

        // Xóa phòng
        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Kiểm tra ràng buộc
                string checkQuery = @"
                    SELECT COUNT(*) 
                    FROM DatPhong 
                    WHERE MaPhong = @MaPhong 
                    AND TrangThaiDatPhong NOT IN (N'Đã trả', N'Đã hủy')";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@MaPhong", txtMaPhong.Text);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Phòng đang được đặt hoặc sử dụng, không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xác nhận xóa
                if (MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM Phong WHERE MaPhong = @MaPhong";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                    deleteCmd.Parameters.AddWithValue("@MaPhong", txtMaPhong.Text);
                    deleteCmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachPhong();
                    ClearInputs();
                }
            }
        }

        // Tải lại danh sách phòng
        private void btnTaiLaiPhong_Click(object sender, EventArgs e)
        {
            LoadDanhSachPhong();
            ClearInputs();
            txtMaPhong.ReadOnly = false;
        }

        // Thoát form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Xóa dữ liệu nhập trên giao diện
        private void ClearInputs()
        {
            txtMaPhong.Clear();
            cboMaLoaiPhong.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
        }

        // Hiển thị thông tin phòng khi chọn trên DataGridView
        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhong.Rows[e.RowIndex];
                txtMaPhong.Text = row.Cells["MaPhong"].Value.ToString();
                txtMaPhong.ReadOnly = true; // Không cho sửa MaPhong khi ở chế độ sửa
                cboMaLoaiPhong.SelectedValue = row.Cells["MaLoaiPhong"].Value.ToString();
                cboTrangThai.SelectedItem = row.Cells["TrangThai"].Value.ToString();
            }
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            frmKhachHang khachHangForm = new frmKhachHang();
            khachHangForm.ShowDialog();
        }

        private void btnChuyenQuaDatPhong_Click(object sender, EventArgs e)
        {
            frmDatPhong datphongForm = new frmDatPhong();
            datphongForm.ShowDialog();
        }
    }
}
