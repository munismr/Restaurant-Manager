using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class ChiTietHoaDonXuat
    {
        public int MaChiTietHoaDonXuat { get; set; }
        public int MaHoaDonXuat { get; set; }
        public int MaMonAn { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }

        public virtual HoaDonXuat MaHoaDonXuatNavigation { get; set; }
        public virtual MonAn MaMonAnNavigation { get; set; }
    }
}
