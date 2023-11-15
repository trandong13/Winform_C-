using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Quan_Ly_Hoa_Don.BLL;

namespace Quan_Ly_Hoa_Don.GUI
{
    public partial class formDoanhThu : Form
    {
        bll bl = new bll();
        public formDoanhThu()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txThang.Text) || String.IsNullOrEmpty(txtNam.Text))
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin ! ", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable dt = bl.layTongTien(txThang.Text, txtNam.Text);
                if (String.IsNullOrEmpty(dt.Rows[0][0].ToString())==false)
                {
                    lblNgay.Text =(txThang.Text + "-" + txtNam.Text +" là: ").ToString();
                    lblDoanThu.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", double.Parse(dt.Rows[0][0].ToString())).ToString();
                }
            }
        }

        private void btnXoaAll_Click(object sender, EventArgs e)
        {
            if( bl.DeleteBill())
            {
                MessageBox.Show("Xóa thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txThang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtNam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
                btnXem_Click(sender, e);
            }
        }
    }
}
