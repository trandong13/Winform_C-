using _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.BLL
{
    internal class LopHocPhanBll
    {
        dal da = new dal();
        public DataTable dsLopHocPhan()
        {
            string sql = "select * from LopHocPhan";
            return da.GetTable(sql);
        }
        public bool themLopHocPhan(string maLop,string maMon, string maGV, int hocKy,int nam)
        {
            string sql = "insert into LopHocPhan " +
                "values ('" + maLop + "','" + maMon + "','" + maGV + "'," + hocKy + "," + nam + ")";
            return da.ExecuteNonQuery(sql);
        }
        public DataTable ktLopHocPhan(String maMon,String maLop)
        {
            string sql = "select * from LopHocPhan where MaMon='" + maMon + "' and MaLop='" + maLop + "'";
            return da.GetTable(sql);
        }
        public bool suaLopHocPhan(string maLop, string maMon, string maGV, int hocKy, int nam)
        {
            string sql = "update LopHocPhan set MaGV='" + maGV + "',HocKy=" + hocKy+ ",Nam=" + nam + " where MaLop='" + maLop + "' and MaMon='" + maMon + "'";
            return da.ExecuteNonQuery(sql);
        }
        public bool xoaMaLopHoc(String maMon, String maLop)
        {
            string sql = "delete from LopHocPhan where MaLop='" + maLop + "' and MaMon='" + maMon + "'";
            return da.ExecuteNonQuery(sql);
        }
    }
}
