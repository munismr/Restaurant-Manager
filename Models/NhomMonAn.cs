using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class NhomMonAn
    {
        public NhomMonAn()
        {
            MonAns = new HashSet<MonAn>();
        }

        public int MaNhomMonAn { get; set; }
        public string TenNhomMonAn { get; set; }

        public virtual ICollection<MonAn> MonAns { get; set; }
    }
}
