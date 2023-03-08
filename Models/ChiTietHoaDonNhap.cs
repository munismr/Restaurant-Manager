using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class ChiTietHoaDonNhap
    {
        public int MaChiTietHoaDonNhap { get; set; }
        public int MaHoaDonNhap { get; set; }
        public int MaNguyenLieu { get; set; }
        public double SoLuong { get; set; }
        public double DonGia { get; set; }

        public virtual HoaDonNhap MaHoaDonNhapNavigation { get; set; }
        public virtual NguyenLieu MaNguyenLieuNavigation { get; set; }
    }
}
