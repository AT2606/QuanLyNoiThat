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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLCHNoiThat
{
    public partial class frmNv : Form
    {
        public frmNv()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QlNThat;Integrated Security=True");

        private void frmNv_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select * from NhanVien";
           
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["maNhanVien"].ToString());
                item.SubItems.Add(reader["tenNhanVien"].ToString());
                item.SubItems.Add(reader["diaChi"].ToString());
                item.SubItems.Add(reader["SDT"].ToString());
                item.SubItems.Add(reader["email"].ToString());
                item.SubItems.Add(reader["chucVu"].ToString());

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


                txtmnv.Text = selectedItem.SubItems[0].Text;
                txttnv.Text = selectedItem.SubItems[1].Text;
                txtdc.Text = selectedItem.SubItems[2].Text;
                txtsdt.Text = selectedItem.SubItems[3].Text;
                txtemail.Text = selectedItem.SubItems[4].Text;
                txtcv.Text = selectedItem.SubItems[5].Text;

            }
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            txtmnv.Clear();
            txttnv.Clear();
            txtdc.Clear();
            txtsdt.Clear();
            txtemail.Clear();
            txtcv.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO NhanVien (tenNhanVien, diaChi, SDT, email, chucVu) VALUES (@tenNhanVien, @diaChi, @SDT, @email, @chucVu)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tenNhanVien", txttnv.Text);
                cmd.Parameters.AddWithValue("@diaChi", txtdc.Text);
                cmd.Parameters.AddWithValue("@SDT", txtsdt.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@chucVu", txtcv.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // After adding the data, you can refresh the ListView to display the new record
            frmNv_Load(sender, e);
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedMaNhanVien = listView1.SelectedItems[0].SubItems[0].Text;

                string query = "UPDATE NhanVien SET tenNhanVien = @tenNhanVien, diaChi = @diaChi, SDT = @SDT, email = @email, chucVu = @chucVu WHERE maNhanVien = @maNhanVien";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenNhanVien", txttnv.Text);
                    cmd.Parameters.AddWithValue("@diaChi", txtdc.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtsdt.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@chucVu", txtcv.Text);
                    cmd.Parameters.AddWithValue("@maNhanVien", selectedMaNhanVien);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                // After updating the data, you can refresh the ListView to reflect the changes
                frmNv_Load(sender, e);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedMaNhanVien = listView1.SelectedItems[0].SubItems[0].Text;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM NhanVien WHERE maNhanVien = @maNhanVien";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNhanVien", selectedMaNhanVien);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    // After deleting the data, remove the selected item from the ListView
                    listView1.SelectedItems[0].Remove();
                }
            }
        }

    }
}
