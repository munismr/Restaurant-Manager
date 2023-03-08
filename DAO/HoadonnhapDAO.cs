using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace RestaurantManager.DAO
{
    public class HoadonnhapDAO
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        public void themhdn(HoaDonNhap hdn)
        {
            db.HoaDonNhaps.Add(hdn);
            db.SaveChanges();
        }
        public void suahdn(int mahd, double tongtien)
        {
            var hoadonnhap = db.HoaDonNhaps.SingleOrDefault(hdn => hdn.MaHoaDonNhap == mahd);
            hoadonnhap.TongTien = tongtien;
            db.SaveChanges();
        }
        public List<HoaDonNhap> hdntheotgvanv(DateTime time, int manv)
        {
            var Hoadonnhap = from hdn in db.HoaDonNhaps
                             where hdn.ThoiGian.Date == time && hdn.MaNhanVien == manv
                             select hdn;
            return Hoadonnhap.ToList();
        }
    }
}
