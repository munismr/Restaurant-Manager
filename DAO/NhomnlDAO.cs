using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantManager.DAO
{
    public class NhomnlDAO
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        public List<NhomNguyenLieu> dsnnl()
        {
            var nhomnl = from nnl in db.NhomNguyenLieus
                         select nnl;
            return nhomnl.ToList();
        }

        public bool themnnl(string tennhom)
        {
            var nhomnl = db.NhomNguyenLieus.SingleOrDefault(nnl => nnl.TenNhomNguyenLieu == tennhom);
            if (nhomnl == null)
            {
                NhomNguyenLieu nnl = new NhomNguyenLieu();
                nnl.TenNhomNguyenLieu = tennhom;
                db.NhomNguyenLieus.Add(nnl);
                db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }
        public void suannl(string tennhom, string tennhomsua)
        {
            var nhomnl = db.NhomNguyenLieus.SingleOrDefault(nnl => nnl.TenNhomNguyenLieu == tennhom);
            nhomnl.TenNhomNguyenLieu = tennhomsua;
            db.SaveChanges();
        }

        public void xoannl(string tennhom)
        {
            var nhomnl = db.NhomNguyenLieus.SingleOrDefault(nnl => nnl.TenNhomNguyenLieu == tennhom);
            db.NhomNguyenLieus.Remove(nhomnl);
            db.SaveChanges();
        }
        public NhomNguyenLieu nnltheoma(int ma)
        {
            var nhomnl = db.NhomNguyenLieus.SingleOrDefault(nnl => nnl.MaNhomNguyenLieu == ma);
            return (NhomNguyenLieu)nhomnl;
        }
    }
}
