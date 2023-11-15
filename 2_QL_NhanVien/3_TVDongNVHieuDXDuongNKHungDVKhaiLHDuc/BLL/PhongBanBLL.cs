using _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.BLL
{
    internal class PhongBanBLL
    {
        dal da = new dal();
        public DataTable dsPhongBan()
        {
            string sql = "select * from PhongBan";
            return da.GetTable(sql);
        }
        public DataTable phongbanTheoMa(string maPB)
        {
            string sql = "select * from PhongBan where MaPB='" + maPB + "'";
            return da.GetTable(sql);
        }
        public bool themPhongBan(string maPB, string tenPB, string diachiPB, string sdtPB)
        {
            string sql = "insert into PhongBan  " +
                "values ('" + maPB + "',N'" + tenPB + "',N'" + diachiPB + "',N'" + sdtPB + "')";
            return da.ExecuteNonQuery(sql);
        }
        public DataTable ktPhongBan(String maPB)
        {
            string sql = "select * from PhongBan where MaPB='" + maPB + "'";
            return da.GetTable(sql);
        }
        public bool suaPhongBan(string maPB, string tenPB, string diachiPB, string sdtPB)
        {
            string sql = "update PhongBan set TenPB=N'" + tenPB + "',DiachiPB=N'" + diachiPB + "',SDTPB=N'" + sdtPB + "' where MaPB='" + maPB + "'";
            return da.ExecuteNonQuery(sql);
        }
        public bool xoaPhongBan(String maPB)
        {
            string sql = "delete from PhongBan where MaPB='" + maPB + "'";
            return da.ExecuteNonQuery(sql);
        }
    }
}
