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
            InitializeComponent();
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
    }
}
