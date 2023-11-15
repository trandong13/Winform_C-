using Quan_Ly_Hoa_Don.BLL;
using Quan_Ly_Hoa_Don.GUI;
using Quan_Ly_Hoa_Don.report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Quan_Ly_Hoa_Don
{
    public partial class FormMain : Form
    {
        static int row;
        int id = 1;
        double tong = 0;
        TrungGian tg = new TrungGian();
        bll bl = new bll();
        static string TenSp;
        int r = 0;
        public FormMain()
        {
            InitializeComponent();
        }
        private void btnThongTin_Click(object sender, EventArgs e)
        {
            var formThongTinSP = new FormThongTinSP("sp");
            formThongTinSP.ShowDialog();

        }
        private object LocDau(string text)
        {
            throw new NotImplementedException();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSoLuong.Text) ||
                  String.IsNullOrEmpty(cbbLoai.Text) || String.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin ! ", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Receipt obj = new Receipt() { Id = id++, Tensp = TenSp, Soluong = float.Parse(txtSoLuong.Text), Dongia = txtDonGia.Text, Loai = cbbLoai.Text, Thanhtien = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", double.Parse(txtDonGia.Text) * double.Parse(txtSoLuong.Text)) };
                    tong += double.Parse(obj.Dongia) * obj.Soluong;
                    receiptBindingSource.Add(obj);
                    receiptBindingSource.MoveLast();
                    lblTong.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", tong).ToString();
                    dataGridView.Rows[r].Cells[4].Value = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", double.Parse(dataGridView.Rows[r].Cells[4].Value.ToString())).ToString();
                    r++;
                    txtTimKiem.Text = null;
                    txtDonGia.Text = null;
                    cbbLoai.Text = null;
                    txtDonGia.Text = null;
                    txtSoLuong.Text = null;
                }
                catch (Exception)
                {
                    MessageBox.Show("Bạn phải nhập số", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvTimSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row != -1)
            {
                TenSp = dgvTimSP.Rows[row].Cells[0].Value.ToString();
            }
            lblTenSp.Text = TenSp;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Receipt obj = receiptBindingSource.Current as Receipt;
            if (obj != null)
            {
                tong -= double.Parse(obj.Thanhtien.Replace(".", ""));
            }
            receiptBindingSource.RemoveCurrent();
            lblTong.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", tong).ToString();
            //
            btnXoa.Enabled = false;
            if (row < dataGridView.Rows.Count)
            {
                for (int i = row; i < dataGridView.Rows.Count; i++)
                {
                    dataGridView.Rows[i].Cells[0].Value = int.Parse(dataGridView.Rows[i].Cells[0].Value.ToString()) - 1;
                }
            }
            id--;
            r--;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = bl.loadSp(TrungGian.LocDau(txtTimKiem.Text).Trim());
                dgvTimSP.DataSource = dt;
                lblTenSp.Text = null;
                if (dgvTimSP.Rows.Count == 1)
                {
                    lblTenSp.Text = dgvTimSP.Rows[0].Cells[0].Value.ToString();
                    TenSp = lblTenSp.Text;
                }
                if (dgvTimSP.Rows.Count > 1)
                {
                    dgvTimSP.Rows[0].Selected = false;
                }
                txtTimKiem.Text = null;

            }
        }

        public void FormMain_Load_1(object sender, EventArgs e)
        {
            DataTable dt1 = bl.loadCbb();
            cbbLoai.DataSource = dt1;
            cbbLoai.DisplayMember = "TenLoai";
            cbbLoai.ValueMember = "TenLoai";
            receiptBindingSource.DataSource = new List<Receipt>();

        }

        private void btnLoai_Click(object sender, EventArgs e)
        {
            var formThongTinSP = new FormThongTinSP("loai");
            formThongTinSP.ShowDialog();
        }

        private void cbbLoai_Click(object sender, EventArgs e)
        {
            DataTable dt1 = bl.loadCbb();
            cbbLoai.DataSource = dt1;
            cbbLoai.DisplayMember = "TenLoai";
            cbbLoai.ValueMember = "TenLoai";
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            using (xemHoaDon frm = new xemHoaDon(receiptBindingSource.DataSource as List<Receipt>, DateTime.Now.ToString("dd/MM/yyyy"), string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", tong)))
            {
                frm.ShowDialog();
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            if (row != -1)
            {
                btnXoa.Enabled = true;
            }
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            var formDT = new formDoanhThu();
            formDT.ShowDialog();
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            FormMain_Load_1(sender, e);
            lblTong.Text = null;
            lblTenSp.Text = null;
            for (int i = 0; i < dgvTimSP.Rows.Count; i++)
            {
                dgvTimSP.Rows[i].Cells[0].Value = null;
            }
            id = 1;
            tong = 0;
            r = 0;
            txtSoLuong.Text = null;
            txtDonGia.Text = null;
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            /*if (string.IsNullOrEmpty(txtDonGia.Text) == false)
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtDonGia.Text, System.Globalization.NumberStyles.AllowThousands);
                txtDonGia.Text = String.Format(culture, "{0:N0}", value);
                txtDonGia.Select(txtDonGia.Text.Length, 0);
            }*/
            try
            {

                double flTienThuong = double.Parse(txtDonGia.Text.Replace(",", ""));
                txtDonGia.Text = flTienThuong.ToString("0,00.##");
                txtDonGia.Select(txtDonGia.TextLength, 0);
            }
            catch (Exception)
            {

            }
        }
        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void cbbLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtDonGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
                btnThem_Click(sender, e);
            }    
        }

        private void txtLuBill_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 0)
            {
                if (bl.insertBill(DateTime.Now.ToString("yyyy/MM/dd"), tong))
                {
                    MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    
                
            }
        }
    }
}
