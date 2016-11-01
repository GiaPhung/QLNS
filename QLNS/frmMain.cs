using QLNS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNS
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            frmDangNhap dangNhap = new frmDangNhap();
            dangNhap.ShowDialog();

            currentUser = dangNhap.NguoiDung;

            InitializeComponent();
            Settings.Default.User_CurrentUser = currentUser != null ? currentUser.MaNhanVien : null;
        }
        private DataTransfer.NguoiDung currentUser;
        private void timer_Tick(object sender, EventArgs e)
        {
            lblTimeNow.Caption = DateTime.Now.ToString("HH:mm:ss tt");
            lblDate.Caption = DateTime.Now.ToString("dd/MM/yyyy");
        }
        public Form IsActive(Type type)
        {
            foreach (var f in this.MdiChildren)
            {
                if (f.GetType() == type)
                    return f;
            }
            return null;
        }
        private void btnLapHoaDonMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form lapHD = IsActive(typeof(frmLapHoaDonBanHang));

            if (lapHD != null)
                lapHD.Activate();
            else
            {
                lapHD = new frmLapHoaDonBanHang();
                lapHD.MdiParent = this;
                lapHD.Show();
            }
        }

        private void btnXemCacHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form lapHD = IsActive(typeof(frmHoaDonBanHang));

            if (lapHD != null)
                lapHD.Activate();
            else
            {
                lapHD = new frmHoaDonBanHang();
                lapHD.MdiParent = this;
                lapHD.Show();
            }
        }
        //public void NapStatusBar()
        //{
        //    lblTenNhaSach.Caption = Settings.Default.StoreInfo_Name;
        //}
        private void frmMain_Load(object sender, EventArgs e)
        {
           // NapStatusBar();
            timer.Start();
        }

        private void btnSaoLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form saoLuu = IsActive(typeof(frmSaoLuu));

            if (saoLuu != null)
                saoLuu.Activate();
            else
            {
                saoLuu = new frmSaoLuu();
                saoLuu.MdiParent = this;
                saoLuu.Show();
            }
        }
    }
}
