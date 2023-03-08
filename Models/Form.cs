using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class Form
    {
        public Form()
        {
            QuyenForms = new HashSet<QuyenForm>();
        }

        public string TenForm { get; set; }

        public virtual ICollection<QuyenForm> QuyenForms { get; set; }
    }
}
