using _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.BLL
{
    internal class NhanVienBLL
    {
        dal da = new dal();
        public bool themNV(string maNV,  string tenNV, string dantoc, string gioiTinh, string queQuan, string ngaySinh, string sdt, string maCV, string maTDHV, int bacLuong, string maPB)
        {
            string sql = "insert into NhanVien(MaNV,TenNV,DanToc,GioiTinh,QueQuan,NgaySinh,SDT,MaCV,MaTDHV,BacLuong,MaPB)  " +
                "values ('" + maNV + "',N'" + tenNV + "',N'" + dantoc + "',N'" + gioiTinh + "',N'" + queQuan + "',N'" + ngaySinh + "',N'" + sdt + "',N'" + maCV + "',N'" + maTDHV + "'," + bacLuong + ",N'" + maPB + "')";
            return da.ExecuteNonQuery(sql);
        }
        public DataTable dsNhanVien()
        {
            string sql = "select MaNV,TenNV,DanToc,GioiTinh,QueQuan,NgaySinh,SDT,MaCV,MaTDHV,BacLuong,MaPB,SoNgay,TongLuong from NhanVien where MaNV=MaNV";
            return da.GetTable(sql);
        }
        public DataTable checkNV(string manv)
        {
            string sql = "select * from NhanVien where MaNV='" + manv + "'";
            return da.GetTable(sql);
        }
        public bool suaNV(string maNV, string tenNV, string dantoc, string gioiTinh, string queQuan, string ngaySinh, string sdt, string maCV, string maTDHV, int bacLuong, string maPB)
        {
            string sql = "update NhanVien set TenNV=N'" + tenNV + "', DanToc=N'" + dantoc + "',GioiTinh=N'" + gioiTinh + "',QueQuan=N'" + queQuan + "',NgaySinh=N'" + ngaySinh + "',SDT=N'" + sdt + "',MaCV=N'" + maCV + "',MaTDHV=N'" + maTDHV + "',BacLuong="+bacLuong+",MaPB=N'"+maPB+"' where MaNV='" + maNV + "'";
            return da.ExecuteNonQuery(sql);
        }
        public bool xoaNV(String maNV)
        {
            string sql = "delete from NhanVien where MaNV='" + maNV + "'";
            return da.ExecuteNonQuery(sql);
        }
        public DataTable timNV(string maNV)
        {
            string sql = "select * from NhanVien where MaNV='" + maNV + "'";
            return da.GetTable(sql);
        }
    }
}
