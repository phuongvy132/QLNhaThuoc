using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DevExpress.PivotGrid.QueryMode;
using DevExpress.XtraDashboardLayout;
using QLNhaThuoc_BUS;
using QLNhaThuoc_DTO;

namespace QLNhaThuoc
{
    public partial class DuocPham : KryptonForm
    {
        DuocPham_BUS dpBUS = new DuocPham_BUS();
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QQPQ8EC;Initial Catalog=QLNhaThuoc;Integrated Security=True");

        public DuocPham()
        {
            InitializeComponent();
        }
        private void DuocPham_Load(object sender, EventArgs e)
        {
            ShowData();
 
        }
        void ShowData()
        {
            dgvThuoc.AutoGenerateColumns = false;
            DataTable dtThuoc = new DataTable();
            dtThuoc = dpBUS.getDP();
            dgvThuoc.DataSource = dtThuoc;
            conn.Close();
        }

        void cleardata()
        {
            txtTenThuoc.Text = "Tên thuốc";
            txtMaThuoc.Text = "Mã thuốc";
            cbMaNhom.Text = "Mã nhóm";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DuocPham_DTO dpDTO = new DuocPham_DTO();
            dpDTO.GiaBan = txtGia.Text;
            dpDTO.MaThuoc = txtMaThuoc.Text;
            dpDTO.TenThuoc = txtTenThuoc.Text;
            dpDTO.HSD = dtHSD.Text;
            dpDTO.MaNhom = cbMaNhom.Text;
            dpDTO.SoLuong = numSL.Text;

            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Thuoc WHERE MaThuoc = @parm1", conn);
            cmd1.Parameters.AddWithValue("parm1", txtMaThuoc.Text);
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
                dpBUS.themDP(dpDTO);

                string SQL = string.Format(@"Insert into Thuoc (MaThuoc, TenThuoc, GiaBan, SoLuong, HSD) 
                                                    values 
                                                   (N'" + txtMaThuoc.Text +
                                                   "',N'" + txtTenThuoc.Text +
                                                   "',N'" + txtGia.Text +
                                                   "',N'" + numSL.Text +
                                                   "',CONVERT(DATE,'" + dtHSD.Text + "',103))");
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL, conn);
                    cmd1.Parameters.AddWithValue("MaThuoc", txtMaThuoc.Text.Trim());
                    //cmd1.Parameters.AddWithValue("MaNhom", cbMaNhom.Text);
                    cmd1.Parameters.AddWithValue("TenThuoc", txtTenThuoc.Text.Trim());
                    cmd1.Parameters.AddWithValue("GiaBan", txtGia.Text.Trim());
                    cmd1.Parameters.AddWithValue("SoLuong", numSL.Text.Trim());
                    cmd1.Parameters.AddWithValue("HSD", dtHSD.Value.ToString("dd/MM/yyyy"));
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    cleardata();
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
    

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaThuoc.ReadOnly = true;
            int i = dgvThuoc.CurrentRow.Index;
            //int t = dgvThuoc.CurrentCell.RowIndex;

            txtTenThuoc.Text = dgvThuoc.Rows[i].Cells[2].Value.ToString();
            cbMaNhom.Text = dgvThuoc.Rows[i].Cells[1].Value.ToString();
            //numSL. = Convert.ToDecimal(dgvThuoc.SelectedRows[0].Cells[5].Value.ToString());
            /****/
            numSL.Text = dgvThuoc.Rows[i].Cells[5].Value.ToString();
            txtMaThuoc.Text = dgvThuoc.Rows[i].Cells[0].Value.ToString();
            dtHSD.Text = dgvThuoc.Rows[i].Cells[4].Value.ToString(); 
            txtGia.Text = dgvThuoc.Rows[i].Cells[3].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            try
            {
                if (dialogResult == DialogResult.Yes)
                {
                    string SQL = string.Format("DELETE FROM Thuoc WHERE MaThuoc = N'" + txtMaThuoc.Text + "'");

                    //Command(mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                    SqlCommand cmd = new SqlCommand(SQL, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    cleardata();
                    ShowData();
                }
                else
                {
                    conn.Close();
                    ShowData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            ShowData();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                string SQL = string.Format(@"UPDATE Thuoc SET TenThuoc = N'" + txtTenThuoc.Text +
                        "', MaThuoc = N'" + txtMaThuoc.Text +
                        "', GiaBan = '" + txtGia.Text +
                        "', SoLuong = '" + numSL.Text +
                        "',	HSD = CONVERT(DATE,'" + dtHSD.Text + "',103)" +
                        "WHERE MaThuoc = '" + txtMaThuoc.Text + "'");

                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                cleardata();
                ShowData();
                MessageBox.Show("Sửa Thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            ShowData();

        }

        private void dgvThuoc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dtHSD.Value = Convert.ToDateTime(dgvThuoc.Rows[e.RowIndex].Cells[5].Value);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
        //private DataTable search()
        //{
        //    string query = "SELECT TenThuoc, MaThuoc  FROM Thuoc";
        //    query += "WHERE TenThuoc Like '%' + @parm1 + '%'";
        //    query += "WHERE MaThuoc Like '%' + @parm1 + '%'";
        //    string con = @"Provider =Microsoft.ACE.OLEDB.12.0; Data Source=DESKTOP-QQPQ8EC;Initial Catalog=QLNhaThuoc;Integrated Security=True";
        //    using (OleDbConnection conn = new OleDbConnection(con))

        //    {
        //        using (OleDbCommand cmd = new OleDbCommand(query,conn))
        //        {
        //            cmd.Parameters.AddWithValue("parm1", txtTimKiem.Text);
        //            using(OleDbDataAdapter da = new OleDbDataAdapter())
        //            {
        //                DataTable dt = new DataTable();
        //                da.Fill(dt);
        //                dgvThuoc.DataSource = dt;
        //                return (dt);
        //            }
        //        }    
        //    }
        //}

        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            //search();

        }
    }
}
