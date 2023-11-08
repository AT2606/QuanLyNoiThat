namespace QLCHNoiThat
{
    partial class frmSP
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
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.masanpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tensanpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giatien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hinhanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHinhAnh = new System.Windows.Forms.Button();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lb_MaSP = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.lb_GiaSP = new System.Windows.Forms.Label();
            this.txtMoTaSP = new System.Windows.Forms.TextBox();
            this.lb_MotaSP = new System.Windows.Forms.Label();
            this.txtTenSp = new System.Windows.Forms.TextBox();
            this.lb_TenSP = new System.Windows.Forms.Label();
            this.txtGiaSP = new System.Windows.Forms.TextBox();
            this.ptHinhAnh = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.IndianRed;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(266, 639);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(82, 52);
            this.btnXoa.TabIndex = 41;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.IndianRed;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(146, 639);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(82, 52);
            this.btnSua.TabIndex = 40;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.masanpham,
            this.tensanpham,
            this.giatien,
            this.mota,
            this.hinhanh});
            this.dataGridView1.Location = new System.Drawing.Point(354, 325);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1143, 469);
            this.dataGridView1.TabIndex = 39;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // masanpham
            // 
            this.masanpham.HeaderText = "Mã Sản Phẩm";
            this.masanpham.MinimumWidth = 6;
            this.masanpham.Name = "masanpham";
            this.masanpham.ReadOnly = true;
            this.masanpham.Width = 218;
            // 
            // tensanpham
            // 
            this.tensanpham.HeaderText = "Tên Sản Phẩm";
            this.tensanpham.MinimumWidth = 6;
            this.tensanpham.Name = "tensanpham";
            this.tensanpham.ReadOnly = true;
            this.tensanpham.Width = 218;
            // 
            // giatien
            // 
            this.giatien.HeaderText = "Giá Tiền";
            this.giatien.MinimumWidth = 6;
            this.giatien.Name = "giatien";
            this.giatien.ReadOnly = true;
            this.giatien.Width = 218;
            // 
            // mota
            // 
            this.mota.HeaderText = "Mô tả";
            this.mota.MinimumWidth = 6;
            this.mota.Name = "mota";
            this.mota.ReadOnly = true;
            this.mota.Width = 218;
            // 
            // hinhanh
            // 
            this.hinhanh.HeaderText = "Hình Ảnh";
            this.hinhanh.MinimumWidth = 6;
            this.hinhanh.Name = "hinhanh";
            this.hinhanh.ReadOnly = true;
            this.hinhanh.Width = 218;
            // 
            // btnHinhAnh
            // 
            this.btnHinhAnh.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnHinhAnh.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHinhAnh.Location = new System.Drawing.Point(105, 282);
            this.btnHinhAnh.Name = "btnHinhAnh";
            this.btnHinhAnh.Size = new System.Drawing.Size(133, 42);
            this.btnHinhAnh.TabIndex = 37;
            this.btnHinhAnh.Text = "Hình Ảnh";
            this.btnHinhAnh.UseVisualStyleBackColor = false;
            this.btnHinhAnh.Click += new System.EventHandler(this.btnHinhAnh_Click);
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(266, 22);
            this.txtMaSP.Multiline = true;
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(283, 34);
            this.txtMaSP.TabIndex = 35;
            // 
            // lb_MaSP
            // 
            this.lb_MaSP.AutoSize = true;
            this.lb_MaSP.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_MaSP.Location = new System.Drawing.Point(20, 18);
            this.lb_MaSP.Name = "lb_MaSP";
            this.lb_MaSP.Size = new System.Drawing.Size(133, 25);
            this.lb_MaSP.TabIndex = 34;
            this.lb_MaSP.Text = "Mã Sản Phẩm";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.IndianRed;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(25, 639);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(82, 52);
            this.btnThem.TabIndex = 38;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lb_GiaSP
            // 
            this.lb_GiaSP.AutoSize = true;
            this.lb_GiaSP.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_GiaSP.Location = new System.Drawing.Point(20, 194);
            this.lb_GiaSP.Name = "lb_GiaSP";
            this.lb_GiaSP.Size = new System.Drawing.Size(157, 25);
            this.lb_GiaSP.TabIndex = 32;
            this.lb_GiaSP.Text = "Giá Tiền   (Vnd)";
            // 
            // txtMoTaSP
            // 
            this.txtMoTaSP.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTaSP.Location = new System.Drawing.Point(894, 16);
            this.txtMoTaSP.Multiline = true;
            this.txtMoTaSP.Name = "txtMoTaSP";
            this.txtMoTaSP.Size = new System.Drawing.Size(577, 219);
            this.txtMoTaSP.TabIndex = 31;
            // 
            // lb_MotaSP
            // 
            this.lb_MotaSP.AutoSize = true;
            this.lb_MotaSP.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_MotaSP.Location = new System.Drawing.Point(671, 27);
            this.lb_MotaSP.Name = "lb_MotaSP";
            this.lb_MotaSP.Size = new System.Drawing.Size(164, 25);
            this.lb_MotaSP.TabIndex = 30;
            this.lb_MotaSP.Text = "Mô Tả Sản Phẩm";
            // 
            // txtTenSp
            // 
            this.txtTenSp.Location = new System.Drawing.Point(266, 93);
            this.txtTenSp.Multiline = true;
            this.txtTenSp.Name = "txtTenSp";
            this.txtTenSp.Size = new System.Drawing.Size(283, 34);
            this.txtTenSp.TabIndex = 29;
            // 
            // lb_TenSP
            // 
            this.lb_TenSP.AutoSize = true;
            this.lb_TenSP.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenSP.Location = new System.Drawing.Point(20, 102);
            this.lb_TenSP.Name = "lb_TenSP";
            this.lb_TenSP.Size = new System.Drawing.Size(138, 25);
            this.lb_TenSP.TabIndex = 28;
            this.lb_TenSP.Text = "Tên Sản Phẩm";
            // 
            // txtGiaSP
            // 
            this.txtGiaSP.Location = new System.Drawing.Point(266, 171);
            this.txtGiaSP.Multiline = true;
            this.txtGiaSP.Name = "txtGiaSP";
            this.txtGiaSP.Size = new System.Drawing.Size(283, 34);
            this.txtGiaSP.TabIndex = 33;
            // 
            // ptHinhAnh
            // 
            this.ptHinhAnh.Location = new System.Drawing.Point(48, 344);
            this.ptHinhAnh.Name = "ptHinhAnh";
            this.ptHinhAnh.Size = new System.Drawing.Size(259, 192);
            this.ptHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptHinhAnh.TabIndex = 36;
            this.ptHinhAnh.TabStop = false;
            // 
            // frmSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1523, 861);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnHinhAnh);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.lb_MaSP);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.ptHinhAnh);
            this.Controls.Add(this.lb_GiaSP);
            this.Controls.Add(this.txtMoTaSP);
            this.Controls.Add(this.lb_MotaSP);
            this.Controls.Add(this.txtTenSp);
            this.Controls.Add(this.lb_TenSP);
            this.Controls.Add(this.txtGiaSP);
            this.Name = "frmSP";
            this.Text = "frmSP";
            this.Load += new System.EventHandler(this.frmSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptHinhAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnHinhAnh;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lb_MaSP;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.PictureBox ptHinhAnh;
        private System.Windows.Forms.Label lb_GiaSP;
        private System.Windows.Forms.TextBox txtMoTaSP;
        private System.Windows.Forms.Label lb_MotaSP;
        private System.Windows.Forms.TextBox txtTenSp;
        private System.Windows.Forms.Label lb_TenSP;
        private System.Windows.Forms.TextBox txtGiaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn masanpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn tensanpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn giatien;
        private System.Windows.Forms.DataGridViewTextBoxColumn mota;
        private System.Windows.Forms.DataGridViewTextBoxColumn hinhanh;
    }
}