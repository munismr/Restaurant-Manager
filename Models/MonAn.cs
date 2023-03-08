using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class MonAn
    {
        public MonAn()
        {
            ChiTietHoaDonXuats = new HashSet<ChiTietHoaDonXuat>();
            DinhLuongs = new HashSet<DinhLuong>();
        }

        public int MaMonAn { get; set; }
        public int MaNhomMonAn { get; set; }
        public string TenMonAn { get; set; }
        public double DonGia { get; set; }
        public string DonViTinh { get; set; }

        public virtual NhomMonAn MaNhomMonAnNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDonXuat> ChiTietHoaDonXuats { get; set; }
        public virtual ICollection<DinhLuong> DinhLuongs { get; set; }
    }
}
