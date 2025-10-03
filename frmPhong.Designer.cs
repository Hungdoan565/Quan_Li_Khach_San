namespace _223277_DoanVinhHung
{
    partial class frmPhong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.cboMaLoaiPhong = new System.Windows.Forms.ComboBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.btnThemPhong = new System.Windows.Forms.Button();
            this.btnSuaPhong = new System.Windows.Forms.Button();
            this.btnXoaPhong = new System.Windows.Forms.Button();
            this.btnTaiLaiPhong = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnChuyen = new System.Windows.Forms.Button();
            this.btnChuyenQuaDatPhong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(430, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại Phòng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(678, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Trạng Thái";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(470, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "PHÒNG";
            // 
            // dgvPhong
            // 
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhong.Location = new System.Drawing.Point(132, 137);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.RowHeadersWidth = 51;
            this.dgvPhong.RowTemplate.Height = 24;
            this.dgvPhong.Size = new System.Drawing.Size(766, 244);
            this.dgvPhong.TabIndex = 4;
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(228, 92);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(185, 22);
            this.txtMaPhong.TabIndex = 5;
            // 
            // cboMaLoaiPhong
            // 
            this.cboMaLoaiPhong.FormattingEnabled = true;
            this.cboMaLoaiPhong.Location = new System.Drawing.Point(529, 91);
            this.cboMaLoaiPhong.Name = "cboMaLoaiPhong";
            this.cboMaLoaiPhong.Size = new System.Drawing.Size(121, 24);
            this.cboMaLoaiPhong.TabIndex = 6;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(777, 92);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(121, 24);
            this.cboTrangThai.TabIndex = 7;
            // 
            // btnThemPhong
            // 
            this.btnThemPhong.Location = new System.Drawing.Point(132, 387);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(84, 29);
            this.btnThemPhong.TabIndex = 8;
            this.btnThemPhong.Text = "Thêm";
            this.btnThemPhong.UseVisualStyleBackColor = true;
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // btnSuaPhong
            // 
            this.btnSuaPhong.Location = new System.Drawing.Point(222, 387);
            this.btnSuaPhong.Name = "btnSuaPhong";
            this.btnSuaPhong.Size = new System.Drawing.Size(84, 29);
            this.btnSuaPhong.TabIndex = 9;
            this.btnSuaPhong.Text = "Sửa";
            this.btnSuaPhong.UseVisualStyleBackColor = true;
            // 
            // btnXoaPhong
            // 
            this.btnXoaPhong.Location = new System.Drawing.Point(312, 387);
            this.btnXoaPhong.Name = "btnXoaPhong";
            this.btnXoaPhong.Size = new System.Drawing.Size(84, 29);
            this.btnXoaPhong.TabIndex = 10;
            this.btnXoaPhong.Text = "Xóa";
            this.btnXoaPhong.UseVisualStyleBackColor = true;
            // 
            // btnTaiLaiPhong
            // 
            this.btnTaiLaiPhong.Location = new System.Drawing.Point(402, 387);
            this.btnTaiLaiPhong.Name = "btnTaiLaiPhong";
            this.btnTaiLaiPhong.Size = new System.Drawing.Size(84, 29);
            this.btnTaiLaiPhong.TabIndex = 11;
            this.btnTaiLaiPhong.Text = "Tải Lại";
            this.btnTaiLaiPhong.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(814, 387);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(84, 29);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnChuyen
            // 
            this.btnChuyen.BackColor = System.Drawing.Color.PeachPuff;
            this.btnChuyen.Location = new System.Drawing.Point(514, 442);
            this.btnChuyen.Name = "btnChuyen";
            this.btnChuyen.Size = new System.Drawing.Size(278, 43);
            this.btnChuyen.TabIndex = 13;
            this.btnChuyen.Text = "Chuyển qua Khách Hàng";
            this.btnChuyen.UseVisualStyleBackColor = false;
            this.btnChuyen.Click += new System.EventHandler(this.btnChuyen_Click);
            // 
            // btnChuyenQuaDatPhong
            // 
            this.btnChuyenQuaDatPhong.BackColor = System.Drawing.Color.PeachPuff;
            this.btnChuyenQuaDatPhong.Location = new System.Drawing.Point(230, 442);
            this.btnChuyenQuaDatPhong.Name = "btnChuyenQuaDatPhong";
            this.btnChuyenQuaDatPhong.Size = new System.Drawing.Size(278, 43);
            this.btnChuyenQuaDatPhong.TabIndex = 14;
            this.btnChuyenQuaDatPhong.Text = "Chuyển qua Đặt Phòng";
            this.btnChuyenQuaDatPhong.UseVisualStyleBackColor = false;
            this.btnChuyenQuaDatPhong.Click += new System.EventHandler(this.btnChuyenQuaDatPhong_Click);
            // 
            // frmPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 497);
            this.Controls.Add(this.btnChuyenQuaDatPhong);
            this.Controls.Add(this.btnChuyen);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTaiLaiPhong);
            this.Controls.Add(this.btnXoaPhong);
            this.Controls.Add(this.btnSuaPhong);
            this.Controls.Add(this.btnThemPhong);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.cboMaLoaiPhong);
            this.Controls.Add(this.txtMaPhong);
            this.Controls.Add(this.dgvPhong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmPhong";
            this.Text = "frmPhong";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.ComboBox cboMaLoaiPhong;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnThemPhong;
        private System.Windows.Forms.Button btnSuaPhong;
        private System.Windows.Forms.Button btnXoaPhong;
        private System.Windows.Forms.Button btnTaiLaiPhong;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnChuyen;
        private System.Windows.Forms.Button btnChuyenQuaDatPhong;
    }
}

