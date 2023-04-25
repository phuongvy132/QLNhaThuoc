using ComponentFactory.Krypton.Toolkit;
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
using QLNhaThuoc_BUS;
using QLNhaThuoc_DTO;
using System.Diagnostics;

namespace QLNhaThuoc
{
    public partial class HoaDon : KryptonForm
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QQPQ8EC;Initial Catalog=QLNhaThuoc;Integrated Security=True");
        DataTable dtHD = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        HoaDon_BUS hdBUS = new HoaDon_BUS();
        HoaDon_DTO hdTO = new HoaDon_DTO();


        private void Hóa_Đơn_Load(object sender, EventArgs e)
        {
            cbTenThuoc.Items.Clear();
            ShowData();
            foreach (DataRow dr in dtHD.Rows)
            {
                cbTenThuoc.Items.Add(dr["TenThuoc"].ToString());
            }
            conn.Close();

            LoadBillNo();
        }

        void ShowData()
        {
            dgv.AutoGenerateColumns = false;
            hdBUS.getHD();
            dgv.DataSource = dtHD;
            conn.Close();
        }

        public void LoadBillNo()
        {
            int a;
            string str = (Properties.Settings.Default.QLNhaThuocConnectionString);
            conn = new SqlConnection(str);
            conn.Open();

            string query = "SELECT MAX(MaHD) FROM HoaDon";
            cmd = new SqlCommand(query, conn);

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    txtBillNo.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    txtBillNo.Text = a.ToString();
                }
                conn.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //int gia = Convert.ToInt32(txtGia.Text);
            //int sl = Convert.ToInt32(txtSL.Text);
            //int Kq = gia * sl;
            //txtThanhTien.Text = Kq.ToString();

            if (cbTenThuoc.Text == "")
                MessageBox.Show("Cần điền tên thuốc!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtGia.Text == "")
                MessageBox.Show("Cần điền giá thuốc!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtSL.Text == "")
                MessageBox.Show("Cần điền số lượng thuốc!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (txtDelUpdate.Text == "")
                {
                    dgv.Rows.Add();
                    int row = dgv.RowCount - 1;
                    dgv["TenThuoc", row].Value = cbTenThuoc.Text;
                    dgv["Gia", row].Value = txtGia.Text;
                    dgv["SoLuong", row].Value = txtSL.Text;
                    dgv["ThanhTien", row].Value = txtThanhTien.Text;
                    dgv["MaHD", row].Value = txtBillNo.Text;

                    //string SQL = string.Format(@"SELECT TenThuoc 
	                   //                         FROM Thuoc
                    //                            ORDER BY TenThuoc ASC");

                    //SqlCommand cmd = new SqlCommand(SQL, conn);
                    //cmd.Parameters.AddWithValue("TenThuoc", cbTenThuoc.Text.Trim());
                    //cmd.Parameters.AddWithValue("GiaBan", txtGia.Text.Trim());
                    //cmd.Parameters.AddWithValue("SoLuong", txtSL.Text.Trim());
                    //cmd.Parameters.AddWithValue("ThanhTien", txtThanhTien.Text);

                    dgv.Refresh();
                    cbTenThuoc.Focus();

                    if (dgv.Rows.Count > 0)
                    {
                        dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[1];
                    }
                }
                else
                {
                    //update rows from GV textbox ̃and affter edit txt to GV
                    int i;
                    i = Convert.ToInt32(txtDelUpdate.Text);
                    DataGridViewRow vrow = dgv.Rows[i - 1];
                    vrow.Cells[1].Value = cbTenThuoc.Text;
                    vrow.Cells[2].Value = txtGia.Text;
                    vrow.Cells[3].Value = txtSL.Text;
                    vrow.Cells[4].Value = txtThanhTien.Text;

                    btnThem.Text = "Thêm";
                }
            }
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgv.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
