﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace QLNS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
           //Application.Run(new frmLapHoaDonBanHang());
            //Application.Run(new frmHoaDonBanHang());
            Application.Run(new frmMain());
            //Application.Run(new frmLapPhieuNhapKho());
            //Application.Run(new frmXemTinhTrang());
        }
    }
}
