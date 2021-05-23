using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;


namespace DAL
{
    public class DALHang
    {
        public List<Hang> layHang()
        {
            List<Hang> arr = new List<Hang>();

        
            Connect.openConnect();
            string query = "select * from Hang";
            SqlCommand cmd = new SqlCommand(query, Connect.connect);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Hang x = new Hang(int.Parse(dr["maHang"] + ""), dr["tenHang"] + "", dr["donViTinh"] + "",float.Parse(dr["donGia"] + ""),int.Parse(dr["soLuongCon"] + ""),int.Parse(dr["maLoaiHang"] + ""), int.Parse(dr["maNhaCungCap"] + "")  );
                arr.Add(x);
            }
            Connect.closeConnect();
            return arr;
        }
        public List<Hang> layHangTheoTen(string tenHang)
        {
            List<Hang> arr = new List<Hang>();

            Connect.openConnect();
            string query = "select * from Hang where tenHang LIKE @tenHang + '%'";
            SqlCommand cmd = new SqlCommand(query, Connect.connect);
            cmd.Parameters.AddWithValue("tenHang", tenHang);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Hang x = new Hang(int.Parse(dr["maHang"] + ""), dr["tenHang"] + "", dr["donViTinh"] + "", float.Parse(dr["donGia"] + ""), int.Parse(dr["soLuongCon"] + ""), int.Parse(dr["maLoaiHang"] + ""), int.Parse(dr["maNhaCungCap"] + ""));

                arr.Add(x);
            }
            Connect.closeConnect();
            return arr;
        }
        public bool coLoaiHang(string maLoaiHang)
        {
            bool check = false;
            List<Hang> arr = new List<Hang>();

            Connect.openConnect();
            string query = "select * from Hang where maLoaiHang = @maLoaiHang";
            SqlCommand cmd = new SqlCommand(query, Connect.connect);
            cmd.Parameters.AddWithValue("maLoaiHang", maLoaiHang);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                check = true;
            }
            Connect.closeConnect();
            return check;
        }
        public bool coNhaCungCap(string maNhaCungCap)
        {
            bool check = false;
            List<Hang> arr = new List<Hang>();

            Connect.openConnect();
            string query = "select * from Hang where maNhaCungCap = @maNhaCungCap";
            SqlCommand cmd = new SqlCommand(query, Connect.connect);
            cmd.Parameters.AddWithValue("maNhaCungCap", maNhaCungCap);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                check = true;
            }
            Connect.closeConnect();
            return check;
        }
        public List<Hang> layHangTheoMa(string maHang)
        {
            List<Hang> arr = new List<Hang>();

            Connect.openConnect();
            string query = "select * from Hang where maHang LIKE @maHang + '%'";
            SqlCommand cmd = new SqlCommand(query, Connect.connect);
            cmd.Parameters.AddWithValue("maHang", maHang);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Hang x = new Hang(int.Parse(dr["maHang"] + ""), dr["tenHang"] + "", dr["donViTinh"] + "", float.Parse(dr["donGia"] + ""), int.Parse(dr["soLuongCon"] + ""), int.Parse(dr["maLoaiHang"] + ""), int.Parse(dr["maNhaCungCap"] + ""));
                arr.Add(x);
            }
            Connect.closeConnect();
            return arr;
        }
        public void themHang(Hang h)
        {
            string sql = "insert into Hang values(@tenHang, @donViTinh, @donGia, @soLuongCon, @maLoaiHang, @maNhaCungCap)";
            Connect.openConnect();
            SqlCommand cmd = new SqlCommand(sql, Connect.connect);
            cmd.Parameters.AddWithValue("tenHang", h.TenHang);
            cmd.Parameters.AddWithValue("donViTinh", h.DonViTinh);
            cmd.Parameters.AddWithValue("donGia", h.DonGia);
            cmd.Parameters.AddWithValue("soLuongCon", h.SoLuongCon);
            cmd.Parameters.AddWithValue("maLoaiHang", h.MaLoaiHang);
            cmd.Parameters.AddWithValue("maNhaCungCap", h.MaNhaCungCap);

            cmd.ExecuteNonQuery();
            Connect.closeConnect();
        }
        public void suaHang(Hang h)
        {
            string sql = "update Hang set tenHang=@tenHang, donViTinh=@donViTinh, donGia=@donGia, soLuongCon=@soLuongCon, maLoaiHang=@maLoaiHang, maNhaCungCap=@maNhaCungCap where maHang =@maHang ";
            Connect.openConnect();
            SqlCommand cmd = new SqlCommand(sql, Connect.connect);
            cmd.Parameters.AddWithValue("maHang", h.MaHang);
            cmd.Parameters.AddWithValue("tenHang", h.TenHang);
            cmd.Parameters.AddWithValue("donViTinh", h.DonViTinh);
            cmd.Parameters.AddWithValue("donGia", h.DonGia);
            cmd.Parameters.AddWithValue("soLuongCon", h.SoLuongCon);
            cmd.Parameters.AddWithValue("maLoaiHang", h.MaLoaiHang);
            cmd.Parameters.AddWithValue("maNhaCungCap", h.MaNhaCungCap);

            cmd.ExecuteNonQuery();
            Connect.closeConnect();
        }

        public void xoaHang(Hang h)
        {
            string sql = "delete from Hang where maHang=@maHang";
            Connect.openConnect();
            SqlCommand cmd = new SqlCommand(sql, Connect.connect);
            cmd.Parameters.AddWithValue("maHang", h.MaHang);
            cmd.ExecuteNonQuery();
            Connect.closeConnect();
        }
    }
}
