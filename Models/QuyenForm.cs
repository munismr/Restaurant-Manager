using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class QuyenForm
    {
        public int MaQuyenForm { get; set; }
        public string TenForm { get; set; }
        public int MaNguoiDung { get; set; }
        public int MaNhanVien { get; set; }

        public virtual NguoiDung MaNguoiDungNavigation { get; set; }
        public virtual NhanVien MaNhanVienNavigation { get; set; }
        public virtual Form TenFormNavigation { get; set; }
    }
}
