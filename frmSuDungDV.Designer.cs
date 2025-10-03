namespace _223277_DoanVinhHung
{
    partial class frmSuDungDV
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
            this.btnSuDungDV = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvSuDungDV = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgaySuDung = new System.Windows.Forms.DateTimePicker();
            this.lblDatPhongInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMaDV = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuDungDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSuDungDV
            // 
            this.btnSuDungDV.Location = new System.Drawing.Point(802, 215);
            this.btnSuDungDV.Name = "btnSuDungDV";
            this.btnSuDungDV.Size = new System.Drawing.Size(178, 29);
            this.btnSuDungDV.TabIndex = 29;
            this.btnSuDungDV.Text = "Sử Dụng Dịch Vụ";
            this.btnSuDungDV.UseVisualStyleBackColor = true;
            this.btnSuDungDV.Click += new System.EventHandler(this.btnSuDungDV_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(896, 533);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(84, 29);
            this.btnThoat.TabIndex = 28;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(686, 215);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(84, 29);
            this.btnXoa.TabIndex = 27;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(596, 215);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(84, 29);
            this.btnSua.TabIndex = 26;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(506, 215);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(84, 29);
            this.btnThem.TabIndex = 25;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // dgvSuDungDV
            // 
            this.dgvSuDungDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuDungDV.Location = new System.Drawing.Point(168, 250);
            this.dgvSuDungDV.Name = "dgvSuDungDV";
            this.dgvSuDungDV.RowHeadersWidth = 51;
            this.dgvSuDungDV.RowTemplate.Height = 24;
            this.dgvSuDungDV.Size = new System.Drawing.Size(812, 277);
            this.dgvSuDungDV.TabIndex = 24;
            this.dgvSuDungDV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuDungDV_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(294, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Nhập SL";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(297, 215);
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(120, 22);
            this.nudSoLuong.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(458, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Chọn Ngày Sử Dụng";
            // 
            // dtpNgaySuDung
            // 
            this.dtpNgaySuDung.Location = new System.Drawing.Point(461, 161);
            this.dtpNgaySuDung.Name = "dtpNgaySuDung";
            this.dtpNgaySuDung.Size = new System.Drawing.Size(200, 22);
            this.dtpNgaySuDung.TabIndex = 20;
            // 
            // lblDatPhongInfo
            // 
            this.lblDatPhongInfo.AutoSize = true;
            this.lblDatPhongInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatPhongInfo.Location = new System.Drawing.Point(457, 94);
            this.lblDatPhongInfo.Name = "lblDatPhongInfo";
            this.lblDatPhongInfo.Size = new System.Drawing.Size(176, 22);
            this.lblDatPhongInfo.TabIndex = 19;
            this.lblDatPhongInfo.Text = "Thông tin Đặt Phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Chọn Dịch Vụ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(489, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 29);
            this.label1.TabIndex = 17;
            this.label1.Text = "DỊCH VỤ";
            // 
            // cboMaDV
            // 
            this.cboMaDV.FormattingEnabled = true;
            this.cboMaDV.Location = new System.Drawing.Point(297, 159);
            this.cboMaDV.Name = "cboMaDV";
            this.cboMaDV.Size = new System.Drawing.Size(121, 24);
            this.cboMaDV.TabIndex = 16;
            // 
            // frmSuDungDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 606);
            this.Controls.Add(this.btnSuDungDV);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvSuDungDV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudSoLuong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpNgaySuDung);
            this.Controls.Add(this.lblDatPhongInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMaDV);
            this.Name = "frmSuDungDV";
            this.Text = "frmSuDungDV";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuDungDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSuDungDV;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvSuDungDV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgaySuDung;
        private System.Windows.Forms.Label lblDatPhongInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMaDV;
    }
}