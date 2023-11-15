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
using System.Data.SqlClient;
using _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.DAL;
using static Microsoft.Office;

namespace _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.GUI
{
    public partial class fm_Menu : Form
    {
        NhanVienBLL nhanVienBll = new NhanVienBLL();
        PhongBanBLL phongBanBll = new PhongBanBLL();
        ChucVuBLL chucVuBll = new ChucVuBLL();
        TrinhDoHocVanBLL trinhDoHocVanBLL = new TrinhDoHocVanBLL();
        LuongBLL luongBLL = new LuongBLL();
       TinhLuongBLL tinhLuongBLL = new TinhLuongBLL();
       

        // phân quyền

        String TenDNhap = "";
        public fm_Menu(String quyen, String tenDN) : this()
        {
            TenDNhap = tenDN;
            //Phân quyền, nếu không có quyền sẽ ẩn button ở menu
            
            if (quyen.Equals("CB"))
            {
                btnHome.Visible = true;
                btn_NhanVien_Dong.Visible = true;
                btn_ChucVu_Duong.Visible = true;
                btn_PhongBan_Hung.Visible = true;
                btn_TienLuong_Duc.Visible = true;
                btn_TDHV_Khai.Visible = true;

            }
            if (quyen.Equals("NV"))
            {
                btnHome.Visible = true;
                btn_NhanVien_Dong.Visible = true;
                btn_ChucVu_Duong.Visible = false;         
                btn_PhongBan_Hung.Visible = false;
                btn_TienLuong_Duc.Visible = false;
                btn_TDHV_Khai.Visible = false;
                btn_ThemNV_Dong.Visible = false;
                btn_SuaNV_Dong.Visible = false;
                btn_XoaNV_Dong.Visible=false;
                btn_TinhLuong_Duc.Visible=false;
                btn_Export_Dong.Visible=false;
            }
        }
        // ------------Menu---------------
        public fm_Menu()
        {
            InitializeComponent();
        }

     
        private void btnHome_Click(object sender, EventArgs e)
        {
            tabTong.SelectedIndex = 0;
        }

        private void btn_NhanVien_Dong_Click(object sender, EventArgs e)
        {
            tabTong.SelectedIndex = 1;
            loadMaPb();
            loadMaCV();
            loadMaTDHV();
            loadBacLuong();
            loadNV();
        }

        private void btn_TienLuong_Duong_Click(object sender, EventArgs e)
        {
            tabTong.SelectedIndex = 2;
            loadLuong();
        }

        private void btn_PhongBan_Hung_Click_1(object sender, EventArgs e)
        {
            tabTong.SelectedIndex = 3;
            loadPhongBan();
        }

        private void btn_ChucVu_Duong_Click(object sender, EventArgs e)
        {
            tabTong.SelectedIndex = 4;
            loadChucVu();
        }
        private void btn_TDHV_Khai_Click(object sender, EventArgs e)
        {
            tabTong.SelectedIndex = 5;
            loadHocVan();
        }
        private void btn_TinhLuong_Duc_Click(object sender, EventArgs e)
        {
            tabTong.SelectedIndex=6;
            loadTinhLuong();
        }
        private void btnOut_Click(object sender, EventArgs e)
        {
            fm_DangNhap_NVHieu form = new fm_DangNhap_NVHieu();
            this.Close();
            form.Show();
        }

        //----------- Hết Menu-----------






        //Quản lý nhân viên
        void loadNV()
        {

            dgv_NhanVien_Dong.DataSource = nhanVienBll.dsNhanVien();
        }
        void XoaTrangNV()
        {
            tb_MaNV_Dong.Text = "";
            tb_TenNV_Dong.Text = "";
            tb_DanToc_Dong.Text = "";
            tb_GioiTinh_Dong.Text = "";
            tb_QueQuan_Dong.Text = "";
            tb_NgaySinh_Dong.Text = "";
            tb_SDT_Dong.Text = "";
        }    

