using _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.BLL
{
    internal class DangNhapBLL
    {
        dal da = new dal();

        public DataTable checkLogin(string tentk, string mk)
        {
            string sql = "select * from DangNhap where TaiKhoan ='" + tentk + "' and MatKhau='" + mk + "'";
            return da.GetTable(sql);
        }

        public bool suaMatKhau(string tentk, string mk)
        {
            string sql = "update DangNhap set MatKhau=N'" + mk + "' where TaiKhoan='" + tentk + "'";
            return da.ExecuteNonQuery(sql);
        }
    }
}
