using _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.BLL
{
    internal class LuongBLL
    {
        dal da = new dal();
        public DataTable dsLuong()
        {
            string sql = "select * from Luong";
            return da.GetTable(sql);
        }
        public DataTable LuongTheoBac(int bacLuong)
        {
            string sql = "select * from Luong where BacLuong='" + bacLuong + "'";
            return da.GetTable(sql);
        }
        public bool themLuong(int bacLuong,int luongcb, float hsluong, float hsphucap)
        {
            string sql = "insert into Luong  " +
                "values (" + bacLuong + "," + luongcb + "," + hsluong + "," + hsphucap + ")";
            return da.ExecuteNonQuery(sql);
        }
        public DataTable ktLuong(int bacLuong)
        {
            string sql = "select * from Luong where BacLuong='" + bacLuong + "'";
            return da.GetTable(sql);
        }
        public bool suaLuong(int bacLuong, int luongcb, float hsluong, float hsphucap)
        {
            string sql = "update Luong set LuongCoBan=" + luongcb + ",HeSoLuong=" + hsluong + ",HeSoPhuCap="+hsphucap+" where BacLuong=" + bacLuong + "";
            return da.ExecuteNonQuery(sql);
        }
        public bool xoaLuong(int bacLuong)
        {
            string sql = "delete from Luong where BacLuong=" + bacLuong + "";
            return da.ExecuteNonQuery(sql);
        }
    }
}
