using _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.BLL
{
    internal class DiemBll
    {
        dal da = new dal();
        public DataTable dsDiem(String maMon, String maLop)
        {
            String sql = "select SinhVien.MaSV,HoDem,Ten,NgaySinh,GioiTinh,TenLop,DiemChuyenCan,DiemHe1,DiemHe21,DiemHe22,DiemQuaTrinh,DiemThi,DiemHocPhan  ";
            sql += "from Diem,SinhVien,LopHoc  ";
            sql += "where Diem.MaSV=SinhVien.MaSV and SinhVien.MaLop=LopHoc.MaLop  ";
            sql += "and MaMon='"+maMon+"' and LopHoc.MaLop='"+maLop+"'";
            return da.GetTable(sql);
        }
        public DataTable dsDiemTk(String maMon, String maLop)
        {
            String sql = "select SinhVien.MaSV,HoDem,Ten,DiemChuyenCan,DiemHe1,DiemHe21,DiemHe22,DiemQuaTrinh,DiemThi,DiemHocPhan  ";
            sql += "from Diem,SinhVien,LopHoc  ";
            sql += "where Diem.MaSV=SinhVien.MaSV and SinhVien.MaLop=LopHoc.MaLop  ";
            sql += "and MaMon='" + maMon + "' and LopHoc.MaLop='" + maLop + "'";
            return da.GetTable(sql);
        }
        public bool suaDiemQt(String maSv, String maMon, String diemCc, String diemHe1, String diemHe21, String diemHe22, String diemQt)
        {
            string sql = "update Diem set DiemChuyenCan='"+diemCc+ "',DiemHe1='"+diemHe1+ "',DiemHe21='" + diemHe21 + "',DiemHe22='" + diemHe22 + "',DiemQuaTrinh='" + diemQt + "'where MaMon='" + maMon + "' and MaSV='"+maSv+"'";
            return da.ExecuteNonQuery(sql);
        }
        public bool suaDiemHP(String maSv, String maMon, String diemThi, String diemHP)
        {
            string sql = "update Diem set DiemThi='" + diemThi + "',DiemHocPhan='" + diemHP + "' where MaMon='" + maMon + "' and MaSV='" + maSv + "'";
            return da.ExecuteNonQuery(sql);
        }
        public bool dangKyMon(String maSv, String maMon)
        {
            string sql = "insert into Diem(MaMon,MaSV) values ('" + maMon + "','" + maSv + "')";
            return da.ExecuteNonQuery(sql);
        }
        public DataTable ktDiem(String maMon, String maSV)
        {
            String sql = "select * from Diem where MaMon='" + maMon + "' and MaSV='" + maSV + "'";
            return da.GetTable(sql);
        }
    }
}
