using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHNoiThat
{
    public partial class frmSP : Form
    {
        public frmSP()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QlNThat;Integrated Security=True");
        private string imagePath = "";

        private void frmSP_Load(object sender, EventArgs e)
        {
            LoadSanPhamData();
        }
        private void LoadSanPhamData()
        {
            try
            {
                conn.Open();
                string sql = "SELECT * FROM SanPham";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    string maSanPham = reader["MaSanPham"].ToString();
                    string tenSanPham = reader["TenSanPham"].ToString();
                    decimal giaTien = (decimal)reader["GiaTien"];
                    string moTa = reader["MoTa"].ToString();
                    string hinhAnh = reader["HinhAnh"].ToString();

                    dataGridView1.Rows.Add(maSanPham, tenSanPham, giaTien, moTa, hinhAnh);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        private void btnHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn đến tệp hình ảnh đã chọn
                imagePath = openFileDialog.FileName;

                // Hiển thị hình ảnh đã chọn lên PictureBox
                ptHinhAnh.Image = new Bitmap(imagePath);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                string maSanPham = selectedRow.Cells["MaSanPham"].Value.ToString();
                string tenSanPham = selectedRow.Cells["TenSanPham"].Value.ToString();
                string giaTien = selectedRow.Cells["GiaTien"].Value.ToString();
                string moTa = selectedRow.Cells["MoTa"].Value.ToString();
                imagePath = selectedRow.Cells["HinhAnh"].Value.ToString();

                txtMaSP.Text = maSanPham;
                txtTenSp.Text = tenSanPham;
                txtGiaSP.Text = giaTien;
                txtMoTaSP.Text = moTa;
                ptHinhAnh.Image = new Bitmap(imagePath);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text) || string.IsNullOrEmpty(txtTenSp.Text) || string.IsNullOrEmpty(txtGiaSP.Text) || string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm và chọn hình ảnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();
                string query = "INSERT INTO SanPham (MaSanPham, TenSanPham, GiaTien, MoTa, HinhAnh) VALUES (@MaSanPham, @TenSanPham, @GiaTien, @MoTa, @HinhAnh)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", txtMaSP.Text);
                    cmd.Parameters.AddWithValue("@TenSanPham", txtTenSp.Text);
                    cmd.Parameters.AddWithValue("@GiaTien", txtGiaSP.Text);
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTaSP.Text);
                    cmd.Parameters.AddWithValue("@HinhAnh", imagePath);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Thêm sản phẩm thành công.");
                ClearFields();
                LoadSanPhamData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

        }
        private void ClearFields()
        {
            txtMaSP.Clear();
            txtTenSp.Clear();
            txtGiaSP.Clear();
            txtMoTaSP.Clear();
            ptHinhAnh.Image = null;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();
                string query = "UPDATE SanPham SET TenSanPham = @TenSanPham, GiaTien = @GiaTien, MoTa = @MoTa, HinhAnh = @HinhAnh WHERE MaSanPham = @MaSanPham";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", txtMaSP.Text);
                    cmd.Parameters.AddWithValue("@TenSanPham", txtTenSp.Text);
                    cmd.Parameters.AddWithValue("@GiaTien", txtGiaSP.Text);
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTaSP.Text);
                    cmd.Parameters.AddWithValue("@HinhAnh", imagePath);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Sửa sản phẩm thành công.");
                ClearFields();
                LoadSanPhamData();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM SanPham WHERE MaSanPham = @MaSanPham";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSanPham", txtMaSP.Text);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show("Xóa sản phẩm thành công.");
                    ClearFields();
                    LoadSanPhamData();
                    conn.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {

                    conn.Close();

                }
            }
        }
    }
}
