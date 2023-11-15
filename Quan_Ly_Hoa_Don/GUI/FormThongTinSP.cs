using Quan_Ly_Hoa_Don.BLL;
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

namespace Quan_Ly_Hoa_Don.GUI
{
    public partial class FormThongTinSP : Form
    {
        private string type = "";
        bll bl = new bll();
        TrungGian tg = new TrungGian();
        public FormThongTinSP()
        {
            InitializeComponent();
        }
        public FormThongTinSP(string type)
        {
            InitializeComponent();
            this.type = type;
        }
        private void FormThongTinSP_Load(object sender, EventArgs e)
        {

            if (type.Equals("sp"))
            {
                DataTable dt = bl.loadAllSp();
                dgvAll.DataSource = dt;
                dgvAll.Columns["TenLoai"].Visible = false;
            }
            if (type.Equals("loai"))
            {
                DataTable dt1 = bl.loadCbb();
                dgvAll.DataSource = dt1;
                dgvAll.Columns["TenSp"].Visible = false;
                txtTimKiem.Enabled = false;
                lblTen.Text = "TÊN LOẠI";
                lblTimKiem.Text = "";
            }
            if (dgvAll.Rows.Count > 0)
            {
                dgvAll.Rows[0].Selected = false;
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = bl.loadSp(TrungGian.LocDau(txtTimKiem.Text).Trim());
                dgvAll.DataSource = dt;
                txtTimKiem.Text = null;
                if (dgvAll.Rows.Count == 1)
                {
                    if (type.Equals("sp"))
                        name = dgvAll.Rows[0].Cells["TenSp"].Value.ToString();
                }
                if (dgvAll.Rows.Count > 1)
                {
                    dgvAll.Rows[0].Selected = false;
                }
            }
        }

        private void FormThongTinSP_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataTable dt2 = bl.loadAllSp();
        }
        private void btnThemSp_Click(object sender, EventArgs e)
        {
            if (type.Equals("sp"))
            {
                try
                {
                    if (String.IsNullOrEmpty(txtThemSp.Text))
                    {
                        MessageBox.Show("Bạn chưa nhập đầy đủ thông tin ! ", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (bl.Insert(txtThemSp.Text))
                        {
                            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Thêm sản phẩm thất bại!", "Thông báo",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("PRIMARY KEY"))
                        MessageBox.Show("Tên hàng đã có trong kho!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (type.Equals("loai"))
            {
                try
                {
                    if (String.IsNullOrEmpty(txtThemSp.Text))
                    {
                        MessageBox.Show("Bạn chưa nhập đầy đủ thông tin ! ", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (bl.InsertLoai(txtThemSp.Text))
                        {
                            MessageBox.Show("Thêm loại thành công!", "Thông báo",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Thêm loại thất bại!", "Thông báo",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("PRIMARY KEY"))
                        MessageBox.Show("Tên loại đã có rồi nhé!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtThemSp.Text = null;
            FormThongTinSP_Load(sender, e);
        }

        private void btnXoaSp_Click(object sender, EventArgs e)
        {
            if (name != null)
            {
                if (type.Equals("sp"))
                {
                    if (bl.Delete(name))
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm thất bại!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (type.Equals("loai"))
                {
                    if (bl.DeleteLoai(name))
                    {
                        MessageBox.Show("Xóa loại thành công!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Xóa loại thất bại!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn sản phẩm muốn xóa!", "Thông báo",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            FormThongTinSP_Load(sender, e);
            name = null;
        }
        static string name;
        private void dgvAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (type.Equals("sp"))
            {
                int row1 = e.RowIndex;
                if (row1 != -1)
                {
                    name = dgvAll.Rows[row1].Cells["TenSp"].Value.ToString();
                }
            }
            if (type.Equals("loai"))
            {
                int row = e.RowIndex;
                if (row != -1)
                {
                    name = dgvAll.Rows[row].Cells["TenLoai"].Value.ToString();
                }

            }
        }
        private void txtThemSp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnThemSp_Click(sender, e);
            }
        }
    }
}
