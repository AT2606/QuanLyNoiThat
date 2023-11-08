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
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors.TextEditController.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace QLCHbanOTO
{
    public partial class frmBangThongKe : Form
    {
        public frmBangThongKe()
        {
            InitializeComponent();
        }

        // Bảng thống kê số lượng xe bán
        private void frmBangThongKe_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            dateStart.Value = DateTime.Now;
            dateEnd.Value = DateTime.Now;
        }
       
        private void UpdateChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QlNThat;Integrated Security=True"))
                {
                    conn.Open();
                    DataTable dt = new DataTable();

                    // Thay đổi câu truy vấn SQL để lấy dữ liệu dựa trên khoảng ngày
                    string query = "SELECT loaiSanPham, SUM(soLuong) as TotalSoLuong FROM khachHang " +
                                    $"WHERE ngayDatHang >= '{startDate}' AND ngayDatHang <= '{endDate}' " +
                                    "GROUP BY loaiSanPham";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                    sqlDataAdapter.Fill(dt);

                    // Xóa các điểm cũ trong biểu đồ
                    chart1.Series["SoLuong"].Points.Clear();

                    chart1.ChartAreas["ChartArea1"].AxisX.Title = "Loại Sản Phẩm";
                    chart1.ChartAreas["ChartArea1"].AxisY.Title = "Số lượng";
                    chart1.Series["SoLuong"]["DrawingStyle"] = "cylinder";
                    chart1.ChartAreas["ChartArea1"].AxisY.Interval = 1;
                    chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;

                    // Cập nhật biểu đồ với dữ liệu mới
                    foreach (DataRow row in dt.Rows)
                    {
                        chart1.Series["SoLuong"].Points.AddXY(row["loaiSanPham"], row["TotalSoLuong"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo biểu đồ: " + ex.Message);
            }
        }
        private void LoadDataGridView()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QlNThat;Integrated Security=True"))
                {
                    cnn.Open();
                    string sql = "SELECT loaiSanPham, soLuong, donGia, thanhTien,ngayDatHang FROM khachHang";


                    SqlCommand com = new SqlCommand(sql, cnn);
                    com.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cnn.Close();
                    dataGridView1.DataSource = dt;
                    int totalSoLuong = 0;
                    decimal totalThanhTien = 0;

                    // Duyệt qua các dòng trong DataTable và tính tổng số lượng và tổng thành tiền
                    foreach (DataRow row in dt.Rows)
                    {
                        totalSoLuong += Convert.ToInt32(row["soLuong"]);
                        totalThanhTien += Convert.ToDecimal(row["thanhTien"]);
                    }

                    // Hiển thị tổng số lượng và tổng thành tiền trên các TextBox
                    textBox1.Text = totalSoLuong.ToString();
                    textBox2.Text = totalThanhTien.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu vào DataGridView: " + ex.Message);
            }
        }

        private void btntim_Click_1(object sender, EventArgs e)
        {
            DateTime startDate = dateStart.Value.Date;
            DateTime endDate = dateEnd.Value.Date.AddSeconds(86399); // Kết thúc vào 00:00:00 của ngày tiếp theo

            if (endDate >= startDate)
            {
                DataView dv = ((DataTable)dataGridView1.DataSource).DefaultView;
                dv.RowFilter = $"ngayDatHang >= #{startDate}# AND ngayDatHang <= #{endDate}#";

                // Sau khi lọc dữ liệu, tính lại tổng số lượng và tổng thành tiền
                int totalSoLuong = 0;
                decimal totalThanhTien = 0;

                foreach (DataRowView rowView in dv)
                {
                    DataRow row = rowView.Row;
                    totalSoLuong += Convert.ToInt32(row["soLuong"]);
                    totalThanhTien += Convert.ToDecimal(row["thanhTien"]);
                }

                // Cập nhật TextBoxs hiển thị tổng số lượng và tổng thành tiền
                textBox1.Text = totalSoLuong.ToString();
                textBox2.Text = totalThanhTien.ToString("N2");

                // Sau khi tính toán tổng số lượng và tổng thành tiền, cập nhật biểu đồ
                UpdateChart(startDate, endDate);
            }
            else
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


