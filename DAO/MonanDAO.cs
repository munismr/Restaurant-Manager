using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantManager.DAO
{
    public class MonanDAO
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        public List<MonAn> dsmonan()
        {
            var monan = from ma in db.MonAns
                        
                        select ma;
            return monan.ToList();
        }
        public List<MonAn> dsmonantheonhom(int manhom)
        {
            var monan = from ma in db.MonAns
                        where ma.MaNhomMonAn == manhom
                        select ma;
            return monan.ToList();
        }

        public MonAn matheoma(int mama)
        {
            var monan= db.MonAns.SingleOrDefault(ma=>ma.MaMonAn== mama);
            return (MonAn)monan;
        }

        public bool themma(string ten, int manhom, int dongia, string dvt)
        {
            var monan = db.MonAns.SingleOrDefault(ma => ma.TenMonAn == ten);
            if (monan == null)
            {              
                MonAn ma = new MonAn();
                ma.TenMonAn = ten;
                ma.MaNhomMonAn = manhom;
                ma.DonGia =dongia;
                ma.DonViTinh = dvt;

                db.MonAns.Add(ma);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void suama(int mama,string ten, int manhom, int dongia, string dvt)
        {
            var monan = db.MonAns.SingleOrDefault(ma => ma.MaMonAn==mama);

            monan.TenMonAn = ten;
            monan.MaNhomMonAn = manhom;
            monan.DonGia = dongia;
            monan.DonViTinh = dvt;

           
            db.SaveChanges();
        }


    }
}
