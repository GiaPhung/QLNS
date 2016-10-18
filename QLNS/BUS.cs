using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS
{
    public static class BUS
    {
        #region Fields
        private static BusinessLogic.HoaDonBanHang _hoadon = null;
        private static BusinessLogic.KhachHang _khachhang = null;
        private static BusinessLogic.CTHoaDonBanHang _cthd = null;
        #endregion

        #region Properties
        public static BusinessLogic.HoaDonBanHang HoaDonBanHang
        {
            get { return _hoadon; }
            set { _hoadon = value; }
        }
        public static BusinessLogic.KhachHang KhachHang
        {
            get { return _khachhang; }
            set { _khachhang = value; }
        }
        public static BusinessLogic.CTHoaDonBanHang CTHoaDonBanHang
        {
            get { return _cthd; }
            set { _cthd = value; }
        }
        #endregion
    }
}
