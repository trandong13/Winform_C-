using _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_TVDongNVHieuNKHungNVKhaiDXDuong_LTNET.BLL
{
    internal class DangNhapBll
    {
        dal da = new dal();

        public DataTable checkLogin(string tentk, string mk)
        {
            string sql = "select * from NguoiDung where TenDN ='" + tentk + "' and MatKhau='" + mk + "'";
            return da.GetTable(sql);
        }
    }
}
