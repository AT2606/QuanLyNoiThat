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
using System.Data;

namespace QLCHNoiThat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QlNThat;Integrated Security=True");
            string tk = txttk.Text;
            string mk = txtmk.Text;
            string quyen = "";
            try
            {
                conn.Open();
                string sql = "select taiKhoan,matKhau,Quyen from TaiKhoan where taiKhoan = @tk and matKhau = @mk ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tk", tk);
                cmd.Parameters.AddWithValue("@mk", mk);
                cmd.Parameters.AddWithValue("Quyen", quyen);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    quyen = rdr["Quyen"].ToString(); // Get the user's role/permission from the database.

                    if (quyen == "admin")
                    {
                        MessageBox.Show("Bạn Đang đăng nhập với tài khoản Admin");

                        Form2 form2 = new Form2();
                        
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        Form2 form2 = new Form2();
                        form2.GetMenuStrip1().Visible = false;
                        form2.Show();
                        this.Hide();
                    }
                }

            }

            catch(Exception ex) 
            {
                MessageBox.Show("LỖi Kết Nối"+ ex.Message);
            }
            finally { conn.Close(); }
        }
    }
}
