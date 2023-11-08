using DevExpress.Xpo.DB.Helpers;
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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QlNThat;Integrated Security=True");
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select maKhachHang,hoTen,diaChi,gioiTinh,SDT,loaiSanPham,soLuong,donGia,thanhTien,FORMAT(ngayDatHang, 'dd/MM/yyyy HH:mm:ss') as ngayDatHang from khachHang";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["MaKhachHang"].ToString());
                item.SubItems.Add(reader["HoTen"].ToString());
                item.SubItems.Add(reader["DiaChi"].ToString());
                item.SubItems.Add(reader["GioiTinh"].ToString());
                item.SubItems.Add(reader["SDT"].ToString());
                item.SubItems.Add(reader["LoaiSanPham"].ToString());
                item.SubItems.Add(reader["SoLuong"].ToString());
                item.SubItems.Add(reader["DonGia"].ToString());
                item.SubItems.Add(reader["ThanhTien"].ToString());
                item.SubItems.Add(reader["NgayDatHang"].ToString());

                listView1.Items.Add(item);


            }
            reader.Close();
            conn.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];


                txtmakhachhang.Text = selectedItem.SubItems[0].Text;
                txthoten.Text = selectedItem.SubItems[1].Text;
                txtdc.Text = selectedItem.SubItems[2].Text;
                txtgt.Text = selectedItem.SubItems[3].Text;
                txtsdt.Text = selectedItem.SubItems[4].Text;
                txtsanpham.Text = selectedItem.SubItems[5].Text;
                txtSL.Text = selectedItem.SubItems[6].Text;
                txtdongia.Text = selectedItem.SubItems[7].Text;
                txtthanhtien.Text = selectedItem.SubItems[8].Text;
                txtngaydathang.Text = selectedItem.SubItems[9].Text;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO KhachHang (hoTen, diaChi, gioiTinh, SDT, loaiSanPham, soLuong, donGia, thanhTien, ngayDatHang) " +
                           "VALUES (@hoTen, @diaChi, @gioiTinh, @SDT, @loaiSanPham, @soLuong, @donGia, @thanhTien, @ngayDatHang)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@hoTen", txthoten.Text);
                cmd.Parameters.AddWithValue("@diaChi", txtdc.Text);
                cmd.Parameters.AddWithValue("@gioiTinh", txtgt.Text);
                cmd.Parameters.AddWithValue("@SDT", txtsdt.Text);
                cmd.Parameters.AddWithValue("@loaiSanPham", txtsanpham.Text);
                cmd.Parameters.AddWithValue("@soLuong", txtSL.Text);
                cmd.Parameters.AddWithValue("@donGia", txtdongia.Text);
                cmd.Parameters.AddWithValue("@thanhTien", txtthanhtien.Text);
                cmd.Parameters.AddWithValue("@ngayDatHang", txtngaydathang.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            
            frmKhachHang_Load(sender, e);
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedMaKhachHang = listView1.SelectedItems[0].SubItems[0].Text;

                string query = "UPDATE KhachHang SET hoTen = @hoTen, diaChi = @diaChi, gioiTinh = @gioiTinh, SDT = @SDT, loaiSanPham = @loaiSanPham, " +
                               "soLuong = @soLuong, donGia = @donGia, thanhTien = @thanhTien, ngayDatHang = @ngayDatHang " +
                               "WHERE maKhachHang = @maKhachHang";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@hoTen", txthoten.Text);
                    cmd.Parameters.AddWithValue("@diaChi", txtdc.Text);
                    cmd.Parameters.AddWithValue("@gioiTinh", txtgt.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtsdt.Text);
                    cmd.Parameters.AddWithValue("@loaiSanPham", txtsanpham.Text);
                    cmd.Parameters.AddWithValue("@soLuong", txtSL.Text);
                    cmd.Parameters.AddWithValue("@donGia", txtdongia.Text);
                    cmd.Parameters.AddWithValue("@thanhTien", txtthanhtien.Text);
                    cmd.Parameters.AddWithValue("@ngayDatHang", txtngaydathang.Text);
                    cmd.Parameters.AddWithValue("@maKhachHang", selectedMaKhachHang);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                
                frmKhachHang_Load(sender, e);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedMaKhachHang = listView1.SelectedItems[0].SubItems[0].Text;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM KhachHang WHERE maKhachHang = @maKhachHang";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maKhachHang", selectedMaKhachHang);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    
                    listView1.SelectedItems[0].Remove();
                }
            }
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            txtmakhachhang.Clear();
            txthoten.Clear();
            txtdc.Clear();
            txtgt.Clear();
            txtsdt.Clear();
            txtsanpham.Clear();
            txtSL.Clear();
            txtdongia.Clear();
            txtthanhtien.Clear();
            txtngaydathang.Clear();
        }
    }
}
