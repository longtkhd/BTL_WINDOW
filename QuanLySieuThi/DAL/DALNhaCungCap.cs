using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;


namespace DAL
{
    public class DALNhaCungCap
    {
        public List<NhaCungCap> layNhaCungCap()
        {
            List<NhaCungCap> arr = new List<NhaCungCap>();

           
            Connect.openConnect();
            string query = "select * from NhaCungCap";
            SqlCommand cmd = new SqlCommand(query, Connect.connect);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NhaCungCap x = new NhaCungCap(int.Parse(dr["maNhaCungCap"] + ""), dr["tenNhaCungCap"] + "", dr["diaChi"] + "");
                arr.Add(x);
            }
            Connect.closeConnect();
            return arr;
        }
        public List<NhaCungCap> layNhaCungCapTheoTen(string tenNhaCungCap)
        {
            List<NhaCungCap> arr = new List<NhaCungCap>();

            Connect.openConnect();
            string query = "select * from NhaCungCap where tenNhaCungCap LIKE @tenNhaCungCap + '%'";
            SqlCommand cmd = new SqlCommand(query, Connect.connect);
            cmd.Parameters.AddWithValue("tenNhaCungCap", tenNhaCungCap);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NhaCungCap x = new NhaCungCap(int.Parse(dr["maNhaCungCap"] + ""), dr["tenNhaCungCap"] + "", dr["diaChi"] + "");
                arr.Add(x);
            }
            Connect.closeConnect();
            return arr;
        }
        public List<NhaCungCap> layNhaCungCapTheoMa(string maNhaCungCap)
        {
            List<NhaCungCap> arr = new List<NhaCungCap>();

            Connect.openConnect();
            string query = "select * from NhaCungCap where maNhaCungCap LIKE @maNhaCungCap + '%'";
            SqlCommand cmd = new SqlCommand(query, Connect.connect);
            cmd.Parameters.AddWithValue("maNhaCungCap", maNhaCungCap);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NhaCungCap x = new NhaCungCap(int.Parse(dr["maNhaCungCap"] + ""), dr["tenNhaCungCap"] + "", dr["diaChi"] + "");
                arr.Add(x);
            }
            Connect.closeConnect();
            return arr;
        }
        public void themNhaCungCap(NhaCungCap ncc)
        {
            string sql = "insert into NhaCungCap values(@tenNhaCungCap, @diaChi)";
            Connect.openConnect();
            SqlCommand cmd = new SqlCommand(sql, Connect.connect);
            cmd.Parameters.AddWithValue("tenNhaCungCap", ncc.TenNhaCungCap);
            cmd.Parameters.AddWithValue("diaChi", ncc.DiaChi);

            cmd.ExecuteNonQuery();
            Connect.closeConnect();
        }
        public void suaNhaCungCap(NhaCungCap ncc)
        {
            string sql = "update NhaCungCap set diaChi=@diaChi, tenNhaCungCap=@tenNhaCungCap where maNhaCungCap =@maNhaCungCap ";
            Connect.openConnect();
            SqlCommand cmd = new SqlCommand(sql, Connect.connect);
            cmd.Parameters.AddWithValue("maNhaCungCap", ncc.MaNhaCungCap);
            cmd.Parameters.AddWithValue("tenNhaCungCap", ncc.TenNhaCungCap);
            cmd.Parameters.AddWithValue("diaChi", ncc.DiaChi);

            cmd.ExecuteNonQuery();
            Connect.closeConnect();
        }

        public void xoaNhaCungCap(NhaCungCap ncc)
        {
            string sql = "delete from NhaCungCap where maNhaCungCap=@maNhaCungCap";
            Connect.openConnect();
            SqlCommand cmd = new SqlCommand(sql, Connect.connect);
            cmd.Parameters.AddWithValue("maNhaCungCap", ncc.MaNhaCungCap);
            cmd.ExecuteNonQuery();
            Connect.closeConnect();
        }
    }
}
