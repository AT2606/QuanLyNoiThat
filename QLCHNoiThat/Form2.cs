using DevExpress.Utils;
using QLCHbanOTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHNoiThat
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       public  MenuStrip GetMenuStrip1() {
       {
                return menuStrip1; 
       }
}
        
        private void btnTT1_Click(object sender, EventArgs e)
        {
            TT1 tt1 = new TT1();
            tt1.Show();
        }

        private void btnTT2_Click(object sender, EventArgs e)
        {
            TT2 tt1 = new TT2();
            tt1.Show();
        }

        private void btnTT3_Click(object sender, EventArgs e)
        {
            TT3 tt1 = new TT3();
            tt1.Show();
        }

        private void btnTT6_Click(object sender, EventArgs e)
        {
            TT6 tt1 = new TT6();
            tt1.Show();
        }

        private void btnTT5_Click(object sender, EventArgs e)
        {
            TT5 tt1 = new TT5();
            tt1.Show();
        }

        private void btnTT4_Click(object sender, EventArgs e)
        {
            TT4 tt1 = new TT4();
            tt1.Show();
        }
        private Form currentform;
        private void openfrm(Form formToOpen)
        {
            if (currentform != null)
            {
                currentform.Close();
            }

            currentform = formToOpen;
            formToOpen.TopLevel = false;
            formToOpen.FormBorderStyle = FormBorderStyle.None;
            formToOpen.Dock = DockStyle.Fill;
            pn_body.Controls.Add(formToOpen);
            pn_body.Size = formToOpen.Size;
            pn_body.Tag = formToOpen;
            formToOpen.BringToFront();
            formToOpen.Show();
        }
        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openfrm(new frmNv());
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openfrm(new frmKhachHang());
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openfrm(new frmncc());
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openfrm(new frmQLTK());
        }

        

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            
                Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();
            
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openfrm(new Form2());
            menuStrip1.Visible = false; 
           


        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openfrm(new frmSP());
           
        }

        private void bảngThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openfrm(new frmBangThongKe());
        }
    }
}
