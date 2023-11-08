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
    public partial class frmGioHang : Form
    {
        public frmGioHang()
        {
            InitializeComponent();
        }
        public void AddItemToGioHang(string tensanpham, int soluong, float dongia, float thanhtien)
        {
            ListViewItem item = new ListViewItem(tensanpham);
            item.SubItems.Add(soluong.ToString());
            item.SubItems.Add(dongia.ToString());
            item.SubItems.Add(thanhtien.ToString());

            listView1.Items.Add(item);
        }


    }
}
