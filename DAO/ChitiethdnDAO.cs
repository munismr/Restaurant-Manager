using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.DAO
{
    public class ChitiethdnDAO
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        public void themcthdn(ChiTietHoaDonNhap cthdn)
        {
            db.ChiTietHoaDonNhaps.Add(cthdn);
            db.SaveChanges();
        }
        public List<ChiTietHoaDonNhap> cthdntheohdn(int mahd) {
            var chitiethdn = from cthdn in db.ChiTietHoaDonNhaps
                             where cthdn.MaHoaDonNhap == mahd
                             select cthdn;
            return chitiethdn.ToList();
        }
        public void xoacthdn(ChiTietHoaDonNhap ct)
        {
            
            db.ChiTietHoaDonNhaps.Remove(ct); db.SaveChanges();
        }
        public ChiTietHoaDonNhap cthdntheoma(int ma) 
        {
            var chitiethdn = db.ChiTietHoaDonNhaps.SingleOrDefault(cthdn => cthdn.MaChiTietHoaDonNhap == ma);
            return (ChiTietHoaDonNhap)chitiethdn;
        }
        
    }
}
