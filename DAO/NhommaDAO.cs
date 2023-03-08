using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Resources;

namespace RestaurantManager.DAO
{
    public class NhommaDAO
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        public List<NhomMonAn> dsnhomma()
        {
            var nhomma = from nma in db.NhomMonAns
                         select nma;
            List<NhomMonAn> list= nhomma.ToList();
            return list;
        }

        public bool themnma(string ten)
        {
            var nhomma = db.NhomMonAns.SingleOrDefault(nma => nma.TenNhomMonAn == ten);
            if (nhomma == null)
            {
                NhomMonAn nma = new NhomMonAn();
                nma.TenNhomMonAn = ten;
                db.NhomMonAns.Add(nma);
                db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }
        public void suannm(string ten, string tensua)
        {
            var nhomma = db.NhomMonAns.SingleOrDefault(nma => nma.TenNhomMonAn == ten);
            nhomma.TenNhomMonAn = tensua;
            db.SaveChanges();
        }
        public NhomMonAn nmatheoma(int ma)
        {
            var nhomma = db.NhomMonAns.SingleOrDefault(nma => nma.MaNhomMonAn == ma);
            return (NhomMonAn)nhomma;
        }
    }
}
