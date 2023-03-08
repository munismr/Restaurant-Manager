using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class HoaDonNhap
    {
        public HoaDonNhap()
        {
            ChiTietHoaDonNhaps = new HashSet<ChiTietHoaDonNhap>();
        }

        public int MaHoaDonNhap { get; set; }
        public int MaNhanVien { get; set; }
        public int MaNhaCungCap { get; set; }
        public double TongTien { get; set; }
        public DateTime ThoiGian { get; set; }

        public virtual NhanVien MaNhanVien1 { get; set; }
        public virtual NhaCungCap MaNhanVienNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
    }
}
