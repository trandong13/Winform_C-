using _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.BLL
{
    internal class SinhVienBll
    {
        dal da = new dal();
        public bool themNguoDung(string tentk, string mk)
        {
            string sql = "insert into NguoiDung values ('" +tentk+ "','" +mk+ "','SV')";
            return da.ExecuteNonQuery(sql);
        }
        public bool themSv(string maSv, string hoDem , string ten, string ngaySinh, string gioiTinh, string queQuan, string sdt,string tenDn,string maLop)
        {
            string sql = "insert into SinhVien  " +
                "values ('" + maSv + "',N'" + hoDem + "',N'" + ten + "','" + ngaySinh + "',N'" + gioiTinh + "',N'" + queQuan + "','" + sdt + "','" + maLop + "','" + tenDn + "')";
            return da.ExecuteNonQuery(sql);
        }
        public DataTable dsSinhVien()
        {
            string sql = "select MaSV,HoDem,Ten,NgaySinh,GioiTinh,QueQuan,MaLop,Sdt,SinhVien.TenDN,MatKhau from SinhVien, NguoiDung where SinhVien.TenDN=NguoiDung.TenDN";
            return da.GetTable(sql);
        }
        public DataTable checkSV(string masv)
        {
            string sql = "select * from SinhVien where MaSV='"+masv+"'";
            return da.GetTable(sql);
        }
        public DataTable checkNguoiDung(string tenDn)
        {
            string sql = "select * from NguoiDung where TenDN='" + tenDn + "'";
            return da.GetTable(sql);
        }
        public bool suaSV(String maSv, string hoDem, string ten, string ngaySinh, string gioiTinh, string queQuan, string sdt,string maLop)
        {
            string sql = "update SinhVien set HoDem=N'" + hoDem + "', Ten=N'" + ten + "',NgaySinh='" + ngaySinh + "',GioiTinh=N'" +gioiTinh+ "',QueQuan=N'" +queQuan+ "',SDT='" +sdt+ "',MaLop='" + maLop + "' where MaSV='" + maSv + "'";
            return da.ExecuteNonQuery(sql);
        }
        public bool xoaSV(String maSV)
        {
            string sql = "delete from SinhVien where MaSV='" + maSV + "'";
            return da.ExecuteNonQuery(sql);
        }
        public DataTable timSv(string maSach)
        {
            string sql = "select * from SinhVien where MaSV='" + maSach + "'";
            return da.GetTable(sql);
        }
        public DataTable sapTheoTenSv()
        {
            string sql = "select * from SinhVien order by Ten asc";
            return da.GetTable(sql);
        }
        //public bool suaNguoiDung(String tenDN, String matKhau)
        //{
        //string sql = "update NguoiDung set TenDN='" + tenDN + "',MatKhau='" +matKhau+ "'";
        //return da.ExecuteNonQuery(sql);
        //}
        public DataTable dsSinhVienTheoMaLop(string maLop)
        {
            string sql = "select * from SinhVien where MaLop='" + maLop + "'";
            return da.GetTable(sql);
        }
        public DataTable dsSinhVienTheoTenDN(string tenDN)
        {
            string sql = "select * from SinhVien where TenDN='" + tenDN + "'";
            return da.GetTable(sql);
        }
    }
}
