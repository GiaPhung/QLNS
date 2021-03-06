﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class KhachHang : DBConnect
    {
        private DataTable dt;

        public DataTable Table
        {
            get { return dt; }
            set { dt = value; }
        }
        public KhachHang()
        {
            //nạp bảng lên
            dt = SelectAll();

            //đặt khóa chính
            dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };
        }
        public DataTable SelectAll()
        {
            return GetData("select * from KHACHHANG");
        }
        public bool Them(DataTransfer.KhachHang kh)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from KHACHHANG", Connection);

                //tạo dòng mới và chèn dữ liệu vào
                DataRow r = dt.NewRow();
                r["MaKhachHang"] = kh.MaKhachHang;
                r["HoTen"] = kh.HoTen;
                r["GioiTinh"] = kh.GioiTinh;
                r["DiaChi"] = kh.DiaChi;
                r["SoDienThoai"] = kh.SoDienThoai;
                r["Email"] = kh.Email;
                dt.Rows.Add(r);

                //cập nhật vào CSDL
                SqlCommandBuilder cm = new SqlCommandBuilder(da);
                da.Update(dt);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(string maKhachHang)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from KHACHHANG", Connection);

                //tìm dòng
                DataRow r = dt.Rows.Find(maKhachHang);

                //tìm và xóa tất cả khóa ngoại
                DataAccess.HoaDonBanHang hdbh = new HoaDonBanHang();
                DataRow[] hdbh_row = hdbh.Table.Select("MaKhachHang like '" + maKhachHang + "'");
                foreach (DataRow item in hdbh_row)
                {
                    hdbh.Xoa(item["MaHoaDon"].ToString());
                }

                
                //xóa dòng
                if (r != null)
                    r.Delete();

                //cập nhật vào CSDL
                SqlCommandBuilder cm = new SqlCommandBuilder(da);
                da.Update(dt);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Sua(DataTransfer.KhachHang kh)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from KHACHHANG", Connection);

                //tìm dòng
                DataRow r = dt.Rows.Find(kh.MaKhachHang);

                //cập nhật dòng
                if (r != null)
                {
                    r["MaKhachHang"] = kh.MaKhachHang;
                    r["HoTen"] = kh.HoTen;
                    r["GioiTinh"] = kh.GioiTinh;
                    r["DiaChi"] = kh.DiaChi;
                    r["SoDienThoai"] = kh.SoDienThoai;
                    r["Email"] = kh.Email;
                }

                //cập nhật vào CSDL
                SqlCommandBuilder cm = new SqlCommandBuilder(da);
                da.Update(dt);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
