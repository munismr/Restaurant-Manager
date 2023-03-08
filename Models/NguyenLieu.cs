using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class NguyenLieu
    {
        public NguyenLieu()
        {
            ChiTietHoaDonNhaps = new HashSet<ChiTietHoaDonNhap>();
            DinhLuongs = new HashSet<DinhLuong>();
        }

        public int MaNguyenLieu { get; set; }
        public int MaNhomNguyenLieu { get; set; }
        public string TenNguyenLieu { get; set; }
        public double DonGia { get; set; }
        public string DonViTinh { get; set; }
        public double SoLuong { get; set; }

        public virtual NhomNguyenLieu MaNhomNguyenLieuNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
        public virtual ICollection<DinhLuong> DinhLuongs { get; set; }
    }
}
