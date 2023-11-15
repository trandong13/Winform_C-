using _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.GUI
{
    public partial class fm_DangNhap_NVHieu : Form
    {

        public fm_DangNhap_NVHieu()
        {
            InitializeComponent();
        }
        DangNhapBLL dangNhapBLL = new DangNhapBLL();
        private void btnDangNhap_Hieu_Click(object sender, EventArgs e)
        {

            String tk = tb_TK_Hieu.Text;
            String mk = tb_MK_Hieu.Text;
            DataTable data = dangNhapBLL.checkLogin(tk, mk);
            if (data != null && data.Rows.Count > 0)
            {
                String taikhoan = data.Rows[0]["TaiKhoan"].ToString();
                String quyenNV = data.Rows[0]["Kieu"].ToString();
                fm_Menu menu = new fm_Menu(quyenNV,taikhoan);
                menu.Show();
                this.Hide();

            }
            else
                MessageBox.Show("Tài khoản mật khẩu không chính xác");
            
        }

        private void btn_DoiMK_Hieu_Click(object sender, EventArgs e)
        {
            fm_DoiMK_Hieu doimk = new fm_DoiMK_Hieu();
            this.Hide();
            doimk.Show();
        }
    }
}
