using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.DAO
{
    public class DinhluongDAO
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        public DinhLuong dltheonlvama( int manl,int mama)
        {
            var dinhluong = db.DinhLuongs.SingleOrDefault(dl => dl.MaNguyenLieu == manl && dl.MaMonAn == mama);
            return (DinhLuong)dinhluong;
        }
        public List<DinhLuong> dltheoma(int mama)
        {
            var dinhluong = from dl in db.DinhLuongs
                            where dl.MaMonAn == mama
                            select dl;
            return dinhluong.ToList(); ;
        }
        public void themdl(int manl,int mama,int soluong)
        {
            DinhLuong dl = new DinhLuong();
            dl.MaNguyenLieu = manl;
            dl.MaMonAn = mama;
            dl.SoLuong = soluong;
            db.DinhLuongs.Add(dl);
            db.SaveChanges();
        }
        public void suadl(int madl, int manl, int mama, double soluong)
        {
            var dinhluong = db.DinhLuongs.SingleOrDefault(dl => dl.MaDinhLuong == madl);
            dinhluong.MaNguyenLieu = manl;
            dinhluong.MaMonAn = mama;
            dinhluong.SoLuong = soluong;
            
            db.SaveChanges();
        }
        public void xoadl(int manl, int mama)
        {
            var dinhluong = db.DinhLuongs.SingleOrDefault(dl => dl.MaNguyenLieu == manl && dl.MaMonAn == mama);
            db.DinhLuongs.Remove(dinhluong);
            db.SaveChanges();
        }
    }
}