        void loadMaPb()
        {
            cb_MaPB_Dong.DataSource = phongBanBll.dsPhongBan();
           cb_MaPB_Dong.DisplayMember = "MaPB";
        }
        void loadMaCV()
        {
            cb_MaCV_Dong.DataSource = chucVuBll.dsChucVu();
            cb_MaCV_Dong.DisplayMember = "MaCV";
        }
        void loadMaTDHV()
        {
            cb_MaTDHV_Dong.DataSource = trinhDoHocVanBLL.dsHocVan();
            cb_MaTDHV_Dong.DisplayMember = "MaTDHV";
        }
        void loadBacLuong()
        {
            cb_BacLuong_Dong.DataSource = luongBLL.dsLuong();
            cb_BacLuong_Dong.DisplayMember = "BacLuong";
        }


        private void btn_ThemNV_Dong_Click(object sender, EventArgs e)
        {
          string maNV       =  tb_MaNV_Dong.Text ;
          string tenNV      = tb_TenNV_Dong.Text ;
          string dantoc     = tb_DanToc_Dong.Text ;
          string gioitinh   = tb_GioiTinh_Dong.Text ;
          string quequan    =  tb_QueQuan_Dong.Text ;
          string ngaysinh   = tb_NgaySinh_Dong.Text ;
          string sdt        = tb_SDT_Dong.Text ;
          string maCV = cb_MaCV_Dong.Text ;
            string maTDHV = cb_MaTDHV_Dong.Text ;
            int bacluong = int.Parse(cb_BacLuong_Dong.Text);
            string maPb = cb_MaPB_Dong.Text ;

            DataTable dataNV = nhanVienBll.checkNV(maNV) ;
            if (dataNV != null && dataNV.Rows.Count > 0)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại.");
            }
            else
            {

                if (nhanVienBll.themNV(maNV,tenNV,dantoc,gioitinh,quequan,ngaysinh,sdt,maCV,maTDHV,bacluong,maPb))
                {
                    MessageBox.Show("Thêm nhân viên thành công.");
                    loadNV();
                    XoaTrangNV();
                }
            }
        }

