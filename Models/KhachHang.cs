using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDonXuats = new HashSet<HoaDonXuat>();
        }

        public int MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }

        public virtual ICollection<HoaDonXuat> HoaDonXuats { get; set; }
    }
}
