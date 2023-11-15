using _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.GUI
{
    public partial class frm_Menu : Form
    {
        SinhVienBll sinhVienBll = new SinhVienBll();
        LopHocBll lopHocBll = new LopHocBll();
        MonHocBll monHocBll = new MonHocBll();
        LopHocPhanBll lopHocPhanBll = new LopHocPhanBll();
        DiemBll diemBll = new DiemBll();
        ThongKeBll thongKeBll = new ThongKeBll();
        public frm_Menu()
        {
            InitializeComponent();

        }

        String TenDNhap = "";
        public frm_Menu(String quyen, String tenDN) : this()
        {
            TenDNhap = tenDN;
            //Phân quyền, nếu không có quyền sẽ ẩn button ở menu
            if (quyen.Equals("GV"))
            {
                btn_SinhVien_Hung.Visible = false;
                btn_LopHoc_Hung.Visible = false;
                btn_MonHoc_Hung.Visible = false;
                btn_LopHocPhan_Dong.Visible = false;
                btn_ThongKe_Khai.Visible = false;
                btn_DangKyMon_Dong.Visible = false;
            }
            if (quyen.Equals("CB"))
            {
                btn_Diem_Dong.Visible = false;
                btn_DangKyMon_Dong.Visible = false;
            }
            if (quyen.Equals("SV"))
            {
                btn_SinhVien_Hung.Visible = false;
                btn_LopHoc_Hung.Visible = false;
                btn_MonHoc_Hung.Visible = false;
                btn_LopHocPhan_Dong.Visible = false;
                btn_ThongKe_Khai.Visible = false;
                btn_Diem_Dong.Visible = false;
            }
        }


        //Khi kích chuột vào button menu
        private void btnHome_Click(object sender, EventArgs e)
        {
            tabTong.SelectedIndex = 0;
        }

        private void btn_SinhVien_Hung_Click(object sender, EventArgs e)
        {
            tabTong.SelectedIndex = 1;
            loadSV();
            loadCbMaLopSv();

        }

        private void btn_LopHoc_Hung_Click(object sender, EventArgs e)
        {
            tabTong.SelectedIndex = 2;
            loadLopHoc();
        }

        private void btn_MonHoc_Hung_Click(object sender, EventArgs e)
        {
            tabTong.SelectedIndex = 3;
            loadMonHoc();
        }

        private void btn_LopHocPhan_Dong_Click(object sender, EventArgs e)
        {
            tabTong.SelectedIndex = 4;
            loadCbbMaLop();
            loadCbbMaMon();
            loadLHP();
        }

        private void btn_Diem_Dong_Click(object sender, EventArgs e)
        {
            tabTong.SelectedIndex = 5;
            loadCbbMonDiem();
            loadCbbLopDiem();
            loadDiem();
        }

        private void btn_ThongKe_Khai_Click(object sender, EventArgs e)
        {
            tabTong.SelectedIndex = 6;
            loadCbbMonTK();
            loadCbbLopTK();
            loadSvTK();
            loadDiemTK();
        }
        private void btn_DangKyMon_Dong_Click(object sender, EventArgs e)
        {
            tabTong.SelectedIndex = 7;
            loadDkSV();
        }
        private void btnOut_Click(object sender, EventArgs e)
        {
            frm_DangNhap_Hieu form = new frm_DangNhap_Hieu();
            this.Close();
            form.Show();
        }



        //Quản lý sinh viên//////////////////////////////////////////////////////////////////////////

        void loadSV()
        {
            dgv_SinhVien_Hung.DataSource = sinhVienBll.dsSinhVien();
        }
        void loadCbMaLopSv()
        {
            cb_MaLop_Hung.DataSource = lopHocBll.dsLopHoc();
            cb_MaLop_Hung.DisplayMember = "MaLop";
        }
        //Hàm xóa trắng dữ liệu trong textbox
        void xoaTrang()
        {
            tb_MaSV_Hung.Text = "";
            tb_HoDem_Hung.Text = "";
            tb_Ten_Hung.Text = "";
            tb_NgaySinh_Hung.Text = "";
            tb_GioiTinh_Hung.Text = "";
            tb_QueQuan_Hung.Text = "";
            tb_SDT_Hung.Text = "";
            //tb_MaLop_Hung.Text = "";
            tb_TenDN_Hung.Text = "";
            tb_MatKhau_Hung.Text = "";
        }

        //Thêm sinh viên
        private void btn_ThemSV_Hung_Click(object sender, EventArgs e)
        {
            String maSv = tb_MaSV_Hung.Text;
            String hoDem = tb_HoDem_Hung.Text;
            String ten = tb_Ten_Hung.Text;
            String ngaySinh = tb_NgaySinh_Hung.Text;
            String gioiTinh = tb_GioiTinh_Hung.Text;
            String queQuan = tb_QueQuan_Hung.Text;
            String sdt = tb_SDT_Hung.Text;
            String maLop = cb_MaLop_Hung.Text;
            String tenDn = tb_TenDN_Hung.Text;
            String matKhau = tb_MatKhau_Hung.Text;

            DataTable data1 = sinhVienBll.checkSV(maSv);
            DataTable data2 = sinhVienBll.checkNguoiDung(tenDn);
            if (data1 != null && data1.Rows.Count > 0)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại.");
            }
            else
            {
                if (data2 != null && data2.Rows.Count > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại.");
                }
                else
                {
                    if (sinhVienBll.themNguoDung(tenDn, matKhau))
                    {
                        if (sinhVienBll.themSv(maSv, hoDem, ten, ngaySinh, gioiTinh, queQuan, sdt, tenDn, maLop))
                        {
                            MessageBox.Show("Thêm sinh viên thành công.");
                            xoaTrang();
                            loadSV();
                        }
                    }
                }
            }

        }

        //Khi kích vào  1 hàng trong dgv thì load dữ liệu lại cái textbox
        private void dgv_SinhVien_Hung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row1 = e.RowIndex;
            tb_MaSV_Hung.Text = dgv_SinhVien_Hung.Rows[row1].Cells["MaSV"].Value.ToString();
            tb_HoDem_Hung.Text = dgv_SinhVien_Hung.Rows[row1].Cells["HoDem"].Value.ToString();
            tb_Ten_Hung.Text = dgv_SinhVien_Hung.Rows[row1].Cells["Ten"].Value.ToString();
            tb_NgaySinh_Hung.Text = dgv_SinhVien_Hung.Rows[row1].Cells["NgaySinh"].Value.ToString();
            tb_GioiTinh_Hung.Text = dgv_SinhVien_Hung.Rows[row1].Cells["GioiTinh"].Value.ToString();
            tb_QueQuan_Hung.Text = dgv_SinhVien_Hung.Rows[row1].Cells["QueQuan"].Value.ToString();
            tb_SDT_Hung.Text = dgv_SinhVien_Hung.Rows[row1].Cells["SDT"].Value.ToString();
            cb_MaLop_Hung.Text = dgv_SinhVien_Hung.Rows[row1].Cells["MaLop"].Value.ToString();
            //tb_TenDN_Hung.Text = dgv_SinhVien_Hung.Rows[row1].Cells["TenDN"].Value.ToString();
            //tb_MatKhau_Hung.Text = dgv_SinhVien_Hung.Rows[row1].Cells["MatKhau"].Value.ToString();

            //tb_MaSV_Hung.ReadOnly = true;


        }

        //kích vào button sửa sẽ update vào database
        private void btn_SuaSV_Hung_Click(object sender, EventArgs e)
        {
            String maSv = tb_MaSV_Hung.Text;
            String hoDem = tb_HoDem_Hung.Text;
            String ten = tb_Ten_Hung.Text;
            String ngaySinh = tb_NgaySinh_Hung.Text;
            String gioiTinh = tb_GioiTinh_Hung.Text;
            String queQuan = tb_QueQuan_Hung.Text;
            String sdt = tb_SDT_Hung.Text;
            String maLop = cb_MaLop_Hung.Text;

            if (sinhVienBll.suaSV(maSv, hoDem, ten, ngaySinh, gioiTinh, queQuan, sdt, maLop))
            {
                MessageBox.Show("Cập nhật sinh viên thành công.");
                xoaTrang();
                loadSV();
            }
        }

        private void btn_XoaSV_Hung_Click(object sender, EventArgs e)
        {
            try
            {
                String maSv = tb_MaSV_Hung.Text;
                if (sinhVienBll.xoaSV(maSv))
                {
                    MessageBox.Show("Xóa thành công.");
                    xoaTrang();
                    loadSV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa.");
            }

        }

        //tìm sinh viên
        private void btn_TimSV_Hung_Click(object sender, EventArgs e)
        {
            String timKiem = txt_TimSV_Hung.Text;
            dgv_SinhVien_Hung.DataSource = null;
            dgv_SinhVien_Hung.DataSource = sinhVienBll.timSv(timKiem);
        }

        private void btn_SapXepSV_Hung_Click(object sender, EventArgs e)
        {
            dgv_SinhVien_Hung.DataSource = null;
            dgv_SinhVien_Hung.DataSource = sinhVienBll.sapTheoTenSv();
        }


        //////////////Hết quản lý Sinh viên///////////////////////////////////////////////////////////////////////////



        //Quản lý lớp học

        //load danh sách lớp học
        void loadLopHoc()
        {
            dgv_LopHoc_Hung.DataSource = lopHocBll.dsLopHoc();
        }
        void xoaTrangLH()
        {
            tb_MaLopHung.Text = "";
            tb_TenLop_Hung.Text = "";
            tb_KhoaHoc_Hung.Text = "";
            tb_HeDTao_Hung.Text = "";
            tb_NamNhapHoc_Hung.Text = "";
            tb_TenKhoa_Hung.Text = "";
        }
        private void btn_ThemLop_Hung_Click(object sender, EventArgs e)
        {
            String maLop = tb_MaLopHung.Text;
            String tenLop = tb_TenLop_Hung.Text;
            String khoaHoc = tb_KhoaHoc_Hung.Text;
            String heDaoTao = tb_HeDTao_Hung.Text;
            int namNhapHoc = int.Parse(tb_NamNhapHoc_Hung.Text);
            String tenKhoa = tb_TenKhoa_Hung.Text;
            DataTable dataLopHoc = lopHocBll.ktLopHoc(maLop);
            if (dataLopHoc != null && dataLopHoc.Rows.Count > 0)
            {
                MessageBox.Show("Mã lớp học đã tồn tại.");
            }
            else
            {
                if (lopHocBll.themLopHoc(maLop, tenLop, khoaHoc, heDaoTao, namNhapHoc, tenKhoa))
                {
                    MessageBox.Show("Thêm lớp học thành công.");
                    loadLopHoc();
                    xoaTrangLH();
                }
            }
        }

        private void dgv_LopHoc_Hung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row1 = e.RowIndex;
            tb_MaLopHung.Text = dgv_LopHoc_Hung.Rows[row1].Cells["dataGridViewTextBoxColumn1"].Value.ToString();
            tb_TenLop_Hung.Text = dgv_LopHoc_Hung.Rows[row1].Cells["TenLop"].Value.ToString();
            tb_KhoaHoc_Hung.Text = dgv_LopHoc_Hung.Rows[row1].Cells["KhoaHoc"].Value.ToString();
            tb_HeDTao_Hung.Text = dgv_LopHoc_Hung.Rows[row1].Cells["HeDaoTao"].Value.ToString();
            tb_NamNhapHoc_Hung.Text = dgv_LopHoc_Hung.Rows[row1].Cells["NamNhapHoc"].Value.ToString();
            tb_TenKhoa_Hung.Text = dgv_LopHoc_Hung.Rows[row1].Cells["TenKhoa"].Value.ToString();
        }

        private void btn_SuaLop_Hung_Click(object sender, EventArgs e)
        {
            String maLop = tb_MaLopHung.Text;
            String tenLop = tb_TenLop_Hung.Text;
            String khoaHoc = tb_KhoaHoc_Hung.Text;
            String heDaoTao = tb_HeDTao_Hung.Text;
            int namNhapHoc = int.Parse(tb_NamNhapHoc_Hung.Text);
            String tenKhoa = tb_TenKhoa_Hung.Text;
            if (lopHocBll.suaLopHoc(maLop, tenLop, khoaHoc, heDaoTao, namNhapHoc, tenKhoa))
            {
                MessageBox.Show("Cập nhật lớp học thành công.");
                loadLopHoc();
                xoaTrangLH();
            }
        }

        private void btn_XoaLop_Hung_Click(object sender, EventArgs e)
        {
            try
            {
                if (lopHocBll.xoaLopHoc(tb_MaLopHung.Text))
                {
                    MessageBox.Show("Xóa lớp học thành công.");
                    loadLopHoc();
                    xoaTrangLH();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa.");
            }

        }

        //////////////hết quản lý lớp học//////////////////////////////////////////////////


        //Quản lý môn học
        void loadMonHoc()
        {
            dgv_MonHoc_Hung.DataSource = monHocBll.dsMonHoc();
        }
        void xoaTrangMon()
        {
            tb_MaMon_Hung.Text = "";
            tb_TenMon_Hung.Text = "";
            tb_SoTinChi_Hung.Text = "";
        }

        private void btn_ThemMon_Hung_Click(object sender, EventArgs e)
        {
            String maMon = tb_MaMon_Hung.Text;
            String tenMon = tb_TenMon_Hung.Text;
            int soTinChi = int.Parse(tb_SoTinChi_Hung.Text);
            DataTable dataMonHoc = monHocBll.ktMonHoc(maMon);
            if (dataMonHoc != null && dataMonHoc.Rows.Count > 0)
            {
                MessageBox.Show("Mã môn học đã tồn tại.");
            }
            else
            {
                if (monHocBll.themMonHoc(maMon, tenMon, soTinChi))
                {
                    MessageBox.Show("Thêm môn học thành công.");
                    loadMonHoc();
                    xoaTrangMon();
                }
            }
        }

        private void dgv_MonHoc_Hung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row1 = e.RowIndex;
            tb_MaMon_Hung.Text = dgv_MonHoc_Hung.Rows[row1].Cells["MaMon"].Value.ToString();
            tb_TenMon_Hung.Text = dgv_MonHoc_Hung.Rows[row1].Cells["TenMon"].Value.ToString();
            tb_SoTinChi_Hung.Text = dgv_MonHoc_Hung.Rows[row1].Cells["SoTin"].Value.ToString();
        }

        private void btn_SuaMon_Hung_Click(object sender, EventArgs e)
        {
            String maMon = tb_MaMon_Hung.Text;
            String tenMon = tb_TenMon_Hung.Text;
            int soTinChi = int.Parse(tb_SoTinChi_Hung.Text);
            if (monHocBll.suaMonHoc(maMon, tenMon, soTinChi))
            {
                MessageBox.Show("Sửa môn học thành công.");
                loadMonHoc();
                xoaTrangMon();
            }
        }

        private void btn_XoaMon_Hung_Click(object sender, EventArgs e)
        {
            try
            {
                if (monHocBll.xoaMonHoc(tb_MaMon_Hung.Text))
                {
                    MessageBox.Show("Xóa môn học thành công.");
                    loadMonHoc();
                    xoaTrangMon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa.");
            }


        }

        ////Hết quản lý môn học///////////////////////////////////////////////

        //Quản lý lớp học phần//////
        void loadCbbMaMon()
        {
            cb_MaMonLHP_Dong.DataSource = monHocBll.dsMonHoc();
            cb_MaMonLHP_Dong.DisplayMember = "MaMon";
            //cb_MaMonLHP_Dong.ValueMember = "MaMon";
        }
        void loadCbbMaLop()
        {
            cb_MaLopLHP_Dong.DataSource = lopHocBll.dsLopHoc();
            cb_MaLopLHP_Dong.DisplayMember = "MaLop";
            //cb_MaMonLHP_Dong.ValueMember = "MaLop";
        }
        void loadLHP()
        {
            dgv_LopHocPhan_Dong.DataSource = lopHocPhanBll.dsLopHocPhan();
        }
        void xoaTrangLHP()
        {
            tb_MaGVLHP_Dong.Text = "";
            tb_HocKy_Dong.Text = "";
            tb_Nam_Dong.Text = "";
        }

        private void btn_ThemLopHP_Dong_Click(object sender, EventArgs e)
        {
            String maLop = cb_MaLopLHP_Dong.Text;
            String maMon = cb_MaMonLHP_Dong.Text;
            String maGV = tb_MaGVLHP_Dong.Text;
            int hocKy = int.Parse(tb_HocKy_Dong.Text);
            int nam = int.Parse(tb_Nam_Dong.Text);
            DataTable dt = lopHocPhanBll.ktLopHocPhan(maMon, maLop);
            if (dt != null && dt.Rows.Count > 0)
            {
                MessageBox.Show("Lớp học phần đã tồn tại.");
            }
            else
            {
                if (lopHocPhanBll.themLopHocPhan(maLop, maMon, maGV, hocKy, nam))
                {
                    MessageBox.Show("Thêm lớp học phần thành công.");
                    loadLHP();
                    xoaTrangLHP();
                }
            }
        }

        private void dgv_LopHocPhan_Dong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row1 = e.RowIndex;
            cb_MaLopLHP_Dong.Text = dgv_LopHocPhan_Dong.Rows[row1].Cells["MaLopHP"].Value.ToString();
            cb_MaMonLHP_Dong.Text = dgv_LopHocPhan_Dong.Rows[row1].Cells["MaMonHP"].Value.ToString();
            tb_MaGVLHP_Dong.Text = dgv_LopHocPhan_Dong.Rows[row1].Cells["MaGV"].Value.ToString();
            tb_HocKy_Dong.Text = dgv_LopHocPhan_Dong.Rows[row1].Cells["HocKy"].Value.ToString();
            tb_Nam_Dong.Text = dgv_LopHocPhan_Dong.Rows[row1].Cells["Nam"].Value.ToString();
        }

        private void btn_SuaLopHP_Dong_Click(object sender, EventArgs e)
        {
            String maLop = cb_MaLopLHP_Dong.Text;
            String maMon = cb_MaMonLHP_Dong.Text;
            String maGV = tb_MaGVLHP_Dong.Text;
            int hocKy = int.Parse(tb_HocKy_Dong.Text);
            int nam = int.Parse(tb_Nam_Dong.Text);
            if (lopHocPhanBll.suaLopHocPhan(maLop, maMon, maGV, hocKy, nam))
            {
                MessageBox.Show("sửa lớp học phần thành công.");
                loadLHP();
                xoaTrangLHP();
            }
        }

        private void btn_XoaLopHP_Dong_Click(object sender, EventArgs e)
        {
            try
            {
                if (lopHocPhanBll.xoaMaLopHoc(cb_MaMonLHP_Dong.Text, cb_MaLopLHP_Dong.Text))
                {
                    MessageBox.Show("Xóa lớp học phần thành công.");
                    loadLHP();
                    xoaTrangLHP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa.");
            }
        }

        //////Hết phần quản lý lớp học phần////////////////////////////////////

        //Quản lý điểm sinh viên/////////////
        void loadCbbMonDiem()
        {
            cb_MonDiem_Dong.DataSource = monHocBll.dsMonHoc();
            cb_MonDiem_Dong.DisplayMember = "TenMon";
            cb_MonDiem_Dong.ValueMember = "MaMon";
        }
        void loadCbbLopDiem()
        {
            cb_LopDiem_Dong.DataSource = lopHocBll.dsLopHoc();
            cb_LopDiem_Dong.DisplayMember = "TenLop";
            cb_LopDiem_Dong.ValueMember = "MaLop";
        }
        void loadDiem()
        {
            String maMon = cb_MonDiem_Dong.SelectedValue.ToString();
            String maLop = cb_LopDiem_Dong.SelectedValue.ToString();
            if (maMon != "" && maLop != "")
                dgv_Diem_Dong.DataSource = diemBll.dsDiem(maMon, maLop);
        }
        void xoaTrangDiem()
        {
            tb_DiemCC_Dong.Text = "";
            tb_DiemHs1_Dong.Text = "";
            tb_DiemHs21_Dong.Text = "";
            tb_DiemHs22_Dong.Text = "";
            tb_DiemThi_Dong.Text = "";
            lbl_DiemQuaTrinh_Dong.Text = "0";
            lbl_DiemHP_Dong.Text = "0";
            lbl_MaSvNhap_Dong.Text = ".";
            lbl_MonNhap_Dong.Text = ".";
            lbl_TinChiNhap_Dong.Text = ".";

        }

        private void btn_LocDiem_Dong_Click(object sender, EventArgs e)
        {
            loadDiem();
        }

        private void dgv_Diem_Dong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row1 = e.RowIndex;
            tb_DiemCC_Dong.Text = dgv_Diem_Dong.Rows[row1].Cells["DiemChuyenCan"].Value.ToString();
            tb_DiemHs1_Dong.Text = dgv_Diem_Dong.Rows[row1].Cells["DiemHe1"].Value.ToString();
            tb_DiemHs21_Dong.Text = dgv_Diem_Dong.Rows[row1].Cells["DiemHe21"].Value.ToString();
            tb_DiemHs22_Dong.Text = dgv_Diem_Dong.Rows[row1].Cells["DiemHe22"].Value.ToString();
            String ktDiemQt = dgv_Diem_Dong.Rows[row1].Cells["DiemQuaTrinh"].Value.ToString();
            String ktDiemHp = dgv_Diem_Dong.Rows[row1].Cells["DiemHocPhan"].Value.ToString();
            if (ktDiemQt == "")
            {
                lbl_DiemQuaTrinh_Dong.Text = "0";
            }
            else
            {
                lbl_DiemQuaTrinh_Dong.Text = dgv_Diem_Dong.Rows[row1].Cells["DiemQuaTrinh"].Value.ToString();
            }
            tb_DiemThi_Dong.Text = dgv_Diem_Dong.Rows[row1].Cells["DiemThi"].Value.ToString();
            if (ktDiemHp == "")
            {
                lbl_DiemHP_Dong.Text = "0";
            }
            else
            {
                lbl_DiemHP_Dong.Text = dgv_Diem_Dong.Rows[row1].Cells["DiemHocPhan"].Value.ToString();
            }
            lbl_MaSvNhap_Dong.Text = dgv_Diem_Dong.Rows[row1].Cells["MaSvDem"].Value.ToString();
            lbl_MonNhap_Dong.Text = cb_MonDiem_Dong.Text;
            DataTable mon = monHocBll.monHocTheoMa(cb_MonDiem_Dong.SelectedValue.ToString());
            lbl_TinChiNhap_Dong.Text = mon.Rows[0]["SoTin"].ToString();
        }

        //Tính điểm quá trình vào lưu vào database
        private void btn_DiemQuaTrinh_Dong_Click(object sender, EventArgs e)
        {

            String maSv = lbl_MaSvNhap_Dong.Text;
            String maMon = cb_MonDiem_Dong.SelectedValue.ToString();
            int soTin = int.Parse(lbl_TinChiNhap_Dong.Text);
            float diemCc = float.Parse(tb_DiemCC_Dong.Text);
            float diemHe1 = float.Parse(tb_DiemHs1_Dong.Text);
            float diemH21 = float.Parse(tb_DiemHs21_Dong.Text);
            float diemH22 = float.Parse(tb_DiemHs22_Dong.Text);
            float diemQt = (float)(diemCc * soTin + diemHe1 + diemH21 * 2 + diemH22 * 2) / (soTin + 5);
            lbl_DiemQuaTrinh_Dong.Text = Math.Round(diemQt, 2).ToString();
            if (diemBll.suaDiemQt(maSv, maMon, diemCc.ToString(), diemHe1.ToString(), diemH21.ToString(), diemH22.ToString(), Math.Round(diemQt, 2).ToString()))
            {
                MessageBox.Show("Nhập điểm thành công.");
                loadDiem();
                xoaTrangDiem();
            }
        }

        //Nhập và tính điểm thi
        private void btn_DiemHocPhan_Dong_Click(object sender, EventArgs e)
        {
            String maSv = lbl_MaSvNhap_Dong.Text;
            String maMon = cb_MonDiem_Dong.SelectedValue.ToString();
            float diemQt = float.Parse(lbl_DiemQuaTrinh_Dong.Text);
            if (diemQt == 0)
            {
                MessageBox.Show("Thiếu điểm quá trình.");
            }
            else
            {
                float diemThi = float.Parse(tb_DiemThi_Dong.Text);
                float diemHP = (float)(diemQt * 0.4 + diemThi * 0.6);
                lbl_DiemHP_Dong.Text = Math.Round(diemHP, 2).ToString();
                if (diemBll.suaDiemHP(maSv, maMon, diemThi.ToString(), Math.Round(diemHP, 2).ToString()))
                {
                    MessageBox.Show("Nhập điểm thành công.");
                    loadDiem();
                    xoaTrangDiem();
                }
            }

        }


        ////Hết phần tính điểm///////////////////////////////////

        //Sinh viên đăng ký môn học//////////////////////
        void loadDkSV()
        {
            DataTable data = sinhVienBll.dsSinhVienTheoTenDN(TenDNhap.Trim());
            lbl_TenSV_Dong.Text = data.Rows[0]["HoDem"].ToString() + " " + data.Rows[0]["Ten"].ToString();
            dgv_dsMon_Dong.DataSource = monHocBll.dsMonHoc();
        }

        private void dgv_dsMon_Dong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row1 = e.RowIndex;
            lbl_MaMonDk_Dong.Text = dgv_dsMon_Dong.Rows[row1].Cells["MaMonDK"].Value.ToString();
            lbl_TenMonDK_Dong.Text = dgv_dsMon_Dong.Rows[row1].Cells["TenMonDK"].Value.ToString();
        }

        private void btn_DKMon_Dong_Click(object sender, EventArgs e)
        {
            DataTable data = sinhVienBll.dsSinhVienTheoTenDN(TenDNhap.Trim());
            DataTable dataCheck = diemBll.ktDiem(lbl_MaMonDk_Dong.Text, data.Rows[0]["MaSV"].ToString());
            if (dataCheck!=null&& dataCheck.Rows.Count > 0)
            {
                MessageBox.Show("Môn đã đăng ký");
            }
            else
            {
                if (diemBll.dangKyMon(data.Rows[0]["MaSV"].ToString(), lbl_MaMonDk_Dong.Text))
                {
                    MessageBox.Show("Đăng ký môn thành công");
                }
            }
            
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        ///Thống kê
        void loadCbbMonTK()
        {
            cb_MaMonTK_Khai.DataSource = monHocBll.dsMonHoc();
            cb_MaMonTK_Khai.DisplayMember = "TenMon";
            cb_MaMonTK_Khai.ValueMember = "MaMon";
        }
        void loadCbbLopTK()
        {
            cb_MaLopTK_Khai.DataSource = lopHocBll.dsLopHoc();
            cb_MaLopTK_Khai.DisplayMember = "TenLop";
            cb_MaLopTK_Khai.ValueMember = "MaLop";
            cb_MLopTK_Khai.DataSource = lopHocBll.dsLopHoc();
            cb_MLopTK_Khai.DisplayMember = "TenLop";
            cb_MLopTK_Khai.ValueMember = "MaLop";

        }
        void loadSvTK()
        {
            
            String maLop = cb_MaLopTK_Khai.SelectedValue.ToString();
            dgv_SvTK_Khai.DataSource = sinhVienBll.dsSinhVienTheoMaLop(maLop);
        }
        void loadDiemTK()
        {
            String maMon = cb_MaMonTK_Khai.SelectedValue.ToString();
            String maLop = cb_MLopTK_Khai.SelectedValue.ToString();
            dgv_DiemTK_Khai.DataSource = diemBll.dsDiemTk(maMon, maLop);
        }

        private void btn_LocSvTK_Khai_Click(object sender, EventArgs e)
        {
            loadSvTK();
        }

        private void btn_LocDiemTK_Khai_Click(object sender, EventArgs e)
        {
            loadDiemTK();
        }

        private void frm_Menu_Load(object sender, EventArgs e)
        {

        }

        ///Hết thống kê/////////////


    }
}