        private void dgv_NhanVien_Dong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row1 = e.RowIndex;
            tb_MaNV_Dong.Text = dgv_NhanVien_Dong.Rows[row1].Cells["MaNV"].Value.ToString();
            tb_TenNV_Dong.Text = dgv_NhanVien_Dong.Rows[row1].Cells["TenNV"].Value.ToString();
            tb_DanToc_Dong.Text = dgv_NhanVien_Dong.Rows[row1].Cells["DanToc"].Value.ToString();
            tb_GioiTinh_Dong.Text = dgv_NhanVien_Dong.Rows[row1].Cells["GioiTinh"].Value.ToString();
            tb_QueQuan_Dong.Text = dgv_NhanVien_Dong.Rows[row1].Cells["QueQuan"].Value.ToString();
            tb_NgaySinh_Dong.Text= dgv_NhanVien_Dong.Rows[row1].Cells["Ngaysinh"].Value.ToString();
            tb_SDT_Dong.Text = dgv_NhanVien_Dong.Rows[row1].Cells["SDT"].Value.ToString();
            cb_MaCV_Dong.Text = dgv_NhanVien_Dong.Rows[row1].Cells["MaCV"].Value.ToString();
            cb_MaTDHV_Dong.Text = dgv_NhanVien_Dong.Rows[row1].Cells["MaHV"].Value.ToString();
            cb_BacLuong_Dong.Text= dgv_NhanVien_Dong.Rows[row1].Cells["BacLuong"].Value.ToString();
            cb_MaPB_Dong.Text= dgv_NhanVien_Dong.Rows[row1].Cells["MaPBan"].Value.ToString();
           
        }
        private void btn_SuaNV_Dong_Click(object sender, EventArgs e)
        {
            string maNV = tb_MaNV_Dong.Text;
            string tenNV = tb_TenNV_Dong.Text;
            string dantoc = tb_DanToc_Dong.Text;
            string gioitinh = tb_GioiTinh_Dong.Text;
            string quequan = tb_QueQuan_Dong.Text;
            string ngaysinh = tb_NgaySinh_Dong.Text;
            string sdt = tb_SDT_Dong.Text;
            string maCV = cb_MaCV_Dong.Text;
            string maTDHV = cb_MaTDHV_Dong.Text;
            int bacluong = int.Parse(cb_BacLuong_Dong.Text);
            string maPb = cb_MaPB_Dong.Text;
            if (nhanVienBll.suaNV(maNV, tenNV, dantoc, gioitinh, quequan, ngaysinh, sdt, maCV, maTDHV, bacluong, maPb))
            {
                MessageBox.Show("Sửa thông tin thành công.");
                loadNV();
                XoaTrangNV();
            }
        }
        private void btn_XoaNV_Dong_Click(object sender, EventArgs e)
        {
            try
            {
                if (nhanVienBll.xoaNV(tb_MaNV_Dong.Text))
                {
                    MessageBox.Show("Xóa nhân viên thành công.");
                    loadNV();
                    XoaTrangNV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa.");
            }
        }

        private void btn_TimNv_Dong_Click(object sender, EventArgs e)
        {
            String timKiem = txt_TimNV_Dong.Text;
            dgv_NhanVien_Dong.DataSource = null;
            dgv_NhanVien_Dong.DataSource = nhanVienBll.timNV(timKiem);
        }

        private DataGridView GetDgv_NhanVien_Dong()
        {
            return dgv_NhanVien_Dong;
        }

        private void btn_Export_Dong_Click(object sender, EventArgs e) 
        {
            /*Datadbject copydata = dgv_NhanVien_Dong.GetClipboardContent();
    
            if (copydata != null) Clipboard.SetDataObject(copydata);
           Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            application.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlwbook;
            Microsoft.Office.Interop.Excel.Worksheet xlwsheet;


            object miseddata = System.Reflection.Missing.Value;
            xlwbook = application.Workbooks.Add(miseddata);

            xlwsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlwbook.Worksheets.get_Item(1);

            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlwsheet.Cells[1, 1];*/

            

        }

        private void ToExcel(object dtgDiem, string fileName)
        {
            throw new NotImplementedException();
        }


        //Hết quản lý nhân viên

        //Quản lý phòng ban

        void loadPhongBan()
        {
            dgv_PhongBan_Hung.DataSource = phongBanBll.dsPhongBan();
        }
        void xoaTrangPB()
        {
            tb_MaPB_Hung.Text = "";
            tb_TenPB_Hung.Text = "";
            tb_DiaChi_Hung.Text = "";
            tb_SdtPB_Hung.Text = "";
        }
        private void btn_ThemPB_Hung_Click(object sender, EventArgs e)
        {
            String maPB = tb_MaPB_Hung.Text;
            String tenPB = tb_TenPB_Hung.Text;
            String diachiPB = tb_DiaChi_Hung.Text;
            String sdtPB = tb_SdtPB_Hung.Text;

            DataTable dataPhongBan = phongBanBll.ktPhongBan(maPB);
            if (dataPhongBan != null && dataPhongBan.Rows.Count > 0)
            {
                MessageBox.Show("Mã phòng ban đã tồn tại.");
            }
            else
            {
                
                if (phongBanBll.themPhongBan(maPB, tenPB, diachiPB, sdtPB))
                {
                    MessageBox.Show("Thêm phòng ban thành công.");
                    loadPhongBan();
                    xoaTrangPB();
                }
            }
        }

        private void btn_SuaPB_Hung_Click(object sender, EventArgs e)
        {
            String maPB = tb_MaPB_Hung.Text;
            String tenPB = tb_TenPB_Hung.Text;
            String diachiPB = tb_DiaChi_Hung.Text;
            String sdtPB = tb_SdtPB_Hung.Text;

            if (phongBanBll.suaPhongBan(maPB, tenPB, diachiPB, sdtPB))
            {
                MessageBox.Show("Sửa môn học thành công.");
                loadPhongBan();
                xoaTrangPB();
            }
        }

        private void dgv_PhongBan_Hung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row1 = e.RowIndex;
           tb_MaPB_Hung.Text = dgv_PhongBan_Hung.Rows[row1].Cells["MaPB"].Value.ToString();
            tb_TenPB_Hung.Text = dgv_PhongBan_Hung.Rows[row1].Cells["TenPB"].Value.ToString();
            tb_DiaChi_Hung.Text = dgv_PhongBan_Hung.Rows[row1].Cells["DiachiPB"].Value.ToString();
            tb_SdtPB_Hung.Text = dgv_PhongBan_Hung.Rows[row1].Cells["SDTPB"].Value.ToString();
        }

        private void btn_XoaPB_Hung_Click(object sender, EventArgs e)
        {
            try
            {
                if (phongBanBll.xoaPhongBan(tb_MaPB_Hung.Text))
                {
                    MessageBox.Show("Xóa phòng ban thành công.");
                    loadPhongBan();
                    xoaTrangPB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa.");
            }
        }
        ////////////////Hết quản lý phòng ban



        /////////////Quản lý chức vụ

        void loadChucVu()
        {
            dgv_ChucVu_Duong.DataSource = chucVuBll.dsChucVu();
        }
        void xoaTrangChucVu()
        {
            tb_MaCV_Duong.Text = "";
            tb_TenCV_Duong.Text = "";
            tb_PhuCapCV_Duong.Text = "";
        }

        private void btn_ThemChucVu_Duong_Click(object sender, EventArgs e)
        {
           string maCV= tb_MaCV_Duong.Text;
           string tenCV= tb_TenCV_Duong.Text ;
           float phucap= float.Parse( tb_PhuCapCV_Duong.Text);

            DataTable dataChuVu = chucVuBll.ktChucVu(maCV);
            if (dataChuVu != null && dataChuVu.Rows.Count > 0)
            {
                MessageBox.Show("Mã chức vụ đã tồn tại.");
            }
            else
            {

                if (chucVuBll.themChucVu(maCV,tenCV,phucap))
                {
                    MessageBox.Show("Thêm chức vụ thành công.");
                    loadChucVu();
                    xoaTrangChucVu();
                }
            }
        }

        private void dgv_ChucVu_Duong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row1 = e.RowIndex;
            tb_MaCV_Duong.Text = dgv_ChucVu_Duong.Rows[row1].Cells["MaCVu"].Value.ToString();
            tb_TenCV_Duong.Text = dgv_ChucVu_Duong.Rows[row1].Cells["TenCV"].Value.ToString();
            tb_PhuCapCV_Duong.Text = dgv_ChucVu_Duong.Rows[row1].Cells["PhuCap"].Value.ToString();
           
        }

        private void btn_SuaChucVu_Duong_Click(object sender, EventArgs e)
        {
            string maCV = tb_MaCV_Duong.Text;
            string tenCV = tb_TenCV_Duong.Text;
            float phucap = float.Parse(tb_PhuCapCV_Duong.Text);

            if (chucVuBll.suaChucVu(maCV,tenCV,phucap))
            {
                MessageBox.Show("Sửa chức vụ thành công.");
                loadChucVu();
                xoaTrangChucVu();
            }
        }

        private void btn_XoaChucVu_Duong_Click(object sender, EventArgs e)
        {
            try
            {
                if (chucVuBll.xoaChucVu(tb_MaCV_Duong.Text))
                {
                    MessageBox.Show("Xóa chức vụ thành công.");
                    loadChucVu();
                    xoaTrangChucVu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa.");
            }
        }
        ///// Hết quản lý chức vụ


        //    Quản lý trình độ học vấn



        void loadHocVan()
        {
            dgv_TDHV_Khai.DataSource = trinhDoHocVanBLL.dsHocVan();
        }
        void xoaTrangHocVan()
        {
            tb_MaTDHV_Khai.Text = "";
            tb_TenTDHV_Khai.Text = "";
            tb_ChuyenNganh_Khai.Text = "";
        }
        private void btn_ThemTDHV_Khai_Click(object sender, EventArgs e)
        {
           string maTDHV    =  tb_MaTDHV_Khai.Text ;
           string tenTDHV   =  tb_TenTDHV_Khai.Text ;
           string chuyennganh = tb_ChuyenNganh_Khai.Text;

            DataTable dataHocVan = trinhDoHocVanBLL.ktHocVan(maTDHV);
            if (dataHocVan != null && dataHocVan.Rows.Count > 0)
            {
                MessageBox.Show("Mã trình độ học vấn đã tồn tại.");
            }
            else
            {

                if (trinhDoHocVanBLL.themHocVan(maTDHV,tenTDHV,chuyennganh))
                {
                    MessageBox.Show("Thêm trình độ học vấn thành công.");
                    loadHocVan();
                    xoaTrangHocVan();
                }
            }
        }

        private void btn_SuaTDHV_Khai_Click(object sender, EventArgs e)
        {
            string maTDHV    =  tb_MaTDHV_Khai.Text ;
           string tenTDHV   =  tb_TenTDHV_Khai.Text ;
           string chuyennganh = tb_ChuyenNganh_Khai.Text;

            if (trinhDoHocVanBLL.suaHocVan(maTDHV, tenTDHV, chuyennganh))
            {
                MessageBox.Show("Sửa trình độ học vấn thành công.");
                loadHocVan();
                xoaTrangHocVan();
            }
        }

        private void dgv_TDHV_Khai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row1 = e.RowIndex;
            tb_MaTDHV_Khai.Text = dgv_TDHV_Khai.Rows[row1].Cells["MaTDHV"].Value.ToString();
            tb_TenTDHV_Khai.Text = dgv_TDHV_Khai.Rows[row1].Cells["TenTDHV"].Value.ToString();
            tb_ChuyenNganh_Khai.Text = dgv_TDHV_Khai.Rows[row1].Cells["ChuyenNganh"].Value.ToString();
        }

        private void btn_XoaTDHV_Khai_Click(object sender, EventArgs e)
        {
            try
            {
                if (trinhDoHocVanBLL.xoaHocVan(tb_MaTDHV_Khai.Text))
                {
                    MessageBox.Show("Xóa trình độ học vấn thành công.");
                    loadHocVan();
                    xoaTrangHocVan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa.");
            }
        }
        ///------Hết trình độ học vấn
        ///


        ///Quản lý hệ số lương
        ///
        void loadLuong()
        {
            dgv_Luong_Duc.DataSource = luongBLL.dsLuong();
        }    

        void xoaTrangLuong()
        {
            tb_BacLuong_Duc.Text = ""; 
            tb_LuongCB_Duc.Text = "";
            tb_HeSoLuong_Duc.Text = "";
            tb_HeSoPhuCap_Duc.Text = "";
        }
        private void btn_ThemLuong_Duc_Click(object sender, EventArgs e)
        {
           int bacluong= int.Parse(tb_BacLuong_Duc.Text);
           int luongcb= int .Parse( tb_LuongCB_Duc.Text) ;
           float hsluong= float.Parse(tb_HeSoLuong_Duc.Text) ;
           float hsphucap=float.Parse( tb_HeSoPhuCap_Duc.Text) ;

            DataTable dataLuong = luongBLL.ktLuong(bacluong);
            if (dataLuong != null && dataLuong.Rows.Count > 0)
             {
                MessageBox.Show("Bậc lương đã tồn tại.");
           }
            else
            {

                if (luongBLL.themLuong(bacluong,luongcb,hsluong,hsphucap))
                {
                    MessageBox.Show("Thêm bậc lương thành công.");
                    loadLuong();
                    xoaTrangLuong();
                }
            }
        }

        private void dgv_Luong_Duc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row1 = e.RowIndex;
            tb_BacLuong_Duc.Text = dgv_Luong_Duc.Rows[row1].Cells["BacLuongg"].Value.ToString();
            tb_LuongCB_Duc.Text = dgv_Luong_Duc.Rows[row1].Cells["LuongCoBan"].Value.ToString();
            tb_HeSoLuong_Duc.Text = dgv_Luong_Duc.Rows[row1].Cells["HeSoLuong"].Value.ToString();
            tb_HeSoPhuCap_Duc.Text = dgv_Luong_Duc.Rows[row1].Cells["HeSoPhuCap"].Value.ToString();
        }

        private void btn_SuaLuong_Duc_Click(object sender, EventArgs e)
        {
            int bacluong = int.Parse(tb_BacLuong_Duc.Text);
            int luongcb = int.Parse(tb_LuongCB_Duc.Text);
            float hsluong = float.Parse(tb_HeSoLuong_Duc.Text);
            float hsphucap = float.Parse(tb_HeSoPhuCap_Duc.Text);

            if (luongBLL.suaLuong(bacluong, luongcb, hsluong, hsphucap))
            {
                MessageBox.Show("Sửa bậc lương thành công.");
                loadLuong();
                xoaTrangLuong();
            }
        }

        private void btn_XoaLuong_Duc_Click(object sender, EventArgs e)
        {
            try
            {
                if (luongBLL.xoaLuong(int.Parse(tb_BacLuong_Duc.Text)))
                {
                    MessageBox.Show("Xóa  thành công");
                    loadLuong();
                    xoaTrangLuong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa.");
            }
        }

        ///// Hết quản lý hệ  số lương
    


        ///--------------Tính tiền lương-------------////
        


        void loadTinhLuong()
        {
            dgv_TinhLuong_Duc.DataSource = tinhLuongBLL.dsLuongNhanVien();
           
        }
       


        private void btn_Tinh_Duc_Click(object sender, EventArgs e)
        {
            float phucap =  float.Parse(tb_PhuCapLuong_Duc.Text);
            int luongcoban= int.Parse(tb_LuongCBL_Duc.Text);
            float hsluong = float.Parse(tb_HeSoLgL_Duc.Text);
            float hsphucap = float.Parse(tb_HeSoPhuCapL_Duc.Text);
            int ngay = int.Parse(tb_SoNgay_Duc.Text);

            

                if (ngay <= 31 && ngay > 0)
                {
                    double tong = (((luongcoban * hsluong + luongcoban * hsphucap) / 30) * ngay) + phucap;
                    tb_TongLuong_Duc.Text = tong.ToString();
                }

                else
                    MessageBox.Show("Bạn cần nhập lại số ngày", "Thông báo");
           
         }

    

       
        private void dgv_TinhLuong_Duc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row1 = e.RowIndex;
            tb_MaNVLuong_Duc.Text = dgv_TinhLuong_Duc.Rows[row1].Cells["MaNVL"].Value.ToString();
            tb_TenNVLuong_Duc.Text = dgv_TinhLuong_Duc.Rows[row1].Cells["TenNVL"].Value.ToString();
            tb_TenCVLuong_Duc.Text = dgv_TinhLuong_Duc.Rows[row1].Cells["TenCVL"].Value.ToString();
            tb_PhuCapLuong_Duc.Text = dgv_TinhLuong_Duc.Rows[row1].Cells["PhuCapL"].Value.ToString();
            tb_BacLuongL_Duc.Text = dgv_TinhLuong_Duc.Rows[row1].Cells["BacLuongL"].Value.ToString();
            tb_LuongCBL_Duc.Text = dgv_TinhLuong_Duc.Rows[row1].Cells["LuongCoBanL"].Value.ToString();
            tb_HeSoLgL_Duc.Text = dgv_TinhLuong_Duc.Rows[row1].Cells["HeSoLuongL"].Value.ToString();
            tb_HeSoPhuCapL_Duc.Text = dgv_TinhLuong_Duc.Rows[row1].Cells["HeSoPhuCapL"].Value.ToString();
        }
        private void btn_Save_Duc_Click(object sender, EventArgs e)
        {
            
            
                string maNV = tb_MaNVLuong_Duc.Text;
                int ngay = int.Parse(tb_SoNgay_Duc.Text);
                decimal tong = decimal.Parse(tb_TongLuong_Duc.Text);


            
            if (tinhLuongBLL.luuLuong(maNV, ngay, tong))
            {
                MessageBox.Show("Lưu thông tin lương thành công.");
                loadTinhLuong();
                tb_TongLuong_Duc.Clear();
                tb_SoNgay_Duc.Clear();
            }

            else
                MessageBox.Show("Lỗi.");


        }
        ///----Hết phần tính lương
        
    }
}
