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
    public partial class frmDatPhong : Form
    {
        string connectionString = "Data Source=LAPTOP-OD073M13\\MAY1;Initial Catalog=QuanLyKhachSan;Integrated Security=True";

        public frmDatPhong()
        {
            InitializeComponent();
            LoadDanhSachDatPhong();
            LoadComboBoxPhong();
            LoadComboBoxKhachHang();
            LoadComboBoxLoaiPhongTim();

            // Gắn sự kiện thủ công
            btnDatPhong.Click += new EventHandler(btnDatPhong_Click);
            btnNhanPhong.Click += new EventHandler(btnNhanPhong_Click);
            btnTraPhong.Click += new EventHandler(btnTraPhong_Click);
            btnTaiLai.Click += new EventHandler(btnTaiLai_Click);
            btnThoat.Click += new EventHandler(btnThoat_Click);
            btnTimPhong.Click += new EventHandler(btnTimPhong_Click);
            dgvDatPhong.CellClick += new DataGridViewCellEventHandler(dgvDatPhong_CellClick);
            btnChuyenQuaDV.Click += new EventHandler(btnChuyenQuaDV_Click);
            cboMaPhong.SelectedIndexChanged += new EventHandler(cboMaPhong_SelectedIndexChanged);
            cboMaKH.SelectedIndexChanged += new EventHandler(cboMaKH_SelectedIndexChanged);
        }

        // Load danh sách đặt phòng
        private void LoadDanhSachDatPhong()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT dp.MaDatPhong, dp.MaPhong, lp.TenLoaiPhong, dp.MaKH, kh.HoTen, 
                               dp.NgayDen, dp.NgayDi, dp.SoNguoi, dp.TrangThaiDatPhong
                        FROM DatPhong dp
                        INNER JOIN Phong p ON dp.MaPhong = p.MaPhong
                        INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                        INNER JOIN KhachHang kh ON dp.MaKH = kh.MaKH";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDatPhong.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách đặt phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách phòng vào ComboBox
        private void LoadComboBoxPhong()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaPhong, TrangThai FROM Phong";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboMaPhong.DataSource = dt;
                    cboMaPhong.DisplayMember = "MaPhong"; // Hiển thị MaPhong (có thể tùy chỉnh để thêm TrangThai)
                    cboMaPhong.ValueMember = "MaPhong";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách khách hàng vào ComboBox
        private void LoadComboBoxKhachHang()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaKH, HoTen FROM KhachHang";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboMaKH.DataSource = dt;
                    cboMaKH.DisplayMember = "HoTen";
                    cboMaKH.ValueMember = "MaKH";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách loại phòng để tìm kiếm
        private void LoadComboBoxLoaiPhongTim()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaLoaiPhong, TenLoaiPhong FROM LoaiPhong";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DataRow dr = dt.NewRow();
                    dr["MaLoaiPhong"] = "";
                    dr["TenLoaiPhong"] = "--Tất cả--";
                    dt.Rows.InsertAt(dr, 0);
                    cboLoaiPhongTim.DataSource = dt;
                    cboLoaiPhongTim.DisplayMember = "TenLoaiPhong";
                    cboLoaiPhongTim.ValueMember = "MaLoaiPhong";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load loại phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hiển thị thông tin phòng khi chọn
        private void cboMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaPhong.SelectedValue != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = @"
                            SELECT lp.TenLoaiPhong, lp.DonGia, p.TrangThai 
                            FROM Phong p
                            INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                            WHERE p.MaPhong = @MaPhong";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaPhong", cboMaPhong.SelectedValue.ToString());
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            lblPhongInfo.Text = $"{reader["TenLoaiPhong"]} - {reader["DonGia"]:N0} VNĐ - {reader["TrangThai"]}";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load thông tin phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hiển thị thông tin khách hàng khi chọn
        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaKH.SelectedValue != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT HoTen, CCCD FROM KhachHang WHERE MaKH = @MaKH";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaKH", cboMaKH.SelectedValue.ToString());
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            lblKHInfo.Text = $"{reader["HoTen"]} - {reader["CCCD"]}";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load thông tin khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Đặt phòng
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMaPhong.SelectedIndex == -1 || cboMaKH.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn phòng và khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dtpNgayDen.Value < DateTime.Today)
                {
                    MessageBox.Show("Ngày đến phải từ hôm nay trở đi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dtpNgayDi.Value <= dtpNgayDen.Value)
                {
                    MessageBox.Show("Ngày đi phải sau ngày đến!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtSoNguoi.Value <= 0)
                {
                    MessageBox.Show("Số người phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Kiểm tra trạng thái phòng
                    string checkQuery = "SELECT TrangThai FROM Phong WHERE MaPhong = @MaPhong";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@MaPhong", cboMaPhong.SelectedValue.ToString());
                    string trangThai = checkCmd.ExecuteScalar()?.ToString();
                    if (trangThai != "Trống" && trangThai != "Đặt trước")
                    {
                        MessageBox.Show("Phòng phải ở trạng thái 'Trống' hoặc 'Đặt trước' để đặt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Thêm đặt phòng
                    string insertQuery = @"
                        INSERT INTO DatPhong (MaPhong, MaKH, NgayDen, NgayDi, SoNguoi, TrangThaiDatPhong)
                        VALUES (@MaPhong, @MaKH, @NgayDen, @NgayDi, @SoNguoi, N'Đã đặt')";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@MaPhong", cboMaPhong.SelectedValue.ToString());
                    insertCmd.Parameters.AddWithValue("@MaKH", cboMaKH.SelectedValue.ToString());
                    insertCmd.Parameters.AddWithValue("@NgayDen", dtpNgayDen.Value);
                    insertCmd.Parameters.AddWithValue("@NgayDi", dtpNgayDi.Value);
                    insertCmd.Parameters.AddWithValue("@SoNguoi", (int)txtSoNguoi.Value);
                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDatPhong();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đặt phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nhận phòng
        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatPhong.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn đơn đặt phòng để nhận!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string maDatPhong = dgvDatPhong.SelectedRows[0].Cells["MaDatPhong"].Value.ToString();
                string trangThaiDatPhong = dgvDatPhong.SelectedRows[0].Cells["TrangThaiDatPhong"].Value.ToString();
                if (trangThaiDatPhong != "Đã đặt")
                {
                    MessageBox.Show("Chỉ có thể nhận phòng với trạng thái 'Đã đặt'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Cập nhật trạng thái đặt phòng
                    string updateDatPhong = "UPDATE DatPhong SET TrangThaiDatPhong = N'Đã nhận' WHERE MaDatPhong = @MaDatPhong";
                    SqlCommand cmd1 = new SqlCommand(updateDatPhong, conn);
                    cmd1.Parameters.AddWithValue("@MaDatPhong", maDatPhong);
                    cmd1.ExecuteNonQuery();

                    // Cập nhật trạng thái phòng
                    string maPhong = dgvDatPhong.SelectedRows[0].Cells["MaPhong"].Value.ToString();
                    string updatePhong = "UPDATE Phong SET TrangThai = N'Đang ở' WHERE MaPhong = @MaPhong";
                    SqlCommand cmd2 = new SqlCommand(updatePhong, conn);
                    cmd2.Parameters.AddWithValue("@MaPhong", maPhong);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Nhận phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDatPhong();
                    LoadComboBoxPhong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhận phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Trả phòng
        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatPhong.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn đơn đặt phòng để trả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string maDatPhong = dgvDatPhong.SelectedRows[0].Cells["MaDatPhong"].Value.ToString();
                string trangThaiDatPhong = dgvDatPhong.SelectedRows[0].Cells["TrangThaiDatPhong"].Value.ToString();
                if (trangThaiDatPhong != "Đã nhận")
                {
                    MessageBox.Show("Chỉ có thể trả phòng với trạng thái 'Đã nhận'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Cập nhật trạng thái đặt phòng
                    string updateDatPhong = "UPDATE DatPhong SET TrangThaiDatPhong = N'Đã trả' WHERE MaDatPhong = @MaDatPhong";
                    SqlCommand cmd1 = new SqlCommand(updateDatPhong, conn);
                    cmd1.Parameters.AddWithValue("@MaDatPhong", maDatPhong);
                    cmd1.ExecuteNonQuery();

                    // Cập nhật trạng thái phòng
                    string maPhong = dgvDatPhong.SelectedRows[0].Cells["MaPhong"].Value.ToString();
                    string updatePhong = "UPDATE Phong SET TrangThai = N'Trống' WHERE MaPhong = @MaPhong";
                    SqlCommand cmd2 = new SqlCommand(updatePhong, conn);
                    cmd2.Parameters.AddWithValue("@MaPhong", maPhong);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Trả phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDatPhong();
                    LoadComboBoxPhong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trả phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tìm phòng trống
        private void btnTimPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpNgayDiTim.Value <= dtpNgayDenTim.Value)
                {
                    MessageBox.Show("Ngày đi phải sau ngày đến!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT p.MaPhong, lp.TenLoaiPhong, p.TrangThai
                        FROM Phong p
                        INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                        WHERE (p.TrangThai = N'Trống'
                            OR (p.TrangThai = N'Đặt trước' 
                                AND NOT EXISTS (
                                    SELECT 1 FROM DatPhong dp
                                    WHERE dp.MaPhong = p.MaPhong
                                    AND dp.TrangThaiDatPhong NOT IN (N'Đã trả', N'Đã hủy')
                                    AND (dp.NgayDen <= @NgayDiTim AND dp.NgayDi >= @NgayDenTim)
                                )
                            ))
                        AND (@MaLoaiPhong = '' OR p.MaLoaiPhong = @MaLoaiPhong)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NgayDenTim", dtpNgayDenTim.Value);
                    cmd.Parameters.AddWithValue("@NgayDiTim", dtpNgayDiTim.Value);
                    cmd.Parameters.AddWithValue("@MaLoaiPhong", cboLoaiPhongTim.SelectedValue.ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPhongTrong.DataSource = dt;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("Không tìm thấy phòng trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tải lại
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDanhSachDatPhong();
            LoadComboBoxPhong();
            LoadComboBoxKhachHang();
            ClearInputs();
        }

        // Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Xóa dữ liệu nhập
        private void ClearInputs()
        {
            cboMaPhong.SelectedIndex = -1;
            cboMaKH.SelectedIndex = -1;
            lblPhongInfo.Text = "";
            lblKHInfo.Text = "";
            dtpNgayDen.Value = DateTime.Today;
            dtpNgayDi.Value = DateTime.Today.AddDays(1);
            txtSoNguoi.Value = 1;
        }

        // Chọn đơn đặt phòng
        private void dgvDatPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDatPhong.Rows[e.RowIndex];
                cboMaPhong.SelectedValue = row.Cells["MaPhong"].Value.ToString();
                cboMaKH.SelectedValue = row.Cells["MaKH"].Value.ToString();
                dtpNgayDen.Value = Convert.ToDateTime(row.Cells["NgayDen"].Value);
                dtpNgayDi.Value = Convert.ToDateTime(row.Cells["NgayDi"].Value);
                txtSoNguoi.Value = Convert.ToInt32(row.Cells["SoNguoi"].Value);
            }
        }

        private void btnChuyenQuaDV_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn trong dgvDatPhong không
                if (dgvDatPhong.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn đơn đặt phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy maDatPhong từ dòng được chọn
                int maDatPhong = Convert.ToInt32(dgvDatPhong.SelectedRows[0].Cells["MaDatPhong"].Value);

                // Khởi tạo frmSuDungDV với tham số maDatPhong
                frmSuDungDV sudungDVForm = new frmSuDungDV(maDatPhong);
                sudungDVForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở form sử dụng dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}