using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class Ban
    {
        public Ban()
        {
            HoaDonXuats = new HashSet<HoaDonXuat>();
        }

        public int MaBan { get; set; }
        public string TenBan { get; set; }
        public string Status { get; set; }

        public virtual ICollection<HoaDonXuat> HoaDonXuats { get; set; }
    }
}
