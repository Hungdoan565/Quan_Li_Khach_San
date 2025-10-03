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
    public partial class frmKhachHang : Form
    {
        string connectionString = "Data Source=LAPTOP-OD073M13\\MAY1;Initial Catalog=QuanLyKhachSan;Integrated Security=True";

        public frmKhachHang()
        {
            InitializeComponent();
            LoadDanhSachKhachHang();

            // Gắn sự kiện thủ công
            btnThemKH.Click += new EventHandler(btnThemKH_Click);
            btnSuaKH.Click += new EventHandler(btnSuaKH_Click);
            btnXoaKH.Click += new EventHandler(btnXoaKH_Click);
            btnTaiLaiKH.Click += new EventHandler(btnTaiLaiKH_Click);
            btnThoat.Click += new EventHandler(btnThoat_Click);
            dgvKhachHang.CellClick += new DataGridViewCellEventHandler(dgvKhachHang_CellClick);
        }

        // Load danh sách khách hàng lên DataGridView
        private void LoadDanhSachKhachHang()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaKH, HoTen, CCCD, SoDienThoai, DiaChi FROM KhachHang";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKhachHang.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm khách hàng
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaKH.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtCCCD.Text))
                {
                    MessageBox.Show("Mã KH, Họ Tên và CCCD không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Kiểm tra trùng MaKH hoặc CCCD
                    string checkQuery = "SELECT COUNT(*) FROM KhachHang WHERE MaKH = @MaKH OR CCCD = @CCCD";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                    checkCmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Mã KH hoặc CCCD đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Thêm vào CSDL
                    string insertQuery = "INSERT INTO KhachHang (MaKH, HoTen, CCCD, SoDienThoai, DiaChi) VALUES (@MaKH, @HoTen, @CCCD, @SoDienThoai, @DiaChi)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                    insertCmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    insertCmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                    insertCmd.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
                    insertCmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachKhachHang();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa khách hàng
        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaKH.Text))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtCCCD.Text))
                {
                    MessageBox.Show("Họ Tên và CCCD không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE KhachHang SET HoTen = @HoTen, CCCD = @CCCD, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi WHERE MaKH = @MaKH";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                    updateCmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    updateCmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                    updateCmd.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
                    updateCmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachKhachHang();
                    ClearInputs();
                    txtMaKH.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa khách hàng
        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaKH.Text))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Kiểm tra ràng buộc với DatPhong
                    string checkQuery = @"
                        SELECT COUNT(*) 
                        FROM DatPhong 
                        WHERE MaKH = @MaKH 
                        AND TrangThaiDatPhong NOT IN (N'Đã trả', N'Đã hủy')";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Khách hàng đang có đơn đặt phòng, không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string deleteQuery = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                        SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                        deleteCmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                        deleteCmd.ExecuteNonQuery();

                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachKhachHang();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tải lại danh sách khách hàng
        private void btnTaiLaiKH_Click(object sender, EventArgs e)
        {
            LoadDanhSachKhachHang();
            ClearInputs();
            txtMaKH.ReadOnly = false;
        }

        // Thoát form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Chuyển sang form frmPhong
        private void btnChuyenPhong_Click(object sender, EventArgs e)
        {
            frmPhong frm = new frmPhong();
            frm.Show();
            this.Hide(); // Ẩn form hiện tại thay vì đóng để giữ trạng thái
        }

        // Xóa dữ liệu nhập trên giao diện
        private void ClearInputs()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtCCCD.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
        }

        // Hiển thị thông tin khách hàng khi chọn trên DataGridView
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                    txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                    txtMaKH.ReadOnly = true; // Không cho sửa MaKH khi ở chế độ sửa
                    txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                    txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
                    txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
                    txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
