﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUL;


namespace QuanLiNhaHang
{
    public partial class frmThemLoaiKhachHang : Form
    {
        frmNhaHang frmST;
        public frmThemLoaiKhachHang(frmNhaHang frm)
        {
            InitializeComponent();
            this.frmST = frm;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                BULLoaiKhachHang bul = new BULLoaiKhachHang();
                bul.themLoaiKhachHang(new LoaiKhachHang(1,txtTenLoaiKhachHang.Text));
                frmST.hienDanhSachLoaiKhachHang();
                MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Thao tác thất bạt, dữ liệu sai", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void frmThemLoaiKhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}
