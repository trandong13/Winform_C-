using _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.BLL
{
    internal class ChucVuBLL
    {

        dal da = new dal();
        public DataTable dsChucVu()
        {
            string sql = "select * from ChucVu";
            return da.GetTable(sql);
        }
        public DataTable chucvuTheoMa(string maCV)
        {
            string sql = "select * from ChucVu where MaCV='" + maCV + "'";
            return da.GetTable(sql);
        }
        public bool themChucVu(string maCV, string tenCV, float phucap)
        {
            string sql = "insert into ChucVu  " +
                "values ('" + maCV + "',N'" + tenCV + "'," + phucap + ")";
            return da.ExecuteNonQuery(sql);
        }
        public DataTable ktChucVu(String maCV)
        {
            string sql = "select * from ChucVu where MaCV='" + maCV + "'";
            return da.GetTable(sql);
        }
        public bool suaChucVu(string maCV, string tenCV, float phucap)
        {
            string sql = "update ChucVu set TenCV=N'" + tenCV + "',PhuCap=" + phucap + " where MaCV='" + maCV + "'";
            return da.ExecuteNonQuery(sql);
        }
        public bool xoaChucVu(String maCV)
        {
            string sql = "delete from ChucVu where MaCV='" + maCV + "'";
            return da.ExecuteNonQuery(sql);
        }
    }
}
