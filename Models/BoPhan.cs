using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class BoPhan
    {
        public BoPhan()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public int MaBoPhan { get; set; }
        public string TenBoPhan { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
