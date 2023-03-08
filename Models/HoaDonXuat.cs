using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class HoaDonXuat
    {
        public HoaDonXuat()
        {
            ChiTietHoaDonXuats = new HashSet<ChiTietHoaDonXuat>();
        }

        public int MaHoaDonXuat { get; set; }
        public int MaBan { get; set; }
        public int MaNhanVien { get; set; }
        public double TongTien { get; set; }
        public DateTime ThoiGianVao { get; set; }
        public DateTime ThoiGianRa { get; set; }
        public int GianGia { get; set; }
        public int MaKhachHang { get; set; }

        public virtual NhanVien MaKhachHang1 { get; set; }
        public virtual KhachHang MaKhachHangNavigation { get; set; }
        public virtual Ban MaNhanVienNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDonXuat> ChiTietHoaDonXuats { get; set; }
    }
}
