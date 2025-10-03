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
    public partial class frmSuDungDV: Form
    {
        string connectionString = "Data Source=LAPTOP-OD073M13\\MAY1;Initial Catalog=QuanLyKhachSan;Integrated Security=True";
        private int maDatPhong;
        public frmSuDungDV(int maDatPhong)
        {
            InitializeComponent();
            this.maDatPhong = maDatPhong;
            LoadThongTinDatPhong();
            LoadComboBoxDichVu();
            LoadDanhSachSuDungDV();

            // Gắn sự kiện thủ công
            btnThem.Click += new EventHandler(btnThem_Click);
            btnSua.Click += new EventHandler(btnSua_Click);
            btnXoa.Click += new EventHandler(btnXoa_Click);
            btnThoat.Click += new EventHandler(btnThoat_Click);
            btnSuDungDV.Click += new EventHandler(btnSuDungDV_Click);
            dgvSuDungDV.CellClick += new DataGridViewCellEventHandler(dgvSuDungDV_CellContentClick);
        }
        private void LoadThongTinDatPhong()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT dp.MaPhong, lp.TenLoaiPhong, kh.HoTen
                        FROM DatPhong dp
                        INNER JOIN Phong p ON dp.MaPhong = p.MaPhong
                        INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                        INNER JOIN KhachHang kh ON dp.MaKH = kh.MaKH
                        WHERE dp.MaDatPhong = @MaDatPhong";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblDatPhongInfo.Text = $"Phòng: {reader["MaPhong"]} - {reader["TenLoaiPhong"]} - Khách hàng: {reader["HoTen"]}";
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin đặt phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thông tin đặt phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách dịch vụ vào ComboBox
        private void LoadComboBoxDichVu()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaDV, TenDV FROM DichVu";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboMaDV.DataSource = dt;
                    cboMaDV.DisplayMember = "TenDV";
                    cboMaDV.ValueMember = "MaDV";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách sử dụng dịch vụ
        private void LoadDanhSachSuDungDV()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT s.MaSuDungDV, s.MaDV, dv.TenDV, s.NgaySuDung, s.SoLuong, s.ThanhTien
                        FROM SuDungDichVu s
                        INNER JOIN DichVu dv ON s.MaDV = dv.MaDV
                        WHERE s.MaDatPhong = @MaDatPhong";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSuDungDV.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách sử dụng dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMaDV.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (nudSoLuong.Value <= 0) // Sử dụng NumericUpDown
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Lấy đơn giá từ bảng DichVu
                    string getDonGiaQuery = "SELECT DonGia FROM DichVu WHERE MaDV = @MaDV";
                    SqlCommand cmdDonGia = new SqlCommand(getDonGiaQuery, conn);
                    cmdDonGia.Parameters.AddWithValue("@MaDV", cboMaDV.SelectedValue.ToString());
                    decimal donGia = (decimal)cmdDonGia.ExecuteScalar();
                    decimal thanhTien = donGia * nudSoLuong.Value;

                    // Thêm vào bảng SuDungDichVu
                    string insertQuery = @"
                        INSERT INTO SuDungDichVu (MaDatPhong, MaDV, NgaySuDung, SoLuong, ThanhTien)
                        VALUES (@MaDatPhong, @MaDV, @NgaySuDung, @SoLuong, @ThanhTien)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);
                    insertCmd.Parameters.AddWithValue("@MaDV", cboMaDV.SelectedValue.ToString());
                    insertCmd.Parameters.AddWithValue("@NgaySuDung", dtpNgaySuDung.Value);
                    insertCmd.Parameters.AddWithValue("@SoLuong", (int)nudSoLuong.Value);
                    insertCmd.Parameters.AddWithValue("@ThanhTien", thanhTien);
                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachSuDungDV();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa dịch vụ
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSuDungDV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cboMaDV.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (nudSoLuong.Value <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Lấy đơn giá
                    string getDonGiaQuery = "SELECT DonGia FROM DichVu WHERE MaDV = @MaDV";
                    SqlCommand cmdDonGia = new SqlCommand(getDonGiaQuery, conn);
                    cmdDonGia.Parameters.AddWithValue("@MaDV", cboMaDV.SelectedValue.ToString());
                    decimal donGia = (decimal)cmdDonGia.ExecuteScalar();
                    decimal thanhTien = donGia * nudSoLuong.Value;

                    // Cập nhật thông tin
                    string maSuDungDV = dgvSuDungDV.SelectedRows[0].Cells["MaSuDungDV"].Value.ToString();
                    string updateQuery = @"
                        UPDATE SuDungDichVu 
                        SET MaDV = @MaDV, NgaySuDung = @NgaySuDung, SoLuong = @SoLuong, ThanhTien = @ThanhTien
                        WHERE MaSuDungDV = @MaSuDungDV";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@MaSuDungDV", maSuDungDV);
                    updateCmd.Parameters.AddWithValue("@MaDV", cboMaDV.SelectedValue.ToString());
                    updateCmd.Parameters.AddWithValue("@NgaySuDung", dtpNgaySuDung.Value);
                    updateCmd.Parameters.AddWithValue("@SoLuong", (int)nudSoLuong.Value);
                    updateCmd.Parameters.AddWithValue("@ThanhTien", thanhTien);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachSuDungDV();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa dịch vụ
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSuDungDV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string maSuDungDV = dgvSuDungDV.SelectedRows[0].Cells["MaSuDungDV"].Value.ToString();
                        string deleteQuery = "DELETE FROM SuDungDichVu WHERE MaSuDungDV = @MaSuDungDV";
                        SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                        deleteCmd.Parameters.AddWithValue("@MaSuDungDV", maSuDungDV);
                        deleteCmd.ExecuteNonQuery();

                        MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachSuDungDV();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thoát form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Xóa dữ liệu nhập
        private void ClearInputs()
        {
            cboMaDV.SelectedIndex = -1;
            dtpNgaySuDung.Value = DateTime.Today;
            nudSoLuong.Value = 1;
        }

        private void dgvSuDungDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvSuDungDV.Rows[e.RowIndex];
                    cboMaDV.SelectedValue = row.Cells["MaDV"].Value.ToString();
                    dtpNgaySuDung.Value = Convert.ToDateTime(row.Cells["NgaySuDung"].Value);
                    nudSoLuong.Value = Convert.ToInt32(row.Cells["SoLuong"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuDungDV_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMaDV.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (nudSoLuong.Value <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string getDonGiaQuery = "SELECT DonGia FROM DichVu WHERE MaDV = @MaDV";
                    SqlCommand cmdDonGia = new SqlCommand(getDonGiaQuery, conn);
                    cmdDonGia.Parameters.AddWithValue("@MaDV", cboMaDV.SelectedValue.ToString());
                    decimal donGia = (decimal)cmdDonGia.ExecuteScalar();
                    decimal thanhTien = donGia * nudSoLuong.Value;

                    string insertQuery = @"
                        INSERT INTO SuDungDichVu (MaDatPhong, MaDV, NgaySuDung, SoLuong, ThanhTien)
                        VALUES (@MaDatPhong, @MaDV, @NgaySuDung, @SoLuong, @ThanhTien)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);
                    insertCmd.Parameters.AddWithValue("@MaDV", cboMaDV.SelectedValue.ToString());
                    insertCmd.Parameters.AddWithValue("@NgaySuDung", dtpNgaySuDung.Value);
                    insertCmd.Parameters.AddWithValue("@SoLuong", (int)nudSoLuong.Value);
                    insertCmd.Parameters.AddWithValue("@ThanhTien", thanhTien);
                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Sử dụng dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachSuDungDV();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sử dụng dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
