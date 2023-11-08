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
    public partial class TT4 : Form
    {
        public TT4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatHang datHang = new DatHang();
            datHang.Show();
            this.Hide();
        }
    }
}
