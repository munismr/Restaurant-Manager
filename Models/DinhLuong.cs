using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class DinhLuong
    {
        public int MaDinhLuong { get; set; }
        public int MaMonAn { get; set; }
        public int MaNguyenLieu { get; set; }
        public double SoLuong { get; set; }

        public virtual NguyenLieu MaMonAn1 { get; set; }
        public virtual MonAn MaMonAnNavigation { get; set; }
    }
}
