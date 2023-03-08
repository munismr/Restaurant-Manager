using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDonNhaps = new HashSet<HoaDonNhap>();
            HoaDonXuats = new HashSet<HoaDonXuat>();
            QuyenForms = new HashSet<QuyenForm>();
        }

        public int MaNhanVien { get; set; }
        public int MaBoPhan { get; set; }
        public string TenNhanVien { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public int DienThoai { get; set; }

        public virtual BoPhan MaBoPhanNavigation { get; set; }
        public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; }
        public virtual ICollection<HoaDonXuat> HoaDonXuats { get; set; }
        public virtual ICollection<QuyenForm> QuyenForms { get; set; }
    }
}
