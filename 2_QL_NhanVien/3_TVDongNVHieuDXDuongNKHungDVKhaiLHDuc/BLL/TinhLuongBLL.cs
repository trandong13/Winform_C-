using _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.BLL
{
    internal class TinhLuongBLL
    {
        dal da = new dal();
        public DataTable dsLuongNhanVien()
        {
            //string sql = "select MaSV,HoDem,Ten,NgaySinh,GioiTinh,QueQuan,MaLop,Sdt,SinhVien.TenDN,MatKhau from SinhVien, NguoiDung where SinhVien.TenDN=NguoiDung.TenDN";

            string sql = "select MaNV,TenNV,NhanVien.MaCV,TenCV,PhuCap,NhanVien.BacLuong,LuongCoBan,HeSoLuong,HeSoPhuCap from NhanVien,ChucVu,Luong where (NhanVien.MaCV=ChucVu.MaCV) and( NhanVien.BacLuong=Luong.BacLuong )";
            return da.GetTable(sql);

        }

        public bool luuLuong(string maNV, int ngay, decimal tong)
        {
            string sql = "update NhanVien set SoNgay = " + ngay + ", TongLuong = " + tong + " where MaNV = '" + maNV + "'";
            return da.ExecuteNonQuery(sql);
        }
    }
}
