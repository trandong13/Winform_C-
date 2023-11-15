using _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.GUI
{
    public partial class frm_DangNhap_Hieu : Form
    {
        DangNhapBll dangNhapBll = new DangNhapBll();
        public frm_DangNhap_Hieu()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Hieu_Click(object sender, EventArgs e)
        {
            String tk = tb_TenDN_Hieu.Text;
            String mk = tb_MatKhau_Hieu.Text;
            DataTable data = dangNhapBll.checkLogin(tk, mk);
            if (data != null && data.Rows.Count > 0)
            {
                String tenDN = data.Rows[0]["TenDN"].ToString();
                String quyenSv = data.Rows[0]["Loai"].ToString();
                frm_Menu form = new frm_Menu(quyenSv, tenDN);
                form.Show();
                this.Hide();

            }
            else
                MessageBox.Show("Tài khoản mật khẩu không chính xác");
        }
    }
}
