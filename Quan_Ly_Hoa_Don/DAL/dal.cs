using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Common;

namespace Quan_Ly_Hoa_Don.DAL
{
    class dal
    {
        public SqlConnection GetConnect()
        {
            String connString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyHoaDon;Integrated Security=True";
            //String connString = @"Server=.\SQLEXPRESS; AttachDbFilename =| DataDirectory | Database1.mdf; Database = QuanLyHoaDon; Trusted_Connection = Yes";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
        public DataTable GetTable(String sql)
        {
            SqlConnection con = GetConnect();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public bool ExecuteNonQuery(String sql)
        {
            SqlConnection con = GetConnect();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
