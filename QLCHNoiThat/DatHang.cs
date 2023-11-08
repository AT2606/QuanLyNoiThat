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

namespace QLCHNoiThat
{
    public partial class DatHang : Form
    {
        public DatHang()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QlNThat;Integrated Security=True");
        private void btndathang_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string query = "INSERT INTO khachHang (hoTen, diaChi, gioiTinh, SDT, LoaiSanPham, soLuong, ngayDatHang, donGia, thanhTien) " +
                                "VALUES (@hoTen, @diaChi, @gioiTinh, @SDT, @LoaiSanPham, @soLuong, GETDATE(), @donGia, @thanhTien)";

                int DonGia = 0;
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@hoTen", txtten.Text);
                    cmd.Parameters.AddWithValue("@diaChi", txtdc.Text);
                    cmd.Parameters.AddWithValue("@gioiTinh", txtgt.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtsdt.Text);
                    cmd.Parameters.AddWithValue("@LoaiSanPham",comboboxsp.Text);
                    cmd.Parameters.AddWithValue("@soLuong", Convert.ToInt32(txtsl.Text));
                    cmd.Parameters.AddWithValue(@"ngayDatHang", dateTimePicker1.Value);
                    if(comboboxsp.Text == "Bộ Bàn Ghế SoFa") 
                    {
                        DonGia = 2000000;

                    }
                    else if(comboboxsp.Text == "Bàn Làm việc")
                    {
                        DonGia = 2500000;
                    }
                    else if(comboboxsp.Text == "Bàn Ghế Xịn Tiếp Khách")
                    {
                        DonGia = 10000000;
                    }
                    else if (comboboxsp.Text == "bàn Trang Điểm")
                    {
                        DonGia = 2000000;
                    }
                    else if (comboboxsp.Text == "Giường Ngủ")
                    {
                        DonGia = 5000000;
                    }
                    else 
                    {
                        DonGia = 3000000;
                    }
                    cmd.Parameters.AddWithValue("@donGia",DonGia);
                    cmd.Parameters.AddWithValue("@thanhTien", Convert.ToDouble(txtsl.Text) * Convert.ToDouble(DonGia));
                    
                    cmd.ExecuteNonQuery();

                    
                }

                frmGioHang frm = new frmGioHang();

                // Add the data to the ListView in frmGioHang
                frm.AddItemToGioHang(comboboxsp.Text, Convert.ToInt32(txtsl.Text), DonGia, Convert.ToInt32(txtsl.Text) * DonGia);

                MessageBox.Show("Data inserted successfully!");
                frm.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
    
}
