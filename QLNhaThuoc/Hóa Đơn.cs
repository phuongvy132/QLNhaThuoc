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
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;

namespace QLNhaThuoc
{
    public partial class HoaDon : KryptonForm
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.QLNhaThuocConnectionString);
        DataTable dtHD = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        HoaDon_BUS hdBUS = new HoaDon_BUS();
        HoaDon_DTO hdDTO = new HoaDon_DTO();
        DuocPham_BUS dpBUS = new DuocPham_BUS();


        private void Hóa_Đơn_Load(object sender, EventArgs e)
        {
            cbTenThuoc.Items.Clear();
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT TenThuoc 
	                            FROM Thuoc
                                ORDER BY TenThuoc ASC";

            cmd.ExecuteNonQuery();
            DataTable dtHD = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            foreach (DataRow dr in dtHD.Rows)
            {
                cbTenThuoc.Items.Add(dr["TenThuoc"].ToString());
            }
            da.Fill(dtHD);
            conn.Close();

            LoadBillNo();
        }

        void ShowData()
        {
            dgv.AutoGenerateColumns = false;
            //dtHD = hdBUS.getHD();
            dgv.DataSource = dtHD;
            conn.Close();
        }
        private void LoadTenThuoc()
        {
            DuocPham_BUS dpBUS = new DuocPham_BUS();
            cbTenThuoc.DataSource = dpBUS.getDP();
            cbTenThuoc.DisplayMember = "TenThuoc";
            cbTenThuoc.ValueMember = "MaThuoc";
        }
        private void addData(HoaDon_DTO hdDTO)
        {
            hdDTO.MaHD = txtBillNo.Text.Trim();
            hdDTO.TenThuoc = cbTenThuoc.SelectedValue.ToString();
            hdDTO.Gia = txtGia.Text.Trim();
            hdDTO.ThoiGian = dtBillDate.Text.Trim();
        }

        private bool checktrung(string mahh)
        {
            for (int i = 0; i < dtHD.Rows.Count; i++)
                if (dtHD.Rows[i][1].ToString() == mahh)
                    return true;
            return false;
        }
        private void capnhatSL(string mahh, int sl)
        {
            for (int i = 0; i < dtHD.Rows.Count; i++)
                if (dtHD.Rows[i][1].ToString() == mahh)
                {
                    int soluong = int.Parse(dtHD.Rows[i][3].ToString()) + sl;
                    dtHD.Rows[i][3] = soluong;
                    double dongia = double.Parse(dtHD.Rows[i][2].ToString());
                    dtHD.Rows[i][4] = (dongia * soluong).ToString();
                    break;
                }
        }
        private bool kiemtraSL(string mahh, int sl)
        {
            DataTable dt = new DataTable();
            dt = dpBUS.getDP("Where MaThuoc = '" + cbTenThuoc.SelectedValue.ToString() + "' and SoLuong>= " + sl);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HoaDon_DTO hdDTO = new HoaDon_DTO();
            hdDTO.TongTienHD = txtTongTien.Text;
            hdDTO.TenThuoc = cbTenThuoc.Text;
            hdDTO.ThoiGian = dtBillDate.Text;

            SqlCommand cmd1 = new SqlCommand("SELECT * FROM HoaDon WHERE TenThuoc = @parm1", conn);
            cmd1.Parameters.AddWithValue("parm1", cbTenThuoc.Text);
            SqlDataReader reader1;

            conn.Open();
            reader1 = cmd1.ExecuteReader();

            if (reader1.Read())
            {
                MessageBox.Show("Mã thuốc đã tồn tại trên hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                conn.Close();
                hdBUS.AddData(hdDTO);

                string SQL = string.Format(@"Insert into HoaDon (ThanhTien, TenThuoc, TongTienHD, SoLuong, ThoiGian) 
                                                    values 
                                                   (N'" + txtThanhTien.Text +
                                                   "',N'" + cbTenThuoc.Text +
                                                   "',N'" + txtTongTien.Text +
                                                   "',N'" + txtSL.Text +
                                                   "',CONVERT(DATE,'" + dtBillDate.Text + "',103))");
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL, conn);
                    cmd1.Parameters.AddWithValue("ThanhTien", txtThanhTien.Text.Trim());
                    //cmd1.Parameters.AddWithValue("MaNhom", cbMaNhom.Text);
                    cmd1.Parameters.AddWithValue("TenThuoc", cbTenThuoc.Text.Trim());
                    cmd1.Parameters.AddWithValue("TongTien", txtTongTien.Text.Trim());
                    cmd1.Parameters.AddWithValue("SoLuong", txtSL.Text.Trim());
                    cmd1.Parameters.AddWithValue("ThoiGian", dtBillDate.Value.ToString("dd/MM/yyyy"));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Thêm Thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            conn.Close();
            ShowData();

        }

        public void LoadBillNo()
        {
            int a;
            string str = ("Data Source=DESKTOP-QQPQ8EC;Initial Catalog=QLNhaThuoc;Integrated Security=True");
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
            LoadTenThuoc();
            dgv.Columns.Clear();
            dtHD.Rows.Clear();
            dtHD.Columns.Clear();
            dtHD.Columns.Add("MaHD");
            dtHD.Columns.Add("HangHoa");
            dtHD.Columns.Add("DonGia");
            dtHD.Columns.Add("SoLuong");
            dtHD.Columns.Add("ThanhTien");

        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgv.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            try
            {
                if (dialogResult == DialogResult.Yes)
                {
                    string SQL = string.Format("DELETE FROM HoaDon WHERE TenThuoc = N'" + cbTenThuoc.Text + "'");

                    //Command(mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                    SqlCommand cmd = new SqlCommand(SQL, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ShowData();
                }
                else
                {
                    conn.Close();
                    ShowData();
                }
                Hóa_Đơn_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            ShowData();
        }
    }
}
