using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TVDongNVHieuDXDuongNKHungDVKhaiLHDuc.DAL
{
    internal class dal
    {
        public SqlConnection GetConnect()
        {
            string connString = @"Data Source=Dong;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //String connString = @"Server=.\SQLEXPRESS; AttachDbFilename =| DataDirectory | Database1.mdf; Database = QuanLyHoaDon; Trusted_Connection = Yes";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
        // hàm lấy dữu liệu trả về datatable
        public DataTable GetTable(String sql)
        {
            SqlConnection con = GetConnect();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        // hàm thực hiện sửa và thêm
        public bool ExecuteNonQuery(String sql)
        {
            SqlConnection con = GetConnect();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            if (cmd.ExecuteNonQuery() > 0)
            { return true; }
            else
                return false;
        }
    }
}
