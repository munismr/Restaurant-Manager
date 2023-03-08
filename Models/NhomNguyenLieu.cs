using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class NhomNguyenLieu
    {
        public NhomNguyenLieu()
        {
            NguyenLieus = new HashSet<NguyenLieu>();
        }

        public int MaNhomNguyenLieu { get; set; }
        public string TenNhomNguyenLieu { get; set; }

        public virtual ICollection<NguyenLieu> NguyenLieus { get; set; }
    }
}
