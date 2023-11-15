using _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.BLL
{
    internal class LopHocBll
    {
        dal da = new dal();
        public DataTable dsLopHoc()
        {
            string sql = "select * from LopHoc";
            return da.GetTable(sql);
        }
        public bool themLopHoc(string maLop, string tenLop, string khoaHoc, string heDaoTao, int namNhapHoc, string tenKhoa)
        {
            string sql = "insert into LopHoc  " +
                "values ('" + maLop + "',N'" + tenLop + "',N'" + khoaHoc + "',N'" + heDaoTao + "'," + namNhapHoc + ",N'" + tenKhoa + "')";
            return da.ExecuteNonQuery(sql);
        }
        public DataTable ktLopHoc(String maLop)
        {
            string sql = "select * from LopHoc where MaLop='"+maLop+"'";
            return da.GetTable(sql);
        }
        public bool suaLopHoc(string maLop, string tenLop, string khoaHoc, string heDaoTao, int namNhapHoc, string tenKhoa)
        {
            string sql = "update LopHoc set TenLop=N'" + tenLop + "', KhoaHoc=N'" + khoaHoc + "',HeDaoTao=N'" + heDaoTao + "',NamNhapHoc=" + namNhapHoc + ",TenKhoa=N'" + tenKhoa + "' where MaLop='" + maLop + "'";
            return da.ExecuteNonQuery(sql);
        }
        public bool xoaLopHoc(String maLop)
        {
            string sql = "delete from LopHoc where MaLop='" + maLop + "'";
            return da.ExecuteNonQuery(sql);
        }
    }
}
