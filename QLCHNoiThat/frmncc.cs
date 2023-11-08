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
    public partial class frmncc : Form
    {
        public frmncc()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QlNThat;Integrated Security=True");
        private void frmncc_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select * from NhaCungCap";
                               
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["maNhaCungCap"].ToString());
                item.SubItems.Add(reader["tenNhaCungCap"].ToString());
                item.SubItems.Add(reader["diaChi"].ToString());
                item.SubItems.Add(reader["soDienThoai"].ToString());
                item.SubItems.Add(reader["email"].ToString());
                item.SubItems.Add(reader["sanPham"].ToString());


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


                txtidncc.Text = selectedItem.SubItems[0].Text;
                txttncc.Text = selectedItem.SubItems[1].Text;
                txtdc.Text = selectedItem.SubItems[2].Text;
                txtsdt.Text = selectedItem.SubItems[3].Text;
                txtemail.Text = selectedItem.SubItems[4].Text;
                txtsp.Text = selectedItem.SubItems[5].Text;
                
            }
        }

       
            private void button1_Click(object sender, EventArgs e)
            {
                string query = "INSERT INTO NhaCungCap (tenNhaCungCap, diaChi, soDienThoai, email, sanPham) VALUES (@tenNhaCungCap, @diaChi, @soDienThoai, @email, @sanPham)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenNhaCungCap", txttncc.Text);
                    cmd.Parameters.AddWithValue("@diaChi", txtdc.Text);
                    cmd.Parameters.AddWithValue("@soDienThoai", txtsdt.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@sanPham", txtsp.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                // After adding the data, you can refresh the ListView to display the new record
                frmncc_Load(sender, e);
            }

        

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedMaNhaCungCap = listView1.SelectedItems[0].SubItems[0].Text;

                string query = "UPDATE NhaCungCap SET tenNhaCungCap = @tenNhaCungCap, diaChi = @diaChi, soDienThoai = @soDienThoai, email = @email, sanPham = @sanPham WHERE maNhaCungCap = @maNhaCungCap";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenNhaCungCap", txttncc.Text);
                    cmd.Parameters.AddWithValue("@diaChi", txtdc.Text);
                    cmd.Parameters.AddWithValue("@soDienThoai", txtsdt.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@sanPham", txtsp.Text);
                    cmd.Parameters.AddWithValue("@maNhaCungCap", selectedMaNhaCungCap);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                // After updating the data, you can refresh the ListView to reflect the changes
                frmncc_Load(sender, e);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedMaNhaCungCap = listView1.SelectedItems[0].SubItems[0].Text;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM NhaCungCap WHERE maNhaCungCap = @maNhaCungCap";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNhaCungCap", selectedMaNhaCungCap);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    // After deleting the data, remove the selected item from the ListView
                    listView1.SelectedItems[0].Remove();
                }
            }
        }


        private void btnBoChon_Click(object sender, EventArgs e)
        {
            txtidncc.Clear();
            txttncc.Clear();
            txtdc.Clear();
            txtsdt.Clear();
            txtemail.Clear();
            txtsp.Clear();
        }
    }
}
