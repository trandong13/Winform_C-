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
    public partial class fm_DoiMK_Hieu : Form
    {
        public fm_DoiMK_Hieu()
        {
            InitializeComponent();
        }
        DangNhapBLL dangNhapBLL = new DangNhapBLL();
        private void btn_BackDN_Hieu_Click(object sender, EventArgs e)
        {
            fm_DangNhap_NVHieu form = new fm_DangNhap_NVHieu(); 
            this.Close();
            form.Show();
        }
        void loadmk()
        {
            tb_tkDoiMK_Hieu.Text="";
            tb_mkCuDoiMK_Hieu.Text="";
             tb_mkMoiDoiMK_Hieu.Text="";
             tb_nhapLaiMk_Hieu.Text="";
        }
        private void btn_XacNhan_Hieu_Click(object sender, EventArgs e)
        {
            String tk = tb_tkDoiMK_Hieu.Text;
            String mkcu = tb_mkCuDoiMK_Hieu.Text;
            String mkmoi1= tb_mkMoiDoiMK_Hieu.Text ;
            String mkmoi2 = tb_nhapLaiMk_Hieu.Text;
            DataTable data = dangNhapBLL.checkLogin(tk, mkcu);
            if (data != null && data.Rows.Count > 0 )
            {
                if(ktra())

                if(mkmoi1.Equals(mkmoi2))
                {
                     if(dangNhapBLL.suaMatKhau(tk,mkmoi2))

                        MessageBox.Show("Thay đổi mật khẩu thành công");
                    loadmk();
                }    
                else
                {
                    MessageBox.Show("Nhập lại mật khẩu mới");
                }    
            }
            else
                MessageBox.Show("Tài khoản mật khẩu không chính xác");


        }

        public bool ktra()
        {
            if(string.IsNullOrEmpty(tb_mkMoiDoiMK_Hieu.Text.Trim()))
            {
                MessageBox.Show("Nhập mật khẩu mới","Error",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                tb_mkMoiDoiMK_Hieu.Focus();
                return false;
            }    
            return true;
        }
    }
}
