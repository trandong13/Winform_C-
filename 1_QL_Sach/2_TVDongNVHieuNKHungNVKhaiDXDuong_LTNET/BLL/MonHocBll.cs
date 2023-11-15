using _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.BLL
{
    internal class MonHocBll
    {
        dal da = new dal();
        public DataTable dsMonHoc()
        {
            string sql = "select * from MonHoc";
            return da.GetTable(sql);
        }
        public DataTable monHocTheoMa(string maMon)
        {
            string sql = "select * from MonHoc where MaMon='"+maMon+"'";
            return da.GetTable(sql);
        }
        public bool themMonHoc(string maMon, string tenMon, int soTin)
        {
            string sql = "insert into MonHoc  " +
                "values ('" + maMon + "',N'" + tenMon + "'," + soTin + ")";
            return da.ExecuteNonQuery(sql);
        }
        public DataTable ktMonHoc(String maMon)
        {
            string sql = "select * from MonHoc where MaMon='" + maMon + "'";
            return da.GetTable(sql);
        }
        public bool suaMonHoc(string maMon, string tenMon, int soTin)
        {
            string sql = "update MonHoc set TenMon=N'" + tenMon + "',SoTin=" + soTin + " where MaMon='" + maMon + "'";
            return da.ExecuteNonQuery(sql);
        }
        public bool xoaMonHoc(String maMon)
        {
            string sql = "delete from MonHoc where MaMon='" + maMon + "'";
            return da.ExecuteNonQuery(sql);
        }
    }
}
