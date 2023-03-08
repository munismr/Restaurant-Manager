using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class NguoiDung
    {
        public NguoiDung()
        {
            QuyenForms = new HashSet<QuyenForm>();
        }

        public int MaNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public string MatKhau { get; set; }

        public virtual ICollection<QuyenForm> QuyenForms { get; set; }
    }
}
