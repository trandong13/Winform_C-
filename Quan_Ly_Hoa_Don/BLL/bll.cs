using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Common;
using Quan_Ly_Hoa_Don.DAL;

namespace Quan_Ly_Hoa_Don.BLL
{
    class bll
    {
        dal da = new dal();
        public DataTable loadSp(string timkiem)
        {
            string sql = "SELECT TenSp FROM SanPham WHERE dbo.fChuyenCoDauThanhKhongDau(TenSp) like '%" + timkiem+"%'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable loadCbb()
        {
            string sql = "SELECT TenLoai FROM Loai";
            DataTable dtcbb = new DataTable();
            dtcbb = da.GetTable(sql);
            return dtcbb;
        }
        public DataTable loadAllSp()
        {
            string sql = "SELECT * FROM SanPham";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public bool Insert(string tensp)
        {
            string sql = "insert into SanPham values(N'"+tensp+"')";
            return da.ExecuteNonQuery(sql);
        }
        public bool InsertLoai(string tenloai)
        {
            string sql = "insert into Loai values(N'"+tenloai+"')";
            return da.ExecuteNonQuery(sql);
        }
        public bool Delete(string tensp)
        {
            string sql = "delete from SanPham where TenSp=N'"+tensp+"'";
            return da.ExecuteNonQuery(sql);
        }
        public bool DeleteLoai(string tenloai)
        {
            string sql = "delete from Loai where TenLoai=N'" + tenloai + "'";
            return da.ExecuteNonQuery(sql);
        }
        public bool insertBill(string ngay, double tong)
        {
            string sql = "insert into HoaDon values('"+ngay+"','"+tong+"')";
            return da.ExecuteNonQuery(sql);
        }
        public DataTable layTongTien(string thang, string nam)
        {
            string sql = "select sum(TongTien) as TongTien from HoaDon where (Month(ngay)='" + thang+"') and (year(ngay)='"+nam+"')";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public bool DeleteBill()
        {
            string sql = "delete from HoaDon";
            return da.ExecuteNonQuery(sql);
        }
    }
}
