using _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.BLL
{
    internal class TrinhDoHocVanBLL
    {
        dal da = new dal();
        public DataTable dsHocVan()
        {
            string sql = "select * from TrinhDoHocVan";
            return da.GetTable(sql);
        }
        public DataTable hocvanTheoMa(string maTDHV)
        {
            string sql = "select * from TrinhDoHocVan where MaTDHV='" + maTDHV + "'";
            return da.GetTable(sql);
        }
        public bool themHocVan(string maTDHV, string tenTDHV, string chuyennganh)
        {
            string sql = "insert into TrinhDoHocVan  " +
                "values ('" + maTDHV + "',N'" + tenTDHV + "',N'" + chuyennganh + "')";
            return da.ExecuteNonQuery(sql);
        }
        public DataTable ktHocVan(String maTDHV)
        {
            string sql = "select * from TrinhDoHocVan where MaTDHV='" + maTDHV + "'";
            return da.GetTable(sql);
        }
        public bool suaHocVan(string maTDHV, string tenTDHV, string chuyennganh)
        {
            string sql = "update TrinhDoHocVan set TenTDHV=N'" + tenTDHV + "',ChuyenNganh=N'" + chuyennganh + "' where MaTDHV='" + maTDHV + "'";
            return da.ExecuteNonQuery(sql);
        }
        public bool xoaHocVan(String maTDHV)
        {
            string sql = "delete from TrinhDoHocVan where MaTDHV='" + maTDHV + "'";
            return da.ExecuteNonQuery(sql);
        }
    }
}
