using RestaurantManager.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantManager.DAO
{
    public class NguyenlieuDAO
    {
        RestaurantManagerContext db = new RestaurantManagerContext();
        public void xoanltheonhom(int manhom)
        {
            var nguyenlieu = from nl in db.NguyenLieus
                             where nl.MaNhomNguyenLieu == manhom
                             select nl;
            foreach(var item in nguyenlieu) 
            {
                db.NguyenLieus.Remove(item);
            }
            db.SaveChanges();
                            
        }
        public List<NguyenLieu> dsnguyenlieu()
        {
            var nguyenlieu = from nl in db.NguyenLieus
                             
                             select nl;
            return nguyenlieu.ToList();
        }

        public List<NguyenLieu> dsnguyenlieutheonhom(int manll)
        {
            var nguyenlieu = from nl in db.NguyenLieus
                             where nl.MaNhomNguyenLieu == manll
                             select nl;
            return nguyenlieu.ToList();
        }
        public bool themnl(string ten,int manhom,int dongia,string dvt, int soluong)
        {
            var nguyenlieu = db.NguyenLieus.SingleOrDefault(nl => nl.TenNguyenLieu == ten);
            if (nguyenlieu == null)
            {
                
                NguyenLieu nl = new NguyenLieu();
                nl.TenNguyenLieu = ten;
                nl.MaNhomNguyenLieu = manhom;
                nl.DonGia = dongia;
                nl.DonViTinh = dvt;
                nl.SoLuong = soluong;
                db.NguyenLieus.Add(nl);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void suanl(int ma,string ten, int manhom, double dongia, string dvt, double soluong)
        {
            var nguyenlieu = db.NguyenLieus.SingleOrDefault(nl => nl.MaNguyenLieu==ma);

            nguyenlieu.TenNguyenLieu = ten;
            nguyenlieu.MaNhomNguyenLieu = manhom;
            nguyenlieu.DonGia = dongia;
            nguyenlieu.DonViTinh = dvt;
            nguyenlieu.SoLuong = soluong;
            
            db.SaveChanges();
            


        }
        public NguyenLieu nguyenlieutheoma(int manl)
        {
            var nguyenlieu = db.NguyenLieus.SingleOrDefault(nl => nl.MaNguyenLieu == manl);
            return (NguyenLieu)nguyenlieu;
        }
    }
}
