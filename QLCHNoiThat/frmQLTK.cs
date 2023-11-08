using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLCHNoiThat
{
    public partial class frmQLTK : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QlNThat;Integrated Security=True");

        public frmQLTK()
        {
            InitializeComponent();
        }

        private void frmQLTK_Load(object sender, EventArgs e)
        {
            conn.Open();           
            string query = "SELECT * FROM TaiKhoan"; 
            SqlCommand cmd = new SqlCommand(query, conn);           
            SqlDataReader reader = cmd.ExecuteReader();           
            listView1.Items.Clear();           
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["maTaiKhoan"].ToString());
                item.SubItems.Add(reader["tenChuTaiKhoan"].ToString());
                item.SubItems.Add(reader["taiKhoan"].ToString());
                item.SubItems.Add(reader["matKhau"].ToString());
                item.SubItems.Add(reader["Quyen"].ToString());

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
                txtmatk.Text = selectedItem.SubItems[0].Text;
                txttentk.Text = selectedItem.SubItems[1].Text;
                txttaikhoan.Text = selectedItem.SubItems[2].Text;
                txtmatkhau.Text = selectedItem.SubItems[3].Text;
                txtquyen.Text = selectedItem.SubItems[4].Text;
            }
        }
        private void btnBoChon_Click(object sender, EventArgs e)
        {
            txtmatk.Clear();
            txttentk.Clear();
            txttaikhoan.Clear();
            txtquyen.Clear();
            txtmatkhau.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO TaiKhoan (tenChuTaiKhoan, taiKhoan, matKhau, Quyen) VALUES (@tenChuTaiKhoan, @taiKhoan, @matKhau, @Quyen)";

           
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                
                cmd.Parameters.AddWithValue("@tenChuTaiKhoan", txttentk.Text);
                cmd.Parameters.AddWithValue("@taiKhoan", txttaikhoan.Text);
                cmd.Parameters.AddWithValue("@matKhau", txtmatkhau.Text);
                cmd.Parameters.AddWithValue("@Quyen", txtquyen.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }           
            frmQLTK_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                
                string selectedMaTaiKhoan = listView1.SelectedItems[0].SubItems[0].Text;

                string query = "UPDATE TaiKhoan SET tenChuTaiKhoan = @tenChuTaiKhoan, taiKhoan = @taiKhoan, matKhau = @matKhau, Quyen = @Quyen WHERE maTaiKhoan = @maTaiKhoan";

               
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                  
                    cmd.Parameters.AddWithValue("@tenChuTaiKhoan", txttentk.Text);
                    cmd.Parameters.AddWithValue("@taiKhoan", txttaikhoan.Text);
                    cmd.Parameters.AddWithValue("@matKhau", txtmatkhau.Text);
                    cmd.Parameters.AddWithValue("@Quyen", txtquyen.Text);                   
                    cmd.Parameters.AddWithValue("@maTaiKhoan", selectedMaTaiKhoan);                    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                frmQLTK_Load(sender, e); 
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedMaTaiKhoan = listView1.SelectedItems[0].SubItems[0].Text;
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM TaiKhoan WHERE maTaiKhoan = @maTaiKhoan";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maTaiKhoan", selectedMaTaiKhoan);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    listView1.SelectedItems[0].Remove();
                }
            }
        }

    }
}
