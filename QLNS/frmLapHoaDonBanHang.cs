using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace QLNS
{
    public partial class frmLapHoaDonBanHang : DevExpress.XtraEditors.XtraForm
    {
        private DataTransfer.HoaDonBanHang hdbh;
        DataTable tbCTHD = new DataTable();
        private bool isInsert;
        public frmLapHoaDonBanHang(DataTransfer.HoaDonBanHang hdbh = null)
        {
            InitializeComponent();
            this.hdbh = hdbh;
            isInsert = hdbh == null;
            KhoiTaoCacBUSCanThiet();
        }
        public void KhoiTaoCacBUSCanThiet()
        {
            if (BUS.KhachHang == null)
                BUS.KhachHang = new BusinessLogic.KhachHang();
            if (BUS.HoaDonBanHang == null)
                BUS.HoaDonBanHang = new BusinessLogic.HoaDonBanHang();
            if (BUS.CTHoaDonBanHang == null)
                BUS.CTHoaDonBanHang = new BusinessLogic.CTHoaDonBanHang();
        }

        //Nạp giao diện mặc định
        public void NapGiaoDien(DataTransfer.HoaDonBanHang hd = null)
        {
            if(hd == null)
            {
                hd = new DataTransfer.HoaDonBanHang(BUS.HoaDonBanHang.AutoGenerateID(), string.Empty, string.Empty, DateTime.Now, 0, false, string.Empty);
                
                NapGiaoDien(hd);
            }
            else
            {
                //load combobox Khách hàng
                cboMaKhachHang.Properties.Columns.Add(new LookUpColumnInfo("HoTen"));
                cboMaKhachHang.Properties.DataSource = BUS.KhachHang.Table;
                cboMaKhachHang.Properties.DisplayMember = "HoTen";
                cboMaKhachHang.Properties.ValueMember = "MaKhachHang";

                txtMaHoaDon.Text = hd.MaHoaDon;
                dateNgayLap.EditValue = hd.NgayLap;
                cboMaKhachHang.EditValue = hd.MaKhachHang;
                txtGhiChu.Text = hd.GhiChu;
                txtThanhTien.Value = (decimal)hd.ThanhTien;
                chkDaThu.Checked = hd.DaThu;

                //tbCTHD.Rows.Clear();
                //DataRow[] rows = BUS.CTHoaDonBanHang.Table.Select("MaHoaDon = '" + hd.MaHoaDon + "'");
                //foreach (DataRow item in rows)
                //{
                //    DataRow r = tbCTHD.NewRow();
                //    DataRow _r = BUS.SanPham.Table.Select("MaSanPham = '" + item["MaSanPham"] + "'")[0];
                //    r["MaSanPham"] = item["MaSanPham"];
                //    r["TenSanPham"] = _r["TenSanPham"];
                //    r["DonVi"] = _r["DonVi"];
                //    r["SoLuong"] = item["SoLuong"];
                //    r["ThanhTien"] = Convert.ToInt32(r["SoLuong"]) * Convert.ToInt32(_r["GiaBan"]);

                //    tbCTHD.Rows.Add(r);
                //}
            }
        }

        private void frmLapHoaDonBanHang_Load(object sender, EventArgs e)
        {
            NapGiaoDien(hdbh);
            //gridChonSP.DataSource = BUS.
        }
    }
}